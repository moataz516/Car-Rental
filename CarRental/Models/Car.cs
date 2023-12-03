namespace CarRental.Models
{
    public class Car
    {
        public string CarId { get; set; }
        public string BrandId { get; set; }
        public string VehicleTypeId { get; set; }
        public string UserId { get; set; }
        public string model { get; set; }
        public int year { get; set; }
        public string plateNumber { get; set; }
        public string color { get; set; }
        public decimal price { get; set; }
        public string description { get; set; }
        public string CurrentLocation { get; set; }
        public string image { get; set; }
        public bool availability  { get; set; }
        public ICollection<Car_CarFeature> CarFeatures { get; set; }
        public ICollection<Reservation> Reservations { get; set; }
        public Brand Brand { get; set; }
        public VehicleType VehicleType { get; set; }
        public ApplicationUser User { get; set; }


    }
}
