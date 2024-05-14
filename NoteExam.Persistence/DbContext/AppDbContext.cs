using Microsoft.EntityFrameworkCore;
using NoteExam.Models;

namespace NoteExam.Persistence.Context;

public class AppDbContext : DbContext
{
    public DbSet<User> Users { get; set; } = null!;

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {

    }
}
