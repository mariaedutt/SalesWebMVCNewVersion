using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NuGet.ContentModel;
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
