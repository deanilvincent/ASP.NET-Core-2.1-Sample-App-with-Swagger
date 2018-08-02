using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ASPNETWebAppWithSwagger.Models;

namespace ASPNETWebAppWithSwagger.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext (DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<ASPNETWebAppWithSwagger.Models.CustomerDetail> CustomerDetail { get; set; }

        public DbSet<ASPNETWebAppWithSwagger.Models.Product> Product { get; set; }

        public DbSet<ASPNETWebAppWithSwagger.Models.Order> Order { get; set; }
    }
}
