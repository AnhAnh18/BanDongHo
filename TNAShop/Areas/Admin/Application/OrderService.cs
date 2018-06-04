using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Data.Entity;
using TNAShop.Data;
using TNAShop.ViewModels.ProductViewModel;
using AutoMapper;
using TNAShop.Domain;

namespace TNAShop.Areas.Admin.Application {
    public class OrderService {
        ApplicationDbContext context;
        public OrderService() {
            context = new ApplicationDbContext();
        }
        public IList<Order> GetOrders() {
            return context.Orders.ToList();
        }
        public Order FindOrder(int id) {
            return context.Orders.Where(x=>x.Id==id).Include(x=>x.OrderDets.Select(b=>b.Product)).FirstOrDefault();
        }
    }
}