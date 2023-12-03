namespace CarRental.Models
{
    public class Car_CarFeature
    {
        
        public string CarId { get; set; }
        public Car Car { get; set; }
        public string CarFeatureId { get; set; }
        public CarFeature CarFeature { get; set; }

    }
}
