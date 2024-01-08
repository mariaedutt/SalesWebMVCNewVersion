using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public DbSet<WebApplicationNewVersion.Models.Department> Department { get; set; } = default!;
    }
}
