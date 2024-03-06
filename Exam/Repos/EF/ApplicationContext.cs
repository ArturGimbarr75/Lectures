using Exam.Models;
using Microsoft.EntityFrameworkCore;

namespace Exam.Repos.EF;

public class ApplicationContext : DbContext
{
    public DbSet<Department> Departments { get; set; }
    public DbSet<Lecture> Lectures { get; set; }
    public DbSet<Student> Students { get; set; }

    public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
    {
        Database.EnsureCreated();
    }

    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Department>()
            .HasMany(d => d.Lectures)
            .WithMany(l => l.Departments);

        modelBuilder.Entity<Department>()
            .HasMany(d => d.Students)
            .WithOne(s => s.Department)
            .HasForeignKey(s => s.DepartmentId)
            .OnDelete(DeleteBehavior.ClientCascade);

        modelBuilder.Entity<Student>()
            .HasOne(s => s.Department)
            .WithMany(d => d.Students);

        modelBuilder.Entity<Student>()
            .HasMany(s => s.Lectures)
            .WithMany(l => l.Students);
    }
}
