using CarSharing.Models.AuthorizationModels;
using CarSharing.Models.Rental;
using Microsoft.AspNetCore.Identity;

namespace CarSharing.Models.UserModels
{
    public class User
    {
        public Guid Id { get; set; }
        public string? Password { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Email { get; set; }
        public string? DriversLicense { get; set; }
        public string? PassportNumber{ get; set; }
        public bool ActivatedAccount { get; set; }
        public int RoleId { get; set; }
        public Role? Role { get; set; }
        public List<ActiveCarRental>? carRentals { get; set; }
    }
}
