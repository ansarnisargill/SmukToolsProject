using Microsoft.EntityFrameworkCore;
using SmukToolsApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmukToolsApp.Data
{
    public class ToolContext : DbContext
    {
        public ToolContext(DbContextOptions<ToolContext> options)
            : base(options)
        {
        }

        public DbSet<Tool> Tools { get; set; }
        public DbSet<ToolType> ToolTypes { get; set; }
        public DbSet<Booking> Bookings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tool>().ToTable("Tools");
            modelBuilder.Entity<ToolType>().ToTable("ToolTypes");
            modelBuilder.Entity<Booking>().ToTable("Bookings");
        }
        
    }
}
