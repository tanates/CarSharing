using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;

namespace CarSharing.Server.Models.AuthorizationModels
{
    public class ProfileRequist
    {
        public string Email  { get; set; }
        public double UserBalance { get; set; }
        public string? Surname { get;set; }
        public string? DriversLicense { get; set; }
        public string? PassportNumber { get; set; }
        public string PhoneNumber { get; set; }
    }
}
