using Microsoft.AspNetCore.Identity;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;

namespace CarSharing.Server.Models.UserModels
{
    public class User
    {
        public User(Guid id, string passwordHash, string name, string email, string roleName, double userBalance)
        {
            Email = email;
            Id = id;
            PasswordHash = passwordHash;
            Name = name;
            RoleName = roleName;
        }

         public Guid Id { get; set; }
        public double UserBalance { get; private set; }
        public string RoleName { get; private set; }
        public string  Name { get; set; }
        public string PasswordHash { get;private set; }
        public string Email { get; private  set; }

        public static User Creat(Guid id, string email, string password, string name, double userBalance)
        {

            return new User(id , password, name, email, "User" , 0);
                
         }
    }
}
