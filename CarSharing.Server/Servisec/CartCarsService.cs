using CarSharing.Models.CarModels;
using CarSharing.Server.Interface.CarInterface;
using CarSharing.Server.Models.CarModels;
using CarSharing.Server.Models.RequistModels;

namespace CarSharing.Server.Servisec
{
    public class CartCarsService
    {
        private readonly ICarModelRepository _carRepository;

        public CartCarsService(ICarModelRepository carRepository)
        {
            _carRepository = carRepository;
        }


        public async Task <List<CarModelEntity>> GetCartCars()
        {
            var cars = await _carRepository.GetAllCars();
            return cars;
        }

        public async Task<CarModelEntity> GetSerchCarBrand(string brand)  
        {
            var cars = await _carRepository.Serch(brand);
            return cars;
        }
        public  async Task  AddCartCar(CartCarsRequistModel car)
        {
          var cart = Cart.Add(car.Name, car.CarDescription, car.CarLicensePlate, car.CarBrandsName, car.Price, car.ImgCar);

          await  _carRepository.AddCart(cart);
         
        }
    }
}
