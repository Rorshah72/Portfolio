using Microsoft.EntityFrameworkCore;
using Portfolio.Shared.Models;

// CoreDbContext
namespace Portfolio.Services.CoreAPI.Data
{
    public class CoreDbContext : DbContext
    {
        public CoreDbContext(DbContextOptions<CoreDbContext> options) : base(options) { }

        public DbSet<Skill> Skills { get; set; }
        public DbSet<Project> ProjectPlans { get; set; }
    }
}
