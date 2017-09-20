using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace WSNet.Models
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

    public class StoreContext : IdentityDbContext<ApplicationUser>
    {
        public StoreContext()
            : base("Store", throwIfV1Schema: false)
        {
        }

        public static StoreContext Create()
        {
            return new StoreContext();
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }



        //https://es.stackoverflow.com/questions/9044/asp-net-mvc5-como-puedo-crear-un-crud-para-la-tabla-aspnetusers
        //public System.Data.Entity.DbSet<WSNet.Models.ApplicationUser> ApplicationUsers { get; set; }



    }
}