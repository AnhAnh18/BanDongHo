using System;
using System.Collections.Generic;
using System.Data.Entity.SqlServer;
using System.Linq;
using System.Web;
using TNAShop.Data;
using TNAShop.Domain;
using System.Data.Entity;
using TNAShop.Areas.Admin.ViewModels;
using TNAShop.Helpers;

namespace TNAShop.Areas.Admin.Application {
    public class UserService {
        private ApplicationDbContext context;

        public UserService() {
            context = new ApplicationDbContext();
        }
        public int GetUsersCount() {
            return context.Users.Count();
        }
        public int GetTotalOrders() {
            return context.Orders.Count();
        }
        public int GetNewInvoice() {
            return context.Orders.Where(x => (SqlFunctions.DateDiff("dd", x.OrderDate, DateTime.Now) <= 2)).Count();
        }
        public int GetNewCommentsCount() {
            return context.Comments.Where(x=>SqlFunctions.DateDiff("dd",x.AddedDate,DateTime.Now)<=2).Count();
        }
        public IList<Comment> GetNewComments() {
            return context.Comments.Where(x => SqlFunctions.DateDiff("dd", x.AddedDate, DateTime.Now) <= 2).ToList();
        }
        public void RemoveComment(int id) {
            context.Comments.Remove(context.Comments.Find(id));
            context.SaveChanges();
        }
        public IList<ProductViewModel> GetTrendingProducts() {
            IQueryable<ProductViewModel> query;
            query = from a1 in (from a in context.Products
                                join b in context.OrderDet
                                on a.Id equals b.ProductId
                                group b by a.Id into d
                                select new ProductViewModel {
                                    Id = d.Key,
                                    Name="",
                                    Price=0,
                                    PromotionalPrice=0,
                                    Image="",
                                    SellingAmt = d.Sum(x => x.Quantity) 
                                }
                    )
                    join b1 in context.Products
                    on a1.Id equals b1.Id
                    select new ProductViewModel {
                        Id = a1.Id,
                        Name = b1.Name,
                        Price = b1.Price,
                        PromotionalPrice = b1.PromotionalPrice,
                        Image = b1.Image,
                        SellingAmt = a1.SellingAmt
                    };
            //query = from a in query
            //        join b in context.Products
            //        on a.Id equals b.Id
            //        select new ProductViewModel {
            //            Id = a.Id,
            //            Name = b.Name,
            //            Price = b.Price,
            //            PromotionalPrice = b.PromotionalPrice,
            //            Image = b.Image,
            //            SellingAmt = a.SellingAmt
            //        };
            query = query.OrderByDescending(x => x.SellingAmt).Take(3);
            return query.ToList();
        }
    }
}