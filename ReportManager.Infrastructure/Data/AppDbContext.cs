using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ReportManager.Domain.Entities;

namespace ReportManager.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext (DbContextOptions<AppDbContext> options)
            : base(options) { }

        public DbSet<Report> Reports => Set<Report>();
        public DbSet<User> Users => Set<User>();
    }
}
