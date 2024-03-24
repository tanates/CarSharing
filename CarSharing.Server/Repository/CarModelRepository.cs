using AutoMapper;
using CarSharing.Models.CarModels;
using CarSharing.Models.Rental;
using CarSharing.Server.Interface.CarInterface;
using CarSharing.Server.Models.CarModels;
using CarSharing.Server.Models.RequistModels;
using Microsoft.EntityFrameworkCore;
using System.Drawing.Text;

namespace CarSharing.Server.Repository
{
    public class CarModelRepository : ICarModelRepository
    {

        const string CAR_IMG = "https://thumbs.dreamstime.com/b/шаб-он-автомоби-я-d-бе-ый-пустой-97883266.jpg";
        private readonly ApplicationContext _context;
        private readonly IMapper _mapper;

        public CarModelRepository(ApplicationContext context, IMapper mapper)
        {
            _context=context;
            _mapper=mapper;
        }

        public async Task AddCart(Cart car)
        {
            try
            {
                var img = car.ImgCar == null ? CAR_IMG : car.ImgCar;
                var carModel = new CarModelEntity
                {
                    Price = car.Price,
                    Name = car.Name,
                    CarDescription = car.CarDescription,
                    CarLicensePlate = car.CarLicensePlate,
                    CarBrandsName = car.CarBrandsName,
                    IsActiveCarRental = false,
                    ImgCar = img

                };

                await _context.AddAsync(carModel);
                await _context.SaveChangesAsync();
              
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex}");
            }
          
        }

        public async Task<List<CarModelEntity>> GetAllCars()
        {
            var cars = await _context.carModels.Where(i => i.IsActiveCarRental == false).ToListAsync();

            return cars.Select(car => new CarModelEntity
            {
                Id = car.Id,
                Name = car.Name,
                ImgCar = car.ImgCar,
                CarDescription = car.CarDescription,
                CarLicensePlate = car.CarLicensePlate,
                CarBrandsName = car.CarBrandsName,
                IsActiveCarRental = car.IsActiveCarRental,
                Price = car.Price,
                CarBrands = car.CarBrands,
                carRentals = car.carRentals
            }).ToList();
        }


        public async Task <CarModelEntity>Serch(string brand)
        {
            var car  = await _context.carModels.Where(i=>i.CarBrandsName ==  brand).ToListAsync();

            if (car == null)
                throw new Exception("Not Cars rental");
            return _mapper.Map<CarModelEntity>(car);
        }
    }
}
