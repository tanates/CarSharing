using CarSharing.Models.CarModels;
using CarSharing.Server.Models.CarModels;

namespace CarSharing.Server.Interface.CarInterface
{
    public interface ICarModelRepository
    {
        public Task<CarModelEntity> GetAllCars ();
        public Task AddCar(Car car);
        
    }
}