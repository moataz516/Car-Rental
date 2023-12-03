namespace CarRental.Models
{
    public class VehicleType
    {
        public string VehicleTypeId { get; set; }
        public string typeName { get; set; }
        public int capacity { get; set; } = 4;
        //public string size { get; set; }
        public string vehicleClass { get; set; }
        public string transmissionType { get; set; }
        public string mileage { get; set; }
        public string fuelType { get; set; }

        public ICollection<Car> Cars { get; set; }
    }
}
