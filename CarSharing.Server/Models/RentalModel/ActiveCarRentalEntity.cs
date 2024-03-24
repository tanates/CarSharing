using CarSharing.Models.CarModels;
using CarSharing.Models.UserModels;

namespace CarSharing.Models.Rental
{
    public class ActiveCarRentalEntity
    {
        public Guid Id { get; set; }
        public DateTime? CarRentalStartDate { get; set; }
        public double PriceForAllTime{ get; set; }
        public DateTime? CarRentalEndDate { get; set; }
        public  string UserEmail { get; set; }
        public bool StartAndEndRental { get; set; } = false;
        public string? CarLicensePlate { get; set; }
        public string? CarName { get; set; }
        public CarModelEntity? Car { get; set; }
        public List<RentalHistoryEntity>? rentalHistories { get; set; }
    }
}
