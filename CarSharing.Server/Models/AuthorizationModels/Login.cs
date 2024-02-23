using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace CarSharing.Models.AuthorizationModels
{
    public class Login : IdentityUser
    {
        [Required(ErrorMessage = "Не указан Email")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Не указан пороль")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
