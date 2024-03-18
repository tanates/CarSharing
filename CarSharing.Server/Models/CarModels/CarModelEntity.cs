using CarSharing.Models.Rental;

namespace CarSharing.Models.CarModels
{
    public class CarModelEntity
    {
        public  Guid Id { get; set; }
        public string? Name { get; set; }
        public string ? CarDescription { get; set; }
        public string? CarLicensePlate { get; set; }
        public string CarBrandsName { get; set; }
        public bool ? IsActiveCarRental { get; set; } = false;
        public  string?  Price { get; set; }
        public CarBrandsEntity? CarBrands { get; set; }
        public List<ActiveCarRental>? carRentals { get; set; }

    }
}
