using Microsoft.EntityFrameworkCore;
using ProductProjectAPI.Core;

namespace ProductProjectAPI.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {

        }
        public DbSet<ProductEntity>? Products{ get; set; }
    }
}
