using Microsoft.EntityFrameworkCore;
using NewsWebApp.Models;

namespace NewsWebApp.Data
{
    public class ApplicationDBContext:DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {

        }
        public DbSet <Article> Articles { get; set; }
    }
}
