using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TNAShop.Data;
using TNAShop.Domain;

namespace TNAShop.Areas.Admin.ViewModels.Admin {
    public class AdminIndexViewModel {
        public int NewClients { set; get; }
        public int NewInvoices { set; get; }
        public int NewComment { set; get; }
        public int OrderAmt { set; get; }
        public IList<ProductViewModel> TrendingProducts { set; get; }
        public int OnlineUser { set; get; }
    }
}