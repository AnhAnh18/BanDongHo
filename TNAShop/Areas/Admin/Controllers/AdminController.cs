using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using TNAShop.Areas.Admin.Application;
using TNAShop.Areas.Admin.ViewModels.Admin;
using TNAShop.Domain;
using TNAShop.Filters;

namespace TNAShop.Areas.Admin.Controllers
{
    [AdminFilter]
    public class AdminController : Controller
    {
        UserService service;
        // GET: Admin/Admin
        public AdminController() {
            service = new UserService();
        }
        public ActionResult Index()
        {
            AdminIndexViewModel viewModel = new AdminIndexViewModel();
            viewModel.NewClients = service.GetUsersCount();
            viewModel.NewComment = service.GetNewCommentsCount();
            viewModel.OrderAmt = service.GetTotalOrders();
            viewModel.NewInvoices = service.GetNewInvoice();
            viewModel.TrendingProducts = service.GetTrendingProducts();
            //viewModel.OnlineUser = Membership.GetNumberOfUsersOnline();
            return View(viewModel);
        }
        public ActionResult ViewNewComment() {
            return View(service.GetNewComments());
        }
        public ActionResult RemoveComment(int id) {
            service.RemoveComment(id);
            return RedirectToAction("ViewNewComment");
        }
        public ActionResult ViewOrders() {
            return View(new OrderService().GetOrders());
        }
        public ActionResult OrderDet(int orderId) {
            return View(new OrderService().FindOrder(orderId));
        }
    }
}