using CarSharing.Models.CarModels;
using CarSharing.Server.Models.CarModels;
using CarSharing.Server.Models.RequistModels;

namespace CarSharing.Server.Interface.CarInterface
{
    public interface ICarModelRepository
    {
        public Task<List<CarModelEntity>> GetAllCars ();
        public Task AddCart(Cart cart);
        public Task<CarModelEntity> Serch(string brand);


    }
}