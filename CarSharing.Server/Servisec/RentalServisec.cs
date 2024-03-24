using AutoMapper;
using CarSharing.Models.Rental;
using CarSharing.Server.Interface.Auth;
using CarSharing.Server.Interface.Car;
using CarSharing.Server.Models.RentalModel;
using CarSharing.Server.Models.RequistModels;
using CarSharing.Server.Repository;

namespace CarSharing.Server.Servisec
{
    public class RentalServisec
    {
   
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly ICheckingAccountStatus _status;
        private readonly IRentaACarRepository _rentaACarRepository;
        private readonly IProfileRepository _profileRepository;
        public RentalServisec(IHttpContextAccessor contextAccessor, ICheckingAccountStatus status, IRentaACarRepository rentaACarRepository, IProfileRepository profileRepository)
        {

            _contextAccessor = contextAccessor;
            _status = status;
            _rentaACarRepository = rentaACarRepository;
            _profileRepository = profileRepository;
        }

        public async Task <List<RentalHistoryEntity>> GetHistoryRental(string email)
        {
           var history = await _rentaACarRepository.GetRentalHistory(email);
            if (history == null)
            {
                throw new Exception("История пуста");
            }
           return history;
        }
        public async Task<double?> SetRental(RentaCarRequist carRequist , string email)
        {
            var httpContex = _contextAccessor.HttpContext;
            if (!_status.IsAuthorizedAccount(httpContex))
            {
                throw new Exception("Пользователь не авторизован");
            }
            var activeAccaunt = await _profileRepository.CheckIsActivation(email);
            if (!activeAccaunt)
            {
                throw new Exception("Не активный аккаунт , акивируй аккаунт");
            }
           
            var allTimePrice = _status.GetRentalPrice(carRequist.Price, carRequist.CarRentalStartDate, carRequist.CarRentalEndDate);
            
            if (!_status.IsAvailableBalance(carRequist.UserBalance, allTimePrice))
            {
                throw new Exception($"Недостаточно денег . Цена аренды {allTimePrice}");
            }

            var renta = ActiveCarRenta.Add(new Guid(), carRequist.CarRentalStartDate, carRequist.PriceForAllTime, carRequist.CarRentalEndDate, carRequist.UserEmail,
                carRequist.StartAndEndRental, carRequist.CarLicensePlate, carRequist.CarName);
            var userBalance = _status.NewBalance(carRequist.UserBalance, allTimePrice);
            await _rentaACarRepository.AddRental(renta,Convert.ToDouble(carRequist.Price), userBalance);
            var balance =   await _rentaACarRepository.UpdateBalance(carRequist.UserEmail, userBalance);
            await _rentaACarRepository.AddHistoryRental(carRequist.UserEmail);
            return balance;
        }
    }
}
