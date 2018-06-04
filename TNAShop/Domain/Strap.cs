using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TNAShop.Domain {
    public class Strap {
        IGenericRepository<Strap> repos;
        public Strap() {

        }
        public Strap(IGenericRepository<Strap> repos) {
            this.repos = repos;
        }

        public int Id { set; get; }
        [Display(Name = "Tên nhãn hiệu")]
        public string StrapName { set; get; }
        public IEnumerable<Strap> Get() {
            return repos.Get();
        }
    }
}