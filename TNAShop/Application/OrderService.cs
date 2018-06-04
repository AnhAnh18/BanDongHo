using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TNAShop.Domain;
using TNAShop.Infrastructure;

namespace TNAShop.Application {
    public class OrderService {
        public void AddOrder(Order order) {
            new Order(new OrderRepository()).AddOrder(order);
        }
    }
}