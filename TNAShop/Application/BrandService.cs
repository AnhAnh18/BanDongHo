using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TNAShop.Data;
using TNAShop.Domain;
using TNAShop.Infrastructure;
using TNAShop.Models;

namespace TNAShop.Application {
    public class BrandService {
        Brand brand = new Brand(new GenericRepository<Brand>(new ApplicationDbContext()));
        
        public IEnumerable<Brand> GetBrands() {
            return brand.Get();
        }
    }
}