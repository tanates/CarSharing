using CarSharing.Models.UserModels;

namespace CarSharing.Models.Rental
{
    public class RentalHistoryEntity
    {
        public Guid Id { get; set; }
        public DateTime? StartRentalDateHistory { get; set; }
        public DateTime? EndRentalDateHistory { get; set; }
        public double? PriceAllTime { get; set; }
        public string? CarLicensePlate { get; set; }
        public string? CareName { get; set; }
        public string UserEmail { get; set; }
        public UserEntity? User { get; set; }
        public ActiveCarRentalEntity ? carRental { get; set; }
    }
}
