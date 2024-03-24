using AutoMapper;
using CarSharing.Models.Rental;
using CarSharing.Models.UserModels;
using CarSharing.Server.Interface.Car;
using CarSharing.Server.Models.RentalModel;
using CarSharing.Server.Models.UserModels;
using Microsoft.EntityFrameworkCore;

namespace CarSharing.Server.Repository

    //Вынести все проверки в Service а не в репозиторий!!
{
    public class RentalRepository : IRentaACarRepository
    {
        private readonly ApplicationContext _context;
        private readonly IMapper _mapper;
        public RentalRepository(ApplicationContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
          
    
        }


        public async Task<double?> UpdateBalance(string email, double newBalance)
        {
            var user  = await _context.Users.FirstOrDefaultAsync(i=>i.Email == email);
            if (user == null)
            {
                throw new Exception("Пользователь не найден");
            }
            user.UserBalance = newBalance;

            _context.Update(user);
            await _context.SaveChangesAsync();

            return user.UserBalance;
        }


        public async Task<List<RentalHistoryEntity>> GetRentalHistory(string email)
        {
            var history = await _context.RentalHistory.Where(i => i.UserEmail == email).ToListAsync();
            if (history == null || !history.Any())
            {
                return new List<RentalHistoryEntity>();
            }

            var rentalHistoryList = history.Select(item => new RentalHistoryEntity
            {
                CareName = item.CareName,
                EndRentalDateHistory = item.EndRentalDateHistory,
                CarLicensePlate = item.CarLicensePlate,
                StartRentalDateHistory = item.StartRentalDateHistory,
                PriceAllTime = item.PriceAllTime,
                UserEmail = item.UserEmail,
            }).ToList();

            return rentalHistoryList;
        }

        public async Task AddHistoryRental( string email)
        {
            var activeCarRentalEntities=  await _context.CarRentals.Where(i=>i.UserEmail == email).ToListAsync();

            foreach(var item  in activeCarRentalEntities)
            {
                var history = new RentalHistoryEntity
                {
                    Id = item.Id,
                    PriceAllTime = item.PriceForAllTime,
                    CareName = item.CarName,
                    CarLicensePlate = item.CarLicensePlate,
                    EndRentalDateHistory = item.CarRentalEndDate,
                    StartRentalDateHistory = item.CarRentalStartDate,

                };
            }

        }

     

        public async Task AddRental(ActiveCarRenta carRenta , double userBalance , double allTimePrice)
        {
          

          
            
            var activeRental = new ActiveCarRentalEntity
            {
                Id = carRenta.Id,
                PriceForAllTime = allTimePrice,
                CarLicensePlate = carRenta.CarLicensePlate,
                CarName = carRenta.CarName,
                CarRentalEndDate = carRenta.CarRentalEndDate,
                CarRentalStartDate = carRenta.CarRentalStartDate,
                UserEmail = carRenta.UserEmail,
                StartAndEndRental = true
            };
            
            

            await _context.CarRentals.AddAsync(activeRental);
            await _context.SaveChangesAsync();

        }

        
    }
}
