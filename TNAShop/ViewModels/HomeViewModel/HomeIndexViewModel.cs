using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TNAShop.ViewModels.ProductViewModel;

namespace TNAShop.ViewModels.HomeViewModel {
    public class HomeIndexViewModel :BaseViewModel {
        public IList<ProductIndexViewModel> Products { set; get; }
        public IList<ProductIndexViewModel> FemaleProducts { set; get; }
    }
}