using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NewsWebApp.Models.Entities;

namespace NewsWebApp.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {
            
        }
        public DbSet <Article> Articles { get; set; }
    }
    public class UserDBContext : IdentityDbContext<Users>
    {
        public UserDBContext(DbContextOptions<UserDBContext> options) : base (options)
        {
            
        }
    }
}
