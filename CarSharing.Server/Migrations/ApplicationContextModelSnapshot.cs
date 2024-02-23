﻿// <auto-generated />
using System;
using CarSharing.Models.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CarSharing.Server.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    partial class ApplicationContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CarSharing.Models.AuthorizationModels.Login", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Login");
                });

            modelBuilder.Entity("CarSharing.Models.AuthorizationModels.Registration", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ConfirmPassword")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Registration");
                });

            modelBuilder.Entity("CarSharing.Models.CarModels.CarBrands", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Brands");
                });

            modelBuilder.Entity("CarSharing.Models.CarModels.CarModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("CarBrandsId")
                        .HasColumnType("int");

                    b.Property<Guid?>("CarBrandsId1")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CarDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CarLicensePlate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Price")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CarBrandsId1");

                    b.ToTable("carModels");
                });

            modelBuilder.Entity("CarSharing.Models.Rental.ActiveCarRental", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CarId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CarLicensePlate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CarName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CarRentalEndDate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CarRentalStartDate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PriceForAllTime")
                        .HasColumnType("int");

                    b.Property<bool>("StartAndEndRental")
                        .HasColumnType("bit");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<Guid?>("UserId1")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("CarId");

                    b.HasIndex("UserId1");

                    b.ToTable("CarRentals");
                });

            modelBuilder.Entity("CarSharing.Models.Rental.RentalHistory", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CarLicensePlate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CareName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EndRentalDateHistory")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PriceAllTime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StartRentalDateHistory")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.Property<Guid?>("carRentalId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("carRentalId");

                    b.ToTable("RentalHistory");
                });

            modelBuilder.Entity("CarSharing.Models.UserModels.Role", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("RoleName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Role");
                });

            modelBuilder.Entity("CarSharing.Models.UserModels.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("ActivatedAccount")
                        .HasColumnType("bit");

                    b.Property<string>("DriversLicense")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PassportNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<Guid?>("RoleId1")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Surname")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId1");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("CarSharing.Models.CarModels.CarModel", b =>
                {
                    b.HasOne("CarSharing.Models.CarModels.CarBrands", "CarBrands")
                        .WithMany("Cars")
                        .HasForeignKey("CarBrandsId1");

                    b.Navigation("CarBrands");
                });

            modelBuilder.Entity("CarSharing.Models.Rental.ActiveCarRental", b =>
                {
                    b.HasOne("CarSharing.Models.CarModels.CarModel", "Car")
                        .WithMany("carRentals")
                        .HasForeignKey("CarId");

                    b.HasOne("CarSharing.Models.UserModels.User", "User")
                        .WithMany("carRentals")
                        .HasForeignKey("UserId1");

                    b.Navigation("Car");

                    b.Navigation("User");
                });

            modelBuilder.Entity("CarSharing.Models.Rental.RentalHistory", b =>
                {
                    b.HasOne("CarSharing.Models.Rental.ActiveCarRental", "carRental")
                        .WithMany("rentalHistories")
                        .HasForeignKey("carRentalId");

                    b.Navigation("carRental");
                });

            modelBuilder.Entity("CarSharing.Models.UserModels.User", b =>
                {
                    b.HasOne("CarSharing.Models.UserModels.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId1");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("CarSharing.Models.CarModels.CarBrands", b =>
                {
                    b.Navigation("Cars");
                });

            modelBuilder.Entity("CarSharing.Models.CarModels.CarModel", b =>
                {
                    b.Navigation("carRentals");
                });

            modelBuilder.Entity("CarSharing.Models.Rental.ActiveCarRental", b =>
                {
                    b.Navigation("rentalHistories");
                });

            modelBuilder.Entity("CarSharing.Models.UserModels.User", b =>
                {
                    b.Navigation("carRentals");
                });
#pragma warning restore 612, 618
        }
    }
}
