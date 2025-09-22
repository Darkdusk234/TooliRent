using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TooliRent.Core.Models;

namespace TooliRent.Infrastructure.Data
{
    public class ToolIRentDbContext : IdentityDbContext<User>
    {
        public ToolIRentDbContext(DbContextOptions<ToolIRentDbContext> options) : base(options)
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

            // Seed initial data
            SeedData(modelBuilder);
        }

        private void SeedData(ModelBuilder modelBuilder)
        {
            // Static DateTime to avoid dynamic changes
            DateTime staticDate = new DateTime(2025, 10, 10, 0, 0, 0, 0, DateTimeKind.Utc);
            DateTime startStaticDate = new DateTime(2025, 10, 06, 0, 0, 0, 0, DateTimeKind.Utc);

            // Seed Categories
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Power Tools", Description = "Electric and battery-powered tools" },
                new Category { Id = 2, Name = "Hand Tools", Description = "Manual tools for various tasks" }
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
                    UserId = "admin",
                    ToolId = 1,
                    CreatedDate = new DateTime(2025, 09, 05),
                    IsPickedUp = false,
                    IsCancelled = false,
                    StartBookedDate = startStaticDate,
                    LastBookedDate = staticDate
                },
                new Booking
                {
                    Id = 2,
                    UserId = "admin",
                    ToolId = 2,
                    CreatedDate = new DateTime(2025, 08, 30),
                    IsPickedUp = true,
                    IsCancelled = false,
                    ReturnDate = new DateTime(2025, 09, 04),
                    StartBookedDate = startStaticDate,
                    LastBookedDate = staticDate
                }
                );

        }
    }
}
