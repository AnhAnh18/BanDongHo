using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TNAShop.Domain {
    public class ProductStrap {
        [Key,Column(Order=1)]
        public int StrapId { set; get; }
        [Key,Column(Order=2)]
        public int ProductId { set; get; }

        public Product Product { set; get; }
        public Strap Strap { set; get; }
    }
}