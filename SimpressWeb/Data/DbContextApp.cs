using Microsoft.EntityFrameworkCore;
using Simpress.Models;

namespace SimpressWeb.Data
{
    public class DbContextApp : DbContext
    {
        public DbContextApp(DbContextOptions<DbContextApp> options) : base(options) {}

        internal DbSet<Product> Products { get; set; }
        internal DbSet<ProductCategory> ProductCategories { get; set; }
    }
}
