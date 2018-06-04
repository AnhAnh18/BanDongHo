using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TNAShop.ViewModels.ProductViewModel { 
    public class PlaceOrderViewModel:BaseViewModel {
        public IList<ProductShoppingCart> Carts { set; get; }
        [Required(ErrorMessage ="Tên khách hàng không được để trống")]
        public string CustomerName { set; get; }
        [Required(ErrorMessage = "Email không được để trống")]
        public string Email { set; get; }
        [Required(ErrorMessage = "Số điện thoại không được để trống")]
        public string PhoneNumber { set; get; }
        [Required(ErrorMessage = "Địa chỉ không được để trống")]
        public string Address { set; get; }
        public string TransportionType { set; get; }
        public string PaymentType { set; get; }
        public string Note { set; get; }
    }
}