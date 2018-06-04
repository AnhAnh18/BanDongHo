using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TNAShop.Domain {
    public class PriceFiltering {
        IGenericRepository<PriceFiltering> repos;

        public PriceFiltering(IGenericRepository<PriceFiltering> repos) {
            this.repos = repos;
        }
        public PriceFiltering() {

        }
        [Key,Column(Order=1)]
        [Display(Name = "Min")]
        public double Min { set; get; }
        [Key,Column(Order=2)]
        [Display(Name = "Max")]
        public double Max { set; get; }
        [Display(Name = "Hiển thị")]
        public string Name { set; get; }

        public IEnumerable<PriceFiltering> Get() {
            return repos.Get();
        }
    }
}