using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TNAShop.Domain;

namespace TNAShop.ViewModels {
    public class BaseViewModel {
        public IEnumerable<Brand> Brands { set; get; }
        public IEnumerable<Category> Categories { set; get; }
        public IEnumerable<Strap> Straps { set; get; }
        public IEnumerable<PriceFiltering> PriceFilterings { set; get; }
    }
}