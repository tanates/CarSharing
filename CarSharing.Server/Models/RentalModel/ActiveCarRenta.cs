using CarSharing.Server.Models.RequistModels;

namespace CarSharing.Server.Models.RentalModel
{
    public class ActiveCarRenta
    {
        public ActiveCarRenta(Guid id, DateTime carRentalStartDate, double priceForAllTime, DateTime carRentalEndDate, string userEmail, bool startAndEndRental, string? carLicensePlate, string? carName)
        {
            Id = id;
            CarRentalStartDate = carRentalStartDate;
            PriceForAllTime = priceForAllTime;
            CarRentalEndDate = carRentalEndDate;
            UserEmail = userEmail;
            StartAndEndRental = startAndEndRental;
            CarLicensePlate = carLicensePlate;
            CarName = carName;
        }
        public Guid Id { get; set; }
        public DateTime CarRentalStartDate { get;private set; }
        public double PriceForAllTime { get; private set; }
        public DateTime CarRentalEndDate { get; private set; }
        public string UserEmail { get; private set; }
        public bool StartAndEndRental { get; private set; }
        public string? CarLicensePlate { get; private set; }
        public string? CarName { get; private set; }


        public static ActiveCarRenta Add(Guid id, DateTime carRentalStartDate, double priceForAllTime, DateTime carRentalEndDate, string userEmail, bool startAndEndRental, string? carLicensePlate, string? carName)
        {
            return new ActiveCarRenta(id, carRentalStartDate,  priceForAllTime, carRentalEndDate, userEmail, startAndEndRental, carLicensePlate,  carName);
        }
    }
}
