using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TNAShop.Domain;

namespace TNAShop.Areas.Admin.ViewModels.Admin {
    public class AddTagViewModel {
        public Product Product { set; get; }
        public int TagId { set; get; }
    }
}