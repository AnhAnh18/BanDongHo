    using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TNAShop.Domain {
    public class Category {
        IGenericRepository<Category> repos;
        public Category() { 

        }
        public Category(IGenericRepository<Category> repos) {
            this.repos = repos;
        }

        public int CategoryId { set; get; }
        [Display(Name = "Loại đồng hồ")]
        public string CategoryName { set; get; }
        [Display(Name = "Parent")]
        public int ParentId { set; get; }
        public IEnumerable<Category> Get() {
            return repos.Get();
        }
        
    }
}