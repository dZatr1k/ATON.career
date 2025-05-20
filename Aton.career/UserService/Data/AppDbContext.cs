using Microsoft.EntityFrameworkCore;
using UserService.Models;

namespace Aton.Career.UserService.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>()
            .HasIndex(u => u.Login)
            .IsUnique();

        modelBuilder.Entity<User>().HasData(new User
        {
            Id = new Guid("86786fc5-fcdb-4334-babd-f7df87cfb354"),
            Login = "Admin",
            Password = "$2a$11$ThoUIkTghKhEuzgk84NxxOFVMvd7vpYYT.ldJLRpU3PRvGpjnY5Qm",
            Name = "Админ",
            Gender = 1,
            Admin = true,
            CreatedOn = DateTime.SpecifyKind(new DateTime(2024, 1, 1), DateTimeKind.Utc),
            CreatedBy = "System",
            ModifiedOn = DateTime.SpecifyKind(new DateTime(2024, 1, 1), DateTimeKind.Utc),
            ModifiedBy = "System"
        });
    }
}
