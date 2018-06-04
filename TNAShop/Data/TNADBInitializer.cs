using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using TNAShop.Domain;
using TNAShop.Models;

namespace TNAShop.Data {
    public class TNADBInitializer : CreateDatabaseIfNotExists<ApplicationDbContext> {
        protected override void Seed(ApplicationDbContext context) {
            context.Categories.Add(new Category() { CategoryName = "Đồng hồ cơ" });
            context.Categories.Add(new Category() { CategoryName = "Đồng hồ điện tử" });
            context.Categories.Add(new Category() { CategoryName = "Đồng hồ kim cương" });
            context.Categories.Add(new Category() { CategoryName = "Phiên bản đặc biệt" });
            context.Categories.Add(new Category() { CategoryName = "Eco-Drive" });

            context.SaveChanges();

            context.PriceFilterings.Add(new PriceFiltering { Min = 2000000, Max = 5000000, Name = "Từ 2 triệu - 5 triệu" });
            context.PriceFilterings.Add(new PriceFiltering { Min = 5000000, Max = 10000000, Name = "Từ 5 triệu - 10 triệu" });
            context.PriceFilterings.Add(new PriceFiltering { Min = 10000000, Max = 20000000, Name = "Từ 10 triệu - 20 triệu" });
            context.PriceFilterings.Add(new PriceFiltering { Min = 20000000, Max = 50000000, Name = "Từ 20 triệu - 50 triệu" });
            context.PriceFilterings.Add(new PriceFiltering { Min = 50000000, Max = 99000000, Name = "Từ 50 triệu - 99 triệu" });
            context.PriceFilterings.Add(new PriceFiltering { Min = 99000000, Max = 2000000000, Name = "Trên 99 triệu" });

            context.Straps.Add(new Strap() { StrapName = "Dây da" });
            context.Straps.Add(new Strap() { StrapName = "Thép không gỉ 316L" });
            context.Straps.Add(new Strap() { StrapName = "Ceramic" });
            context.Straps.Add(new Strap() { StrapName = "Mạ vàng hồng" });
            context.Straps.Add(new Strap() { StrapName = "Titanium" });

            context.SaveChanges();

            context.Tags.Add(new Tag { TagName = "Đồng hồ đẹp" });
            context.Tags.Add(new Tag { TagName = "Đồng hồ Nam" });
            context.Tags.Add(new Tag { TagName = "Đồng hồ Nữ" });
            context.Tags.Add(new Tag { TagName = "Đồng hồ hiếm" });
            context.Tags.Add(new Tag { TagName = "Giảm giá" });
            context.Tags.Add(new Tag { TagName = "Đồng hồ 99%" });

            context.SaveChanges();

            context.Brands.Add(new Brand() { Name = "Alpina", Image = "~/Content/Images/Brand/Alpina.png" });
            context.Brands.Add(new Brand() { Name = "Bering", Image = "~/Content/Images/Brand/Bering.png" });
            context.Brands.Add(new Brand() { Name = "Breitling", Image = "~/Content/Images/Brand/Breitling.png" });
            context.Brands.Add(new Brand() { Name = "CalvinKlein", Image = "~/Content/Images/Brand/Calvin-Klein.png" });
            context.Brands.Add(new Brand() { Name = "Candino", Image = "~/Content/Images/Brand/Candino.png" });
            context.Brands.Add(new Brand() { Name = "Century", Image = "~/Content/Images/Brand/Century.png" });
            context.Brands.Add(new Brand() { Name = "Chronoswiss", Image = "~/Content/Images/Brand/Chronoswiss.png" });
            context.Brands.Add(new Brand() { Name = "Citizen", Image = "~/Content/Images/Brand/Citizen.png" });
            context.Brands.Add(new Brand() { Name = "D&G", Image = "~/Content/Images/Brand/DAG.png" });
            context.Brands.Add(new Brand() { Name = "Ernest-Borel", Image = "~/Content/Images/Brand/Ernest-Borel.png" });
            context.Brands.Add(new Brand() { Name = "Festina", Image = "~/Content/Images/Brand/Festina.png" });
            context.Brands.Add(new Brand() { Name = "Francisdelon", Image = "~/Content/Images/Brand/Francisdelon.png" });
            context.Brands.Add(new Brand() { Name = "Freelook", Image = "~/Content/Images/Brand/Freelook.png" });
            context.Brands.Add(new Brand() { Name = "Hermle", Image = "~/Content/Images/Brand/Hermle.png" });
            context.Brands.Add(new Brand() { Name = "Longines", Image = "~/Content/Images/Brand/longines.png" });

            context.SaveChanges();
            context.Products.Add(new Product { Name = "Đồng hồ Breitling Navitimer 01 46mm Southeast Asia AB01281A/BF19/4100", Code = "AB01281A/BF19/4100", Image = "~/Content/Images/Products/new_1503395212.png", PromotionalPrice = 179676000, Price = 199640000, BrandId = 3, CategoryId = 1, Status = true, Warranty = 60, CaseSize = 43, Gender = 1, IncludedVAT = true });
            ImagePaths ips = new ImagePaths();
            ips.Images.Add("~/Content/Images/Products/ab012012-bb01-447a-1.jpg");
            ips.Images.Add("~/Content/Images/Products/$_57.jpg");
            ips.Images.Add("~/Content/Images/Products/JFbiao01575 (7).jpg");

            context.Products.Add(new Product { Name = "Đồng hồ Breitling Navitimer 01 AB012012/BB01/447A", Code = "AB012012/BB01/447A", Image = "~/Content/Images/Products/3-ab012012-bb01-447a_1503395271.png", PromotionalPrice = 226872000, Price = 252080000, BrandId = 3, CategoryId = 1, Status = true, Warranty = 60, CaseSize = 43, Gender = 1, IncludedVAT = true, MoreImages = JsonConvert.SerializeObject(ips) });
            context.Products.Add(new Product { Name = "Đồng hồ Breitling Chronomat 44 Black Dial Mens AB011012/B967/375A", Code = "AB011012/B967/375A", Image = "~/Content/Images/Products/2ab011012-b967-375a_1503395306.png", PromotionalPrice = 226458000, Price = 251620000, BrandId = 3, CategoryId = 1, Status = true, Warranty = 60, CaseSize = 44, Gender = 1, IncludedVAT = true });
            context.Products.Add(new Product { Name = "Đồng hồ Breitling Chronomat 38 W1331012/BD92/385A", Code = "W1331012/BD92/385A", Image = "~/Content/Images/Products/1w1331012-bd92-385a_1503395340.png", PromotionalPrice = 1, Price = 197340000, BrandId = 3, CategoryId = 1, Status = true, Warranty = 24, CaseSize = 38, Gender = 2, IncludedVAT = true });
            context.Products.Add(new Product { Name = "Đồng hồ Breitling Galactic 36 W7433012/BE08/376A", Code = "W7433012/BE08/376A", Image = "~/Content/Images/Products/16-w7433012-be08-376a_1503395701.png", PromotionalPrice = 1, Price = 131790000, BrandId = 3, CategoryId = 1, Status = true, Warranty = 24, CaseSize = 36, Gender = 2, IncludedVAT = true });

            context.ProductStrap.Add(new ProductStrap() { ProductId = 1, StrapId = 1 });
            context.ProductStrap.Add(new ProductStrap() { ProductId = 2, StrapId = 2 });
            context.ProductStrap.Add(new ProductStrap() { ProductId = 3, StrapId = 2 });
            context.ProductStrap.Add(new ProductStrap() { ProductId = 4, StrapId = 2 });
            context.ProductStrap.Add(new ProductStrap() { ProductId = 5, StrapId = 2 });

            context.Products.Add(new Product { Name = "Đồng hồ Alpina Heritage Pilot Chronograph AL-860S4H5", PromotionalPrice = 78651000, Price = 87390000, BrandId = 1, Code = "AL-860S4H5", Status = true, Warranty = 24, CaseSize = 41.5, CategoryId = 1, Gender = 1, IncludedVAT = true, Image = "~/Content/Images/Products/AL-860S4H5.png" });
            context.Products.Add(new Product { Name = "Đồng hồ Alpina Startimer Pilot AL-860GB4S6", PromotionalPrice = 68742000, Price = 76380000, BrandId = 1, Code = "AL-860GB4S6", Status = true, Warranty = 24, CaseSize = 44, CategoryId = 1, Gender = 1, IncludedVAT = true, Image = "~/Content/Images/Products/AL-860GB4S6.png" });

            ips = new ImagePaths();
            ips.Images.Add("~/Content/Images/Products/AL-860B5AQ6_1.jpg");
            ips.Images.Add("~/Content/Images/Products/AL-860B5AQ6_2.jpg");
            ips.Images.Add("~/Content/Images/Products/AL-860B5AQ6_3.jpg");
            context.Products.Add(new Product { Name = "Đồng hồ Alpina Alpiner 4 Chronograph AL-860B5AQ6B", Code = "AL-860B5AQ6B", Image = "~/Content/Images/Products/AL-860B5AQ6B.png", PromotionalPrice = 68004000, Price = 75560000, BrandId = 1, CategoryId = 1, Status = true, Warranty = 24, CaseSize = 44, Gender = 1, IncludedVAT = true, MoreImages = JsonConvert.SerializeObject(ips) });
            

            context.Products.Add(new Product { Name = "Đồng hồ Alpina Alpiner Chronograph AL-860AD5AQ6", Code = "AL-860AD5AQ6", Image = "~/Content/Images/Products/AL-860AD5AQ6.png", PromotionalPrice = 68004000, Price = 75560000, BrandId = 1, CategoryId = 1, Status = true, Warranty = 24, CaseSize = 44, Gender = 1, IncludedVAT = true });
            context.Products.Add(new Product { Name = "Đồng hồ Alpina Alpiner Automatic Chronograph AL-750N4E6B", Code = "AL-750N4E6B", Image = "~/Content/Images/Products/AL-750N4E6B.png", PromotionalPrice = 52866000, Price = 58740000, BrandId = 1, CategoryId = 1, Status = true, Warranty = 24, CaseSize = 44, Gender = 1, IncludedVAT = true });
            context.Products.Add(new Product { Name = "Đồng hồ Alpina Seastrong Diver 300 AL-725LB4V26B", Code = "AL-725LB4V26B", Image = "~/Content/Images/Products/AL-725LB4V26B.png", PromotionalPrice = 55386000, Price = 61540000, BrandId = 1, CategoryId = 1, Status = true, Warranty = 24, CaseSize = 44, Gender = 1, IncludedVAT = true });
            context.Products.Add(new Product { Name = "Đồng hồ Alpina AL-525VG4E6", Code = "AL-525VG4E6", Image = "~/Content/Images/Products/AL-525VG4E6.png", PromotionalPrice = 29844000, Price = 33160000, BrandId = 1, CategoryId = 1, Status = true, Warranty = 24, CaseSize = 41.5, Gender = 1, IncludedVAT = true });
            context.Products.Add(new Product { Name = "Đồng hồ Alpina Alpiner 4 Manufacture Flyback Chronograph AL-760BS5AQ6", Code = "AL-760BS5AQ6", Image = "~/Content/Images/Products/AL-760BS5AQ6.png", PromotionalPrice = 98280000, Price = 109200000, BrandId = 1, CategoryId = 1, Status = true, Warranty = 24, CaseSize = 41.5, Gender = 1, IncludedVAT = true });
            context.Products.Add(new Product { Name = "Đồng hồ Alpina Startimer Pilot AL-725B4S6", Code = "AL-725B4S6", Image = "~/Content/Images/Products/AL-725B4S6.png", PromotionalPrice = 50463000, Price = 56070000, BrandId = 1, CategoryId = 1, Status = true, Warranty = 24, CaseSize = 41.5, Gender = 1, IncludedVAT = true });
            context.Products.Add(new Product { Name = "Đồng hồ Alpina Alpiner 4 GMT AL-550GRN5AQ6", Code = "AL-550GRN5AQ6", Image = "~/Content/Images/Products/AL-550GRN5AQ6.png", PromotionalPrice = 42156000, Price = 46840000, BrandId = 1, CategoryId = 1, Status = true, Warranty = 24, CaseSize = 41.5, Gender = 1, IncludedVAT = true });
            context.Products.Add(new Product { Name = "Đồng hồ Alpina AL-525STD2CD3B", Code = "AL-525STD2CD3B", Image = "~/Content/Images/Products/AL-525STD2CD3B.png", PromotionalPrice = 1, Price = 86430000, BrandId = 1, CategoryId = 1, Status = true, Warranty = 24, CaseSize = 34, Gender = 2, IncludedVAT = true });

            //1 1 2 1 2 2 1 1 1 1 2
            context.ProductStrap.Add(new ProductStrap() { ProductId = 6, StrapId = 1 });
            context.ProductStrap.Add(new ProductStrap() { ProductId = 7, StrapId = 1 });
            context.ProductStrap.Add(new ProductStrap() { ProductId = 8, StrapId = 2 });
            context.ProductStrap.Add(new ProductStrap() { ProductId = 9, StrapId = 1 });
            context.ProductStrap.Add(new ProductStrap() { ProductId = 10, StrapId = 2 });
            context.ProductStrap.Add(new ProductStrap() { ProductId = 11, StrapId = 2 });
            context.ProductStrap.Add(new ProductStrap() { ProductId = 12, StrapId = 1 });
            context.ProductStrap.Add(new ProductStrap() { ProductId = 13, StrapId = 1 });
            context.ProductStrap.Add(new ProductStrap() { ProductId = 14, StrapId = 1 });
            context.ProductStrap.Add(new ProductStrap() { ProductId = 15, StrapId = 1 });
            context.ProductStrap.Add(new ProductStrap() { ProductId = 16, StrapId = 2 });

            // 3 3 2 3 2
            context.Products.Add(new Product { Name = "Đồng hồ Bering 32426-789", Code = "32426-789", Image = "~/Content/Images/Products/32426-789.png", PromotionalPrice = 1, Price = 1, BrandId = 2, CategoryId = 2, Status = true, Warranty = 36, CaseSize = 26, Gender = 2, IncludedVAT = true });
            context.Products.Add(new Product { Name = "Đồng hồ Bering 32230-442", Code = "32230-442", Image = "~/Content/Images/Products/32230-442.png", PromotionalPrice = 1, Price = 4330000, BrandId = 2, CategoryId = 2, Status = true, Warranty = 36, CaseSize = 26, Gender = 2, IncludedVAT = true });
            context.Products.Add(new Product { Name = "Đồng hồ Bering 32230-262", Code = "32230-262", Image = "~/Content/Images/Products/32230-262.png", PromotionalPrice = 1, Price = 6490000, BrandId = 2, CategoryId = 2, Status = true, Warranty = 36, CaseSize = 30, Gender = 2, IncludedVAT = true });
            context.Products.Add(new Product { Name = "Đồng hồ Bering 30226-751", Code = "30226-751", Image = "~/Content/Images/Products/30226-751.png", PromotionalPrice = 1, Price = 8350000, CategoryId = 2, Status = true, Warranty = 36, BrandId = 2, CaseSize = 26, Gender = 2, IncludedVAT = true });
            context.Products.Add(new Product { Name = "Đồng hồ Bering 13139-002", Code = "13139-002", Image = "~/Content/Images/Products/13139-002.png", PromotionalPrice = 3753000, Price = 4170000, BrandId = 2, CategoryId = 2, Status = true, Warranty = 36, CaseSize = 39, Gender = 2, IncludedVAT = true });

            context.ProductStrap.Add(new ProductStrap() { ProductId = 17, StrapId = 3 });
            context.ProductStrap.Add(new ProductStrap() { ProductId = 18, StrapId = 3 });
            context.ProductStrap.Add(new ProductStrap() { ProductId = 19, StrapId = 2 });
            context.ProductStrap.Add(new ProductStrap() { ProductId = 20, StrapId = 3 });
            context.ProductStrap.Add(new ProductStrap() { ProductId = 21, StrapId = 2 });

            //24 24 1 2

            context.Products.Add(new Product { Name = "Đồng hồ Calvin Klein K7W2S116", Code = "K7W2S116", Image = "~/Content/Images/Products/K7W2S116.png", PromotionalPrice = 1, Price = 6930000, BrandId = 4, CategoryId = 2, Status = true, Warranty = 24, CaseSize = 28, Gender = 2, IncludedVAT = true });
            context.Products.Add(new Product { Name = "Đồng hồ Calvin Klein K7W2M616", Code = "K7W2M616", Image = "~/Content/Images/Products/K7W2M616.png", PromotionalPrice = 1, Price = 8870000, BrandId = 4, CategoryId = 2, Status = true, Warranty = 24, CaseSize = 28, Gender = 2, IncludedVAT = true });
            context.Products.Add(new Product { Name = "Đồng hồ Calvin Klein K7N236K2", Code = "K7N236K2", Image = "~/Content/Images/Products/K7N236K2.png", PromotionalPrice = 1, Price = 7470000, BrandId = 4, CategoryId = 2, Status = true, Warranty = 24, CaseSize = 38, Gender = 2, IncludedVAT = true });
            context.Products.Add(new Product { Name = "Đồng hồ Calvin Klein K7Q21146", Code = "K7Q21146", Image = "~/Content/Images/Products/K7Q21146.png", PromotionalPrice = 1, Price = 7470000, BrandId = 4, CategoryId = 2, Status = true, Warranty = 24, CaseSize = 38, Gender = 2, IncludedVAT = true });

            context.ProductStrap.Add(new ProductStrap() { ProductId = 22, StrapId = 2 });
            context.ProductStrap.Add(new ProductStrap() { ProductId = 22, StrapId = 4 });
            context.ProductStrap.Add(new ProductStrap() { ProductId = 23, StrapId = 2 });
            context.ProductStrap.Add(new ProductStrap() { ProductId = 23, StrapId = 4 });
            context.ProductStrap.Add(new ProductStrap() { ProductId = 24, StrapId = 1 });
            context.ProductStrap.Add(new ProductStrap() { ProductId = 25, StrapId = 2 });
            
            context.Products.Add(new Product { Name = "Đồng hồ Citizen AW1370.51E", Code = "AW1370.51E", Image = "~/Content/Images/Products/AW1370.51E.png", PromotionalPrice = 4140000, Price = 4600000, BrandId = 8, CategoryId = 5, Status = false, Warranty = 12, CaseSize = 41, Gender = 2, IncludedVAT = true });
            context.ProductStrap.Add(new ProductStrap() { ProductId = 26, StrapId = 5 });
            context.Products.Add(new Product { Name = "Đồng hồ Candino C4606/4", Code = "C4606/4", Image = "~/Content/Images/Products/c4606-4_1495771094.png", PromotionalPrice = 9936000, Price = 11040000, BrandId = 8, CategoryId = 5, Status = false, Warranty = 12, CaseSize = 41, Gender = 2, IncludedVAT = true });
            context.ProductStrap.Add(new ProductStrap() { ProductId = 27, StrapId = 5 });

            context.Products.Add(new Product { Name = "Đồng hồ Longines L4.874.3.27.7", Code = "L4.874.3.27.7", Image = "~/Content/Images/Products/l48743277_1493198071.png", PromotionalPrice = 46926000, Price = 52140000, BrandId = 8, CategoryId = 3, Status = false, Warranty = 12, CaseSize = 41, Gender = 2, IncludedVAT = true });
            context.ProductStrap.Add(new ProductStrap() { ProductId = 28, StrapId = 2 });
            context.SaveChanges();

            foreach (var item in context.Products.ToList()) {
                if (item.Price < 5000000)
                    item.Quantity = 5;
                else
                    item.Quantity = 3;
                if (item.PromotionalPrice != 1) {
                    context.ProductTags.Add(new ProductTag { ProductId = item.Id, TagId = 5 });
                }
            }
            
            context.SaveChanges();
            
            context.Comments.Add(new Comment() { Email = "Đỗ Đức Anh", Content = "Đồng hồ fake đấy đừng có mua ^^", ProductId = 2 });
            context.Comments.Add(new Comment() { Email = "Hán Thị Hồng Nhung", Content = "Đẹp thế mà kêu fake", ProductId = 2 });
            context.Comments.Add(new Comment() { Email = "Anonymous", Content = "Đồng hồ fake đấy đừng có tin ^^", ProductId = 2 });
            context.Comments.Add(new Comment() { Email = "Nguyễn Văn An", Content = "Đồng hồ fake đấy đừng có tin ^^", ProductId = 2 });
            context.SaveChanges();

            context.Roles.Add(new Microsoft.AspNet.Identity.EntityFramework.IdentityRole { Id = "admin", Name = "admin" });
            context.Roles.Add(new Microsoft.AspNet.Identity.EntityFramework.IdentityRole { Id = "mod", Name = "mod" });
            context.Roles.Add(new Microsoft.AspNet.Identity.EntityFramework.IdentityRole { Id = "member", Name = "member" });
            
            
        }
    }
}