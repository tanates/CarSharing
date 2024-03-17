using AutoMapper;
using CarSharing.Models.UserModels;
using CarSharing.Server.Models.UserModels;

namespace CarSharing.Server.Models
{
    public class DataBaseMapping :Profile
    {
        public DataBaseMapping()
        {
            CreateMap<UserEntity, User>();
            CreateMap<User, UserEntity>();

            CreateMap <UserEntity , ProfileUser>();
            CreateMap<UserEntity , ProfileUser>();
        }
    }
}
