namespace CarSharing.Server.Models.CarModels
{
    public class Car
    {
        public Car(string? name, string? carDescription, string? carLicensePlate, string carBrandsName, string? price)
        {
            Name=name;
            CarDescription=carDescription;
            CarLicensePlate=carLicensePlate;
            CarBrandsName=carBrandsName;
            Price=price;
        }

        public string? Name { get;private set ; }
        public string? CarDescription { get;private set; }
        public string? CarLicensePlate { get;private set; }
        public string CarBrandsName { get;private set; }
        public string? Price { get;private set; }
        public bool? IsActiveCarRental { get; set; } = false;

        public static Car Add(string? name, string? carDescription, string? carLicensePlate, string carBrandsName, string? price)
        {
            return new Car(name,  carDescription, carLicensePlate,  carBrandsName, price);
        }
    }
}
