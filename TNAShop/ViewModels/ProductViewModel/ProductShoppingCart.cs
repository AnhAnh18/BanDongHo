using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TNAShop.ViewModels.ProductViewModel {
    public class ProductShoppingCart {
        public int Id{ set; get; }
        public string Name { set; get; }
        public string Image { set; get; }
        public string Price { set; get; }
        public string PromotionalPrice { set; get; }
        public string Save { set; get; }
        public int BuyingQuantity { set; get; }
        public byte[] Version { set; get; }
        public string TotalPrice { set; get; }
    }
}