namespace CarSharing.Models.Rental
{
    public class RentalHistory
    {
        public Guid Id { get; set; }
        public string? StartRentalDateHistory { get; set; }
        public string? EndRentalDateHistory { get; set; }
        public string? PriceAllTime { get; set; }
        public string? CarLicensePlate { get; set; }
        public string? CareName { get; set; }
        public  int UserID { get; set; }
        public ActiveCarRental ? carRental { get; set; }
    }
}
