using Microsoft.EntityFrameworkCore;
using WebApplicationNewVersion.Models;

namespace WebApplicationNewVersion.Data
{
    public class WebApplicationNewVersionContext : DbContext
    {
        public WebApplicationNewVersionContext (DbContextOptions<WebApplicationNewVersionContext> options)
            : base(options)
        {
        }

        public DbSet<Department> Department { get; set; } = default!;
        public DbSet<Seller> Seller { get; set; }
        public DbSet<SalesRecord> SalesRecord { get; set; }
    }
}
