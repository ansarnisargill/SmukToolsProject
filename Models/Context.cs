using Microsoft.EntityFrameworkCore;
using SmukToolsProject.Models;

namespace SmukToolsApp.Models
{
    public class SmukContext : DbContext
    {
        public SmukContext(DbContextOptions<SmukContext> options)
            : base(options)
        {

        }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Event> Events { get; set; }

    }

}