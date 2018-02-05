using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNet.Identity.EntityFramework;

namespace TestWebApplication.Models
{
    // В профиль пользователя можно добавить дополнительные данные, если указать больше свойств для класса ApplicationUser. Подробности см. на странице https://go.microsoft.com/fwlink/?LinkID=317594.
    public class ApplicationUser : IdentityUser
    {
        /*
         U can write here some fields to add them to dbo.AspNetUsers
             */
        [Column(TypeName ="image")]
        public byte[] Avatar { get; set; }
        public Cart Cart { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public int Index { get; set; }
        public string Street { get; set; }
        public string Apartment { get; set; } 

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Обратите внимание, что authenticationType должен совпадать с типом, определенным в CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Здесь добавьте утверждения пользователя
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<StatusModel> Statuses { get; set; }
        public DbSet<Request> Queries { get; set; }
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

    public static ApplicationDbContext Create()
    {
        return new ApplicationDbContext();
    }

        public System.Data.Entity.DbSet<TestWebApplication.Models.Cart> Carts { get; set; }
    }
}