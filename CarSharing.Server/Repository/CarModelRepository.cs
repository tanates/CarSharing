using AutoMapper;
using CarSharing.Models.CarModels;
using CarSharing.Models.Rental;
using CarSharing.Server.Interface.CarInterface;
using CarSharing.Server.Models.CarModels;

namespace CarSharing.Server.Repository
{
    public class CarModelRepository : ICarModelRepository
    {
        private readonly ApplicationContext _context;
        private readonly IMapper _mapper;

        public CarModelRepository(ApplicationContext context, IMapper mapper)
        {
            _context=context;
            _mapper=mapper;
        }

        public async Task AddCar(Car car)
        {
            var carModel = new CarModelEntity
            {
                 Name  = car.Name,
                CarDescription = car.CarDescription,
                CarLicensePlate = car.CarLicensePlate,
                CarBrandsName = car.CarBrandsName,
                IsActiveCarRental = false

            };

           await _context.AddAsync(carModel);
           await _context.SaveChangesAsync();
        }

        public async  Task <CarModelEntity>GetAllCars()
        {
            var car = _context.carModels;
            return  _mapper.Map<CarModelEntity>(car);
        }
    }
}
