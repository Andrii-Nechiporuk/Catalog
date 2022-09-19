using Microsoft.EntityFrameworkCore;

namespace CatalogApp.Models
{
    public class CatalogDbContext : DbContext
    {
        public CatalogDbContext(DbContextOptions<CatalogDbContext> options) : base(options) 
        {
        
        }

        public DbSet<CatalogItem> CatalogItems { get; set; }
    }
}
