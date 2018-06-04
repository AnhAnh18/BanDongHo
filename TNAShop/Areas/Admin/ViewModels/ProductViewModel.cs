using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TNAShop.Areas.Admin.ViewModels {
    public class ProductViewModel {
        public int Id { set; get; }
        public string Name { set; get; }
        public string Image { set; get; }
        public double Price { set; get; }
        public double PromotionalPrice { set; get; }
        public int SellingAmt { set; get; }
    }
}