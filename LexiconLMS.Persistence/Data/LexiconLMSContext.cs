using LexiconLMS.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace LexiconLMS.Persistence.Data
{
    public class LexiconLMSContext : DbContext
    {
        public LexiconLMSContext(DbContextOptions<LexiconLMSContext> options) : base(options)
        {
        }

        public DbSet<User> Users => Set<User>();
        public DbSet<Course> Courses => Set<Course>();
        public DbSet<Document> Documents => Set<Document>();
        public DbSet<Module> Modules => Set<Module>();
        public DbSet<Activity> Activities => Set<Activity>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // User to Course relationship (One-to-Many)
            modelBuilder.Entity<User>()
                .HasOne(u => u.Course)
                .WithMany(c => c.Students)
                .HasForeignKey(u => u.CourseId)
                .IsRequired() // Since the relationship is not optional
                .OnDelete(DeleteBehavior.Restrict); // Choose an appropriate delete behavior

            // Course to Module relationship (One-to-Many)
            modelBuilder.Entity<Module>()
                .HasOne(m => m.Course)
                .WithMany(c => c.Modules)
                .HasForeignKey(m => m.CourseId)
                .OnDelete(DeleteBehavior.Cascade); // Allow cascading deletes

            // Module to Activity relationship (One-to-Many)
            modelBuilder.Entity<Activity>()
                .HasOne(a => a.Module)
                .WithMany(m => m.Activities)
                .HasForeignKey(a => a.ModuleId)
                .OnDelete(DeleteBehavior.Cascade); // Allow cascading deletes

            // Document relationships (Many-to-One) for User, Course, Module, and Activity
            modelBuilder.Entity<Document>()
                .HasOne(d => d.User)
                .WithMany(u => u.Documents)
                .HasForeignKey(d => d.UserId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.SetNull); // Set foreign key to null on delete

            modelBuilder.Entity<Document>()
                .HasOne(d => d.Course)
                .WithMany(c => c.Documents)
                .HasForeignKey(d => d.CourseId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.SetNull); // Set foreign key to null on delete

            modelBuilder.Entity<Document>()
                .HasOne(d => d.Module)
                .WithMany(m => m.Documents)
                .HasForeignKey(d => d.ModuleId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.SetNull); // Set foreign key to null on delete

            modelBuilder.Entity<Document>()
                .HasOne(d => d.Activity)
                .WithMany(a => a.Documents)
                .HasForeignKey(d => d.ActivityId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.SetNull); // Set foreign key to null on delete        }
        }
    }
}
