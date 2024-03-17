using CarSharing.Models.CarModels;
using CarSharing.Models.UserModels;

namespace CarSharing.Models.Rental
{
    public class ActiveCarRental
    {
        public Guid Id { get; set; }
        public string? CarRentalStartDate { get; set; }
        public int PriceForAllTime{ get; set; }
        public string? CarRentalEndDate { get; set; }
        public  int UserId { get; set; }
        public bool StartAndEndRental { get; set; }
        public string? CarLicensePlate { get; set; }
        public string? CarName { get; set; }
        public CarModel? Car { get; set; }
        public UserEntity? User { get; set; }
        public List<RentalHistory>? rentalHistories { get; set; }
    }
}
