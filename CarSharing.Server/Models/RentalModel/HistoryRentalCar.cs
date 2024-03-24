namespace CarSharing.Server.Models.RentalModel
{
    public class HistoryRentalCar
    {
        public HistoryRentalCar(Guid? id, DateTime? startRentalDateHistory, DateTime? endRentalDateHistory, double? priceAllTime, string? carLicensePlate, string? careName, string? userEmail)
        {
            Id = id;
            StartRentalDateHistory = startRentalDateHistory;
            EndRentalDateHistory = endRentalDateHistory;
            PriceAllTime = priceAllTime;
            CarLicensePlate = carLicensePlate;
            CareName = careName;
            UserEmail = userEmail;
        }

        public Guid? Id { get; set; }
        public DateTime? StartRentalDateHistory { get; set; }
        public DateTime? EndRentalDateHistory { get; set; }
        public double? PriceAllTime { get; set; }
        public string? CarLicensePlate { get; set; }
        public string? CareName { get; set; }
        public string? UserEmail { get; set; }


        public static HistoryRentalCar Add(Guid? id, DateTime? startRentalDateHistory, DateTime? endRentalDateHistory, double? priceAllTime, string? carLicensePlate, string? careName, string ?userEmail)
        {
            return new HistoryRentalCar(id, startRentalDateHistory, endRentalDateHistory, priceAllTime, carLicensePlate, careName, userEmail);
        }
    }
}
