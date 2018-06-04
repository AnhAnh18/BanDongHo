using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TNAShop.Data;
using TNAShop.Domain;
using TNAShop.Infrastructure;

namespace TNAShop.Application {
    public class StrapService {
        public IEnumerable<Strap> Get() {
            return new Strap(new GenericRepository<Strap>(new ApplicationDbContext())).Get();
        }
    }
}