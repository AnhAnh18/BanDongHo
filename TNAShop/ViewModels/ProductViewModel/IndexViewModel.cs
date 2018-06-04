using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TNAShop.Domain;

namespace TNAShop.ViewModels.ProductViewModel {
    public class IndexViewModel:BaseViewModel {
        public IPagedList<ProductIndexViewModel> Products { set; get; }
    }
}