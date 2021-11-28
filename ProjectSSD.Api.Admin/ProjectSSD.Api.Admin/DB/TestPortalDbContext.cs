using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectSSD.Api.Admin.DB
{
    public class AdminDbContext : DbContext
    {
        public DbSet<TestPortal> TestPortal { get; set; }
        public DbSet<Schedule> Schedule { get; set; }
        public DbSet<Feedback> Feedback { get; set; }
        public DbSet<ClickEvent> ClickEvent { get; set; }


        public AdminDbContext(DbContextOptions options) : base(options)
        {

        }
    }
}
