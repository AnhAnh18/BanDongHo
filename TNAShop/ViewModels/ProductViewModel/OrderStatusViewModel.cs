using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TNAShop.ViewModels.ProductViewModel {
    public class OrderStatusViewModel:BaseViewModel {
        public string CustomerName { set; get; }
        public string Email { set; get; }
        public string PhoneNumber { set; get; }
        public string Address { set; get; }
        public string TransportionType { set; get; }
        public string PaymentType { set; get; }
        public string Note { set; get; }
        public string TotalPrice { set; get; }
    }
}