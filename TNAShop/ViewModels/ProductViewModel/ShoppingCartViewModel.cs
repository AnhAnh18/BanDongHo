using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TNAShop.ViewModels.ProductViewModel {
    public class ShoppingCartViewModel:BaseViewModel {
        public IList<ProductShoppingCart> Carts { set; get; }
    }
}