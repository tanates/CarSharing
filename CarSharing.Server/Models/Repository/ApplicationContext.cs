﻿using CarSharing.Models.CarModels;
using CarSharing.Models.Rental;
using CarSharing.Models.UserModels;
using Microsoft.EntityFrameworkCore;
using CarSharing.Models.AuthorizationModels;

namespace CarSharing.Models.Repository
{
    public class ApplicationContext : DbContext
    {

        public DbSet<User> Users { get; set; }
        public DbSet<CarBrands> Brands { get; set; }
        public DbSet<CarModel> carModels { get; set; }
        public DbSet<ActiveCarRental>CarRentals { get; set; }
        public DbSet<RentalHistory> RentalHistory { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<Registration> Registration { get; set; } = default!;
        public DbSet<Login> Login { get; set; }
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
       : base(options)
        {
        }

    }
}