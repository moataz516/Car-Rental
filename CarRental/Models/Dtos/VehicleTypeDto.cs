namespace CarRental.Models.Dtos
{
    public class VehicleTypeDto
    { 
        public string VehicleTypeId { get; set; }
        public string typeName { get; set; }
        public int capacity { get; set; } = 4;
        public string vehicleClass { get; set; }
        public string transmissionType { get; set; }
        public string mileage { get; set; }
        public string fuelType { get; set; }
    }

    public class VehicleTypeReservationDto
    {
        public string typeName { get; set; }
        public string vehicleClass { get; set; }
    }

    public class VehicleTypeFiltering
    {
        public string VehicleTypeId { get; set; }
        public string typeName { get; set; }
    }





}
