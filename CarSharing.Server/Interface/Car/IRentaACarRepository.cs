using CarSharing.Models.Rental;
using CarSharing.Server.Models.RentalModel;

namespace CarSharing.Server.Interface.Car
{
    public interface IRentaACarRepository
    {
        public Task AddRental(ActiveCarRenta carRenta, double userBalance, double allTimePrice);
        public Task AddHistoryRental(string email);
        public Task<double?> UpdateBalance(string email, double newBalance);
        public Task<List<RentalHistoryEntity>> GetRentalHistory(string email);

    }
}
