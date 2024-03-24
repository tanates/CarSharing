using CarSharing.Models.UserModels;
using CarSharing.Server.Models.AuthorizationModels;
using CarSharing.Server.Models.UserModels;

namespace CarSharing.Server.Interface.Auth
{
    public interface IProfileRepository
    {
        Task<bool> Update(ProfileUser profile);
        public Task<UserEntity> GetProfileByEmail(string email);
        public  Task<bool> CheckIsActivation(string email);

    }
}