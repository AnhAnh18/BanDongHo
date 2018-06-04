using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace TNAShop.Domain {
    public class Brand {
        public int Id { set; get; }
        [Display(Name="Tên nhãn hiệu")]
        public string Name { set; get; }
        [Display(Name = "Mô tả nhãn hiệu")]
        public string HtmlDescription { set; get; }
        [Display(Name = "Đường dẫn ảnh hiển thị")]
        public string Image { set; get; }
        IGenericRepository<Brand> repos;
        public Brand() {
            
        }

        public Brand(IGenericRepository<Brand> repos) {
            this.repos = repos;
        }

        public IEnumerable<Brand> Get(Expression<Func<Brand, bool>> filter = null,
         Func<IQueryable<Brand>, IOrderedQueryable<Brand>> orderBy = null,
            string includeProperties = "") {
            return repos.Get(filter, orderBy, includeProperties);
        }
    }
}