using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.InteropServices;
using System.Web;
using TNAShop.Data;
using TNAShop.Domain;
using TNAShop.Infrastructure;
using TNAShop.Models;
using TNAShop.ViewModels.ProductViewModel;

namespace TNAShop.Application {
    public class ProductService {
        Product pr;
        public ProductService() {
            pr = new Product(new GenericRepository<Product>(new ApplicationDbContext()));
        }
        public IEnumerable<Product> GetProducts() {
            return pr.Get();
        }
        public IEnumerable<Product> Where(Expression<Func<Product,bool>> pre) {
            return pr.Get(pre);
        }
        public Product GetById(int id) {
            return pr.GetById(id);
        }
        public IQueryable<Product> Filter(string filterName) {
            return pr.Filter(filterName);
        }
        public IQueryable<Product> StrapFilter(int id) {
            return pr.StrapFilter(id);
        }
        public bool CheckConcurency(Product pr) {
            return pr.CheckConcurency(pr);
        }
    }
}