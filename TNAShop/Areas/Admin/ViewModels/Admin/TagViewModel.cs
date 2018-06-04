using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TNAShop.Domain;

namespace TNAShop.Areas.Admin.ViewModels.Admin {
    public class TagViewModel {
        public IList<Product> Products { set; get; }
        public IList<Tag> Tags  { set; get; }
    }
}