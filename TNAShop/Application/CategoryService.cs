using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TNAShop.Data;
using TNAShop.Domain;
using TNAShop.Infrastructure;

namespace TNAShop.Application {
    public class CategoryService {
        public IEnumerable<Category> Get() {
            return new Category(new GenericRepository<Category>(new ApplicationDbContext())).Get();
        }
    }
}