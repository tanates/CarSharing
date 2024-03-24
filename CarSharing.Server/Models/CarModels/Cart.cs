namespace CarSharing.Server.Models.CarModels
{
    public class Cart
    {
        public Cart(string? name, string? carDescription, string? carLicensePlate, string carBrandsName, string? price , string img)
        {
            Name=name;
            CarDescription=carDescription;
            CarLicensePlate=carLicensePlate;
            CarBrandsName=carBrandsName;
            Price=price;
            ImgCar = img;
        }
        public  string ImgCar { get; set; }
        public string? Name { get;private set ; }
        public string? CarDescription { get;private set; }
        public string? CarLicensePlate { get;private set; }
        public string CarBrandsName { get;private set; }
        public string? Price { get;private set; }
        public bool? IsActiveCarRental { get; set; } = false;

        public static Cart Add(string? name, string? carDescription, string? carLicensePlate, string carBrandsName, string? price , string img)
        {
            return new Cart(name,  carDescription, carLicensePlate,  carBrandsName, price , img);
        }
    }
}
