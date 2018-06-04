using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TNAShop.Domain;
using TNAShop.Infrastructure;

namespace TNAShop.Application {
    public class PriceFilteringService {
        public IEnumerable<PriceFiltering> Get() {
            return new PriceFiltering(new GenericRepository<PriceFiltering>(new Data.ApplicationDbContext())).Get();
        }
    }
}