using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TNAShop.Domain {
    public class OrderDet {
        [Key,Column(Order=1)]
        public int OrderId { set; get; }
        [Key,Column(Order=2)]
        public int ProductId { set; get; }
        [Display(Name = "Giá sản phẩm")]
        public double ProductPrice { set; get; }
        [Display(Name = "Số lượng")]
        public int Quantity { set; get; }
        
        public Order Order { set; get; }
        public Product Product { set; get; }
    }
}