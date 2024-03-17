using CarSharing.Server.Models.AuthorizationModels;

namespace CarSharing.Server.Models.UserModels
{
    public class ProfileUser
    {
        public ProfileUser(ProfileRequist requist)
        {
            Email = requist.Email ?? "";
            Surname = requist.Surname ?? "";
            ActivatedAccount = false ;
            DriversLicense = requist.DriversLicense ?? "";
            PassportNumber = requist.PassportNumber ?? "";
            PhoneNumber = requist.PhoneNumber ?? "";
        }

        public string? Email { get; private set; }
        public string? Surname { get; private set; }
        public bool ActivatedAccount { get; private set; }
        public string? DriversLicense { get; private set; }
        public string? PassportNumber { get; private set; }
        public string?PhoneNumber { get; private set; }

        public static ProfileUser AddDateProfile(ProfileRequist requist)
        {
            return new ProfileUser(requist);
        }
    }
}
