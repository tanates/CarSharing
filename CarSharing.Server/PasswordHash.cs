using CarSharing.Server.Interface.Auth;

namespace CarSharing.Server
{
    public class PasswordHash : IPasswordHash
    {
        public string Generate(string password) =>
            BCrypt.Net.BCrypt.EnhancedHashPassword(password);

        public bool VerifyPassword(string password, string passwordHash) =>
            BCrypt.Net.BCrypt.EnhancedVerify(password, passwordHash);

     
    }
}
