using CarSharing.Models.AuthorizationModels;
using CarSharing.Models.Rental;
using Microsoft.AspNetCore.Identity;

namespace CarSharing.Models.UserModels
{
    public class UserEntity
    {
  
        public Guid Id { get; set; }
        public string PasswordHash { get; set; }
        public double? UserBalance { get; set; }
        public  string? PhoneNumber { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Email { get; set; }
        public string? DriversLicense { get; set; }
        public string? PassportNumber{ get; set; }
        public bool ActivatedAccount { get; set; }
        public string RoleName { get; set; }
        public Role? Role { get; set; }
        public List<RentalHistoryEntity>? carRentalsHistory { get; set; }

    }
}
