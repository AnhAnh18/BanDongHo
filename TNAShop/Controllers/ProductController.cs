using AutoMapper;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TNAShop.Application;
using TNAShop.Data;
using TNAShop.Domain;
using TNAShop.Filters;
using TNAShop.Helpers;
using TNAShop.ViewModels;
using TNAShop.ViewModels.ProductViewModel;

namespace TNAShop.Controllers
{
    [HeaderFooterFilter]
    public class ProductController : Controller
    {
        ProductService productService;
        CommentService commentService;
        BrandService brandService;
        OrderService orderService;

        public ProductController() {
            productService = new ProductService();
            brandService = new BrandService();
            commentService = new CommentService();
            orderService = new OrderService();
        }

        public ActionResult AddToCart(ProductDetailViewModel viewModel,string btnSubmit) {
            if(Session["Carts"]==null)
                Session["Carts"] = new List<ProductShoppingCart>();
            ProductShoppingCart cart = Mapper.Map<ProductDetailViewModel, ProductShoppingCart>(viewModel);
            var carts = (List<ProductShoppingCart>)Session["Carts"];
            var c = carts.Where(x => x.Id == cart.Id).FirstOrDefault();
            cart.BuyingQuantity = 1;
            if (c!=null) {
                c.BuyingQuantity++;
                c.TotalPrice = (c.BuyingQuantity * double.Parse((c.PromotionalPrice == "1" ? c.Price : c.PromotionalPrice).Replace(".",""))).ToString();
                c.TotalPrice = PriceHelper.NormalizePrice(c.TotalPrice);
                if (c.Price == "1")
                    c.TotalPrice = "Giá bán liên hệ";
            } else {
                cart.TotalPrice = cart.PromotionalPrice == "1" ? cart.Price : cart.PromotionalPrice;
                if (cart.Price == "1")
                    cart.TotalPrice = "Giá bán liên hệ";
                carts.Add(cart);
            }
            if(btnSubmit=="Mua ngay") {
                return RedirectToAction("PlaceOrder");
            }
            return RedirectToAction("Index");
        }
        public ActionResult ShowShoppingCart() {
            ShoppingCartViewModel viewModel = new ShoppingCartViewModel();
            viewModel.Carts = (List<ProductShoppingCart>)Session["Carts"];

            return View(viewModel);
        }
        public ActionResult PlaceOrder() {
            PlaceOrderViewModel vm = new PlaceOrderViewModel();
            vm.Carts = (List<ProductShoppingCart>)Session["Carts"];
            return View(vm);
        }
        
        public ActionResult CreateOrder(PlaceOrderViewModel viewModel) {
            if (!ModelState.IsValid) {
                return View("PlaceOrder", viewModel);
            }
            OrderStatusViewModel vm = Mapper.Map<PlaceOrderViewModel, OrderStatusViewModel>(viewModel);
            List<OrderDet> orderDets = new List<OrderDet>();
            Order ord = new Order();
            ord = Mapper.Map<PlaceOrderViewModel, Order>(viewModel);
            ord.OrderDets = new List<OrderDet>();
            vm.TotalPrice = "0";
            
            //Xu ly concurrency
            for(int i=0;i<viewModel.Carts.Count();i++){
                Product pr =  Mapper.Map<ProductShoppingCart, Product>(viewModel.Carts[i]);
                    Product pr1 = productService.GetById(viewModel.Carts[i].Id);
                if (productService.CheckConcurency(pr)) {
                    int qty = viewModel.Carts[i].BuyingQuantity;
                    viewModel.Carts[i] = Mapper.Map<Product, ProductShoppingCart>(pr1);
                    viewModel.Carts[i].BuyingQuantity = qty;
                    viewModel.Carts[i].TotalPrice = (viewModel.Carts[i].BuyingQuantity * double.Parse((viewModel.Carts[i].PromotionalPrice == "1" ? viewModel.Carts[i].Price : viewModel.Carts[i].PromotionalPrice).Replace(".", ""))).ToString();

                    ModelState.AddModelError("ConcurrencyError","Sản phẩm " + pr1.Name + " đã bị thay đổi thông tin, vui lòng xem lại sản phẩm trước khi mua");
                    return View("PlaceOrder", viewModel);
                }
                int qty1 = viewModel.Carts[i].BuyingQuantity;
                if (qty1 > pr1.Quantity) {
                    ModelState.AddModelError("QuantityError", "Đồng hồ " + pr1.Name + " không còn đủ hàng. Vui lòng chọn số lượng ít hơn.");
                    return View("PlaceOrder", viewModel);
                }
                pr = productService.GetById(viewModel.Carts[i].Id);

                vm.TotalPrice =(pr.PromotionalPrice==1?pr.Price * viewModel.Carts[i].BuyingQuantity:pr.PromotionalPrice*viewModel.Carts[i].BuyingQuantity).ToString();
                OrderDet det = new OrderDet();
                det.Quantity = viewModel.Carts[i].BuyingQuantity;
                det.ProductId = viewModel.Carts[i].Id;
                det.ProductPrice = pr.PromotionalPrice == 1 ? pr.Price : pr.PromotionalPrice;
                det.Order = ord;
                ord.OrderDets.Add(det);
                ord.TotalCost += det.ProductPrice * det.Quantity;
            }
            vm.TotalPrice = PriceHelper.NormalizePrice(vm.TotalPrice);
            orderService.AddOrder(ord);
            Session["Carts"] = null;
            return View("OrderStatus",vm);
        }

