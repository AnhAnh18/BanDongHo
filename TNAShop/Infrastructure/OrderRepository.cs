using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TNAShop.Data;
using TNAShop.Domain;

namespace TNAShop.Infrastructure {
    public class OrderRepository : IOrderRepository {
        public void AddOrder(Order order) {
            ApplicationDbContext context = new ApplicationDbContext();
            context.Orders.Add(order);
            context.SaveChanges();
        }
    }
}