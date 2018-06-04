using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TNAShop.Application;
using TNAShop.Domain;
using TNAShop.Filters;
using TNAShop.ViewModels;
using TNAShop.ViewModels.HomeViewModel;
using TNAShop.ViewModels.ProductViewModel;

namespace TNAShop.Controllers {
    [HeaderFooterFilter]
    public class HomeController : Controller {
        ProductService service;
        public HomeController() {
            service = new ProductService();
        }
        public ActionResult Index() {
            HomeIndexViewModel viewModel = new HomeIndexViewModel();
            viewModel.Products = Mapper.Map<IEnumerable<Product>, IList<ProductIndexViewModel>>(service.GetProducts().Where(x => x.Gender == 1).Take(6));
            viewModel.FemaleProducts = Mapper.Map<IEnumerable<Product>,IList<ProductIndexViewModel>>(service.GetProducts().Where(x=>x.Gender==2).Take(6));
            return View(viewModel);
        }
        
        public ActionResult About() {
            ViewBag.Message = "Your application description page.";

            return View(new BaseViewModel());
        }

        public ActionResult Contact() {
            ViewBag.Message = "Your contact page.";

            return View(new BaseViewModel());
        }
    }
}