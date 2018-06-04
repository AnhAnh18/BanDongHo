using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Data.Entity;
using TNAShop.Data;
using TNAShop.ViewModels.ProductViewModel;
using AutoMapper;

namespace TNAShop.Domain {
    public class Product {
        ApplicationDbContext context = new ApplicationDbContext();
        #region Properties
        [Key]
        public int Id { set; get; }
        [Display(Name = "Tên đồng hồ")]
        public string Name { set; get; }
        [Display(Name = "Mã sản phẩm")]
        public string Code { set; get; }
        [Display(Name = "Giá niêm yết")]
        public double Price { set; get; }
        [Display(Name = "Giá khuyến mại")]
        public double PromotionalPrice { set; get; }
        [Display(Name = "Mô tả")]
        public string Description { set; get; }
        [Display(Name = "Đã bao gồm thuế VAT")]
        public bool IncludedVAT { set; get; }
        [Display(Name = "Trạng thái")]
        public bool Status { set; get; }
        [Display(Name = "Bảo hàng")]
        public int Warranty { set; get; }
        [Display(Name = "Đánh giá")]
        public float Rating { set; get; }
        [Display(Name = "Giới tính")]
        public int Gender { set; get; }
        [Display(Name = "Kích thước")]
        public double CaseSize { set; get; }
        [Display(Name = "Ảnh hiển thị")]
        public string Image { set; get; }
        public string MoreImages { set; get; }
        [Display(Name="Số lượng")]
        public int Quantity { set; get; }

        [Display(Name = "Thương hiệu")]
        public int BrandId { set; get; }
        public ICollection<ProductStrap> ProductStrap { set; get; }
        public ICollection<Strap> Straps { set; get; }
        public ICollection<Comment> Comments { set; get; }
        [Display(Name = "Loại đồng hồ")]
        public int CategoryId { set; get; }

        [Timestamp]
        public byte[] Version { set; get; }

        //Navigation property
        public Category Category { set; get; }
        public Brand Brand { set; get; }

        #endregion
        IGenericRepository<Product> repos;
        IGenericRepository<Tag> tagRepos;
        public Product() {

        }

        public Product(IGenericRepository<Product> repos) {
            this.repos = repos;
        }
        public IEnumerable<Product> Get(Expression<Func<Product, bool>> filter = null,
            Func<IQueryable<Product>, IOrderedQueryable<Product>> orderBy = null,
            string includeProperties = "") {
            return repos.Get(filter, orderBy, includeProperties);
        }

        public Product GetById(int id) {
            return context.Products.Where(x => x.Id == id).Include(x => x.Brand)
                .Include(x => x.Category)
                .Include(x => x.ProductStrap.Select(y => y.Strap))
                .Include(x => x.Comments).FirstOrDefault();
            ;
        }
        
        public IQueryable<Product> Filter(string filter) {
            IQueryable<Product> query = from a in context.Products
                                        join
             b in context.ProductTags
             on a.Id equals b.ProductId
                                        join
             c in context.Tags on
             b.TagId equals c.TagId
                                        where c.TagName.Contains(filter)

                                        select a;
            query = query.Union(context.Products.Where(x => x.Name.Contains(filter)));
            return query;
        }
        
        public IQueryable<Product> StrapFilter(int id) {
            IQueryable<Product> query = from a in context.Products
                                        join
             b in context.ProductStrap
             on a.Id equals b.ProductId
                                        where b.StrapId == id
                                        select a;
            return query;
        }
        public bool CheckConcurency(Product pr) {
            return CompareTwoBytesArray(context.Products.Where(x=>x.Id == pr.Id).FirstOrDefault().Version,pr.Version);
        }
        public bool CompareTwoBytesArray(byte[] arr1, byte[] arr2) {
            if (arr1.Length != arr2.Length) {
                return true;
            }
            for(int i = 0; i < arr1.Length; i++) {
                if (arr1[i] != arr2[i])
                    return true;
            }
            return false;
        }
    }
}