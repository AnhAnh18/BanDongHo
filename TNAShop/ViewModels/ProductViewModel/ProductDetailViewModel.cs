using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TNAShop.Domain;

namespace TNAShop.ViewModels.ProductViewModel {
    public class ProductDetailViewModel :BaseViewModel {
        public int Id { set; get; }
        public string Name { set; get; }
        public string Code { set; get; }

        public string PriceString { set; get; }
        public string Price { set; get; }
        public string PromotionalPrice { set; get; }
        public string Save { set; get; }
        public string Description { set; get; }
        public bool IncludedVAT { set; get; }
        public string Status { set; get; }
        public string Warranty { set; get; }
        public float Rating { set; get; }
        public string Gender { set; get; }
        public double CaseSize { set; get; }
        public string Image { set; get; }
        public string MoreImages { set; get; }
        public string Brand { set; get; }
        public string Strap { set; get; }
        public string Category { set; get; }
        public byte[] Version { set; get; }

        public ICollection<Comment> Comments { set; get; }
    }
}