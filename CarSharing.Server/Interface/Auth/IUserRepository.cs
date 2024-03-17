using CarSharing.Models.UserModels;
using CarSharing.Server.Models.UserModels;

namespace CarSharing.Server.Interface.Auth
{
    public interface IUserRepository
    {
        public Task Add(User user);
        public Task<User> GetByEmail(string email);
    }
}
