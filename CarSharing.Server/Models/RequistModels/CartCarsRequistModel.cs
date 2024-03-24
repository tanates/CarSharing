namespace CarSharing.Server.Models.RequistModels
{
    public class CartCarsRequistModel
    {

        public string? Name { get; set; }
        public string ImgCar { get; set; }
        public string? CarDescription { get; set; }
        public string? CarLicensePlate { get; set; }
        public string CarBrandsName { get; set; }
        public bool? IsActiveCarRental { get; set; } = false;
        public string? Price { get; set; }

    }
}
