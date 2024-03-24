using AutoMapper;
using CarSharing.Models.CarModels;
using CarSharing.Models.Rental;
using CarSharing.Models.UserModels;
using CarSharing.Server.Models.CarModels;
using CarSharing.Server.Models.RentalModel;
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
            CreateMap<ProfileUser, UserEntity>();

            /*  CreateMap<CarModelEntity, Cart>();
              CreateMap<List<CarModelEntity>, List<Cart>>().ReverseMap();
            */

          

            //  CreateMap<RentalHistoryEntity, HistoryRentalCar>();

            // CreateMap<HistoryRentalCar, RentalHistoryEntity>();

        }
    }
}
