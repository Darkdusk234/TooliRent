using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TooliRent.Core.Models;

namespace TooliRent.Infrastructure.Data
{
    public class ToolIRentDbContext : IdentityDbContext<User>
    {
        public ToolIRentDbContext(DbContextOptions<ToolIRentDbContext> option) : base(option)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Tool> Tools { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Configure Category entity
            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Description).HasMaxLength(255);
                entity.HasMany(e => e.Tools)
                      .WithOne(t => t.Category)
                      .HasForeignKey(t => t.CategoryId);
            });

            //Configure Tool entity
            modelBuilder.Entity<Tool>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.ToolType).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Description).HasMaxLength(255);
                entity.Property(e => e.Available).HasDefaultValue(true);
                entity.HasMany(e => e.Bookings)
                      .WithOne(b => b.Tool)
                      .HasForeignKey(b => b.ToolId);
            });

            //Configure Booking entity
            modelBuilder.Entity<Booking>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.HasOne(e => e.Tool)
                      .WithMany(t => t.Bookings)
                      .HasForeignKey(e => e.ToolId);
                entity.HasOne(e => e.User)
                      .WithMany(u => u.Bookings)
                      .HasForeignKey(e => e.UserId);
            });

            //Configure User entity
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasMany(e => e.Bookings)
                      .WithOne(b => b.User)
                      .HasForeignKey(b => b.UserId);
            });
        }

        private void SeedData(ModelBuilder modelBuilder)
        {
            // Seed Categories
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Power Tools", Description = "Electric and battery-powered tools" },
                new Category { Id = 2, Name = "Hand Tools", Description = "Manual tools for various tasks" }
            );

            // Seed Users
            var user1Id = Guid.NewGuid();
            var user2Id = Guid.NewGuid();

            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = user1Id.ToString(),
                    UserName = "user",
                    NormalizedUserName = "USER",
                    Email = "user@example.com",
                    NormalizedEmail = "USER@EXAMPLE.COM",
                    FirstName = "John",
                    LastName = "Doe",
                    IsActive = true
                },
                new User
                {
                    Id = user2Id.ToString(),
                    UserName = "admin",
                    NormalizedUserName = "ADMIN",
                    Email = "admin@example.com",
                    NormalizedEmail = "ADMIN@EXAMPLE.COM",
                    FirstName = "Admin",
                    LastName = "Smith",
                    IsActive = true
                }
            );

            // Seed Tools
            modelBuilder.Entity<Tool>().HasData(
                new Tool
                {
                    Id = 1,
                    ToolType = "Cordless Drill",
                    CategoryId = 1,
                    Description = "18V cordless drill with battery",
                    Available = true
                },
                new Tool
                {
                    Id = 2,
                    ToolType = "Hammer",
                    CategoryId = 2,
                    Description = "16oz claw hammer",
                    Available = true
                }
            );

            // Seed Bookings
            modelBuilder.Entity<Booking>().HasData(
                new Booking
                {
                    Id = 1,
                    UserId = user1Id,
                    ToolId = 1,
                    CreatedDate = DateTime.UtcNow,
                    IsPickedUp = false
                },
                new Booking
                {
                    Id = 2,
                    UserId = user2Id,
                    ToolId = 2,
                    CreatedDate = DateTime.UtcNow,
                    IsPickedUp = true,
                    ReturnDate = DateTime.UtcNow.AddDays(-1)
                }
                );
        }
    }
}
