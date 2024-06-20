using LexiconLMS.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace LexiconLMS.Persistence
{
    public class LexiconLMSDbContext : DbContext
    {
        public LexiconLMSDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Activity> Activities { get; set; } = default!;
        public DbSet<Course> Courses { get; set; } = default!;
        public DbSet<Document> Documents { get; set; } = default!;
        public DbSet<Module> Modules { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(System.Reflection.Assembly.GetExecutingAssembly());
        }
    }
}
