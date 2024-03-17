using CarSharing.Server.Models.UserModels;

namespace CarSharing.Server.Interface
{
    public interface IJwtProvider
    {
        public string GeneratToken(User user);
    }
}