using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CarSharing.Server.Migrations
{
    /// <inheritdoc />
    public partial class car : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Brands",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Login",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Login", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Registration",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ConfirmPassword = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Registration", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "carModels",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImgCar = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CarDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CarLicensePlate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CarBrandsName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActiveCarRental = table.Column<bool>(type: "bit", nullable: true),
                    Price = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CarBrandsId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_carModels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_carModels_Brands_CarBrandsId",
                        column: x => x.CarBrandsId,
                        principalTable: "Brands",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserBalance = table.Column<double>(type: "float", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DriversLicense = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PassportNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ActivatedAccount = table.Column<bool>(type: "bit", nullable: false),
                    RoleName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CarRentals",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CarRentalStartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PriceForAllTime = table.Column<double>(type: "float", nullable: false),
                    CarRentalEndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartAndEndRental = table.Column<bool>(type: "bit", nullable: false),
                    CarLicensePlate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CarName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CarId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarRentals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CarRentals_carModels_CarId",
                        column: x => x.CarId,
                        principalTable: "carModels",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RentalHistory",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StartRentalDateHistory = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EndRentalDateHistory = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PriceAllTime = table.Column<double>(type: "float", nullable: true),
                    CarLicensePlate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CareName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    carRentalId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RentalHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RentalHistory_CarRentals_carRentalId",
                        column: x => x.carRentalId,
                        principalTable: "CarRentals",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RentalHistory_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "RoleName" },
                values: new object[,]
                {
                    { 1, "User" },
                    { 2, "Admin" },
                    { 3, "Moderator" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_carModels_CarBrandsId",
                table: "carModels",
                column: "CarBrandsId");

            migrationBuilder.CreateIndex(
                name: "IX_CarRentals_CarId",
                table: "CarRentals",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_RentalHistory_carRentalId",
                table: "RentalHistory",
                column: "carRentalId");

            migrationBuilder.CreateIndex(
                name: "IX_RentalHistory_UserId",
                table: "RentalHistory",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Login");

            migrationBuilder.DropTable(
                name: "Registration");

            migrationBuilder.DropTable(
                name: "RentalHistory");

            migrationBuilder.DropTable(
                name: "CarRentals");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "carModels");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "Brands");
        }
    }
}
