namespace CarRental.Models
{
    public class CarFeature
    {
        public string CarFeatureId { get; set; }
        public string featureName { get; set; }
        public string description { get; set; }
        public ICollection<Car_CarFeature> Cars { get; set; }

    }
}
