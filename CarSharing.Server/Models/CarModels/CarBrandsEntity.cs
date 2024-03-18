namespace CarSharing.Models.CarModels
{
    public class CarBrandsEntity
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public List<CarModelEntity> Cars { get; set; } = new();

    }
}
