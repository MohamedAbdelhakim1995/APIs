using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EcommerceApis.Models
{
    public class EcommerceEntity : IdentityDbContext<ApplicationUser> 
    {

        public DbSet<Category> category {get ; set ;}
        public DbSet<Product> product { get; set; }

        public DbSet<Order> order { get; set; }

        public DbSet<Cart> cart { get; set; }

        public DbSet<CartItem> cartItem { get; set; }

        public DbSet<ApplicationUser> applicationUser { get; set; }





        public EcommerceEntity() : base()
        {

        }


        public EcommerceEntity(DbContextOptions options) : base (options)
        {

        }


        protected override void OnConfiguring(DbContextOptionsBuilder ob)
        {
            ob.UseSqlServer(@"Data Source=DESKTOP-BFD20LM;Initial Catalog=EcommerceProject;Integrated Security=True");

        }

    }
}