        public ActionResult AddComment(string anonymous, Comment cm,int productId) {
            if (anonymous != null) {
                cm.Email = "Anonymous";
            }
            else if (!System.Web.HttpContext.Current.User.Identity.IsAuthenticated) {
                return RedirectToAction("Login", "Account");
            }
            commentService.AddComment(cm);
            return RedirectToAction("Detail", new { id = productId });
        }
        // GET: Product
        public ActionResult Index(string filterName,int? brandId,int ?page,int ?gender, int?minCost, int?maxCost, int?strapId, int?categoryId)
        {
            IndexViewModel viewModel = new IndexViewModel();
            ApplicationDbContext context = new ApplicationDbContext();

            int pageSize = 12;
            int pageNumber = (page ?? 1);
            
            IQueryable<Product> query = context.Products;
            if (strapId != null) {
                query = productService.StrapFilter((int)strapId);
            }
            if (!string.IsNullOrWhiteSpace(filterName)) {
                query = productService.Filter(filterName);
            }
            if (brandId != null) {
                query = query.Where(x => x.BrandId == brandId);
            }
            if (gender != null) {
                query = query.Where(x => x.Gender == gender);
            }
            if (categoryId != null) {
                query = query.Where(x => x.CategoryId == categoryId);
            }
            if (minCost != null) {
                query = query.Where(x => ((x.PromotionalPrice == 1 ? x.Price : x.PromotionalPrice) >= minCost && (x.PromotionalPrice == 1 ? x.Price : x.PromotionalPrice) <= maxCost));
            }
            ViewBag.BrandId = brandId;
            ViewBag.Filter = filterName;
            ViewBag.Gender = gender;
            ViewBag.CategoryId = categoryId;
            ViewBag.StrapId = strapId;
            ViewBag.Min = minCost;
            ViewBag.Max = maxCost;
            viewModel.Products = Mapper.Map<IEnumerable<Product>, IList<ProductIndexViewModel>>(query.ToList()).ToPagedList(pageNumber,pageSize);
            
            return View(viewModel);
        }

        public ActionResult Detail(int id) {
            Product pr = productService.GetById(id);
            if(pr == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            return View(Mapper.Map<Product,ProductDetailViewModel>(pr));
        }
        public ActionResult ClearCarts(int? productId) {
            if (productId == null) { 
                Session["Carts"] = null;
            } else {
                var carts = (List<ProductShoppingCart>)Session["Carts"];
                carts.Remove(carts.First(x => x.Id == productId));
            }
            return RedirectToAction("ShowShoppingCart", "Product");
        }
    }
}