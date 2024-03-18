using CarSharing.Models.CarModels;
using CarSharing.Models.Rental;
using CarSharing.Models.UserModels;
using Microsoft.EntityFrameworkCore;
using CarSharing.Models.AuthorizationModels;

namespace CarSharing.Server.Repository
{
    public class ApplicationContext : DbContext
    {

        public DbSet<UserEntity> Users { get; set; }
        public DbSet<CarBrandsEntity> Brands { get; set; }
        public DbSet<CarModelEntity> carModels { get; set; }
        public DbSet<ActiveCarRental> CarRentals { get; set; }
        public DbSet<RentalHistory> RentalHistory { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<Registration> Registration { get; set; } = default!;
        public DbSet<Login> Login { get; set; }
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
       : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>().HasData(
                new Role { Id = 1, RoleName = "User" },
                new Role { Id = 2, RoleName = "Admin" },
                new Role { Id = 3, RoleName = "Moderator" }
            );
        }
    }
}
