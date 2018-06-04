using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using TNAShop.Domain;

namespace TNAShop.Data
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("TNAShop", throwIfV1Schema: false)
        {
            
        }

        public DbSet<Product> Products { set; get; }
        public DbSet<Category> Categories { set; get; }
        public DbSet<Tag> Tags { set; get; }
        public DbSet<ProductTag> ProductTags { set; get; }
        public DbSet<Brand> Brands { set; get; }
        public DbSet<ProductStrap> ProductStrap { set; get; }
        public DbSet<Strap> Straps{ set; get; }
        public DbSet<PriceFiltering> PriceFilterings { set; get; }
        public DbSet<Comment> Comments { set; get; }
        public DbSet<Order> Orders { set; get; }
        public DbSet<OrderDet> OrderDet { set; get; }
        
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}