namespace CarSharing.Server.Models.RequistModels
{
    public class RentaCarRequist
    {
        public DateTime CarRentalStartDate { get; set; }
        public double PriceForAllTime { get; set; }
        public DateTime CarRentalEndDate { get; set; }
        public string UserEmail { get; set; }
        public double  UserBalance { get; set; }
        public string Price { get; set; }
        public bool StartAndEndRental { get; set; }
        public string? CarLicensePlate { get; set; }
        public string? CarName { get; set; }
    }
}
