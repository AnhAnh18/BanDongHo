using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TNAShop.Domain {
    public class Tag {
        [Key]
        public int TagId { set; get; }
        [Display(Name = "Tên thẻ")]
        public string TagName { set; get; }
    }
}