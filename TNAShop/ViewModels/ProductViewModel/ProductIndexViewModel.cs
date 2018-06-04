using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TNAShop.ViewModels.ProductViewModel {
    public class ProductIndexViewModel {
        public int Id { set; get; }
        public int BrandId { set; get; }
        public string Name { set; get; }
        public string Code { set; get; }
        public string Image { set; get; }
        public string Price { set; get; }
        public int Gender { set; get; }
        public string PromotionalPrice { set; get; }
    }
}