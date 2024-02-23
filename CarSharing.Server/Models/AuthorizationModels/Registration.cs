using CarSharing.Models.UserModels;
using System.ComponentModel.DataAnnotations;

namespace CarSharing.Models.AuthorizationModels
{
    public class Registration
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Введите имя ")]
        public string Name { get; set; }


        [Required(ErrorMessage = "Не указан Email")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Не указан пороль")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "Пороль не совпадает")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }
}
