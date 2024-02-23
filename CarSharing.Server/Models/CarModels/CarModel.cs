using CarSharing.Models.Rental;

namespace CarSharing.Models.CarModels
{
    public class CarModel
    {
        public  Guid Id { get; set; }
        public string? Name { get; set; }
        public string ? CarDescription { get; set; }
        public string? CarLicensePlate { get; set; }
        public int CarBrandsId { get; set; }
        public  string?  Price { get; set; }
        public CarBrands? CarBrands { get; set; }
        public List<ActiveCarRental>? carRentals { get; set; }

    }
}
