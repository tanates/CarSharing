namespace CarSharing.Models.CarModels
{
    public class CarBrands
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public List<CarModel> Cars { get; set; } = new();

    }
}
