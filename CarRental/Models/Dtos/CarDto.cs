using AutoMapper.Features;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarRental.Models.Dtos
{
    public class CarDto
    {
        public string CarId { get; set; }
        public string model { get; set; }
        public string year { get; set; }
        public string plateNumber { get; set; }
        public string color { get; set; }
        public string description { get; set; }
        public int price { get; set; }
        public string image { get; set; }
        public bool availability { get; set; }
        public string CurrentLocation { get; set; }
        public BrandDto Brand { get; set; }
        public VehicleTypeDto VehicleType { get; set; }
        public List<CarFeatureDto> Features { get; set; }  
    }


    public class CarDetailsDto
    {
        public string CarId { get; set; }
        public string model { get; set; }
        public string year { get; set; }
        public string plateNumber { get; set; }
        public string color { get; set; }
        public string description { get; set; }
        public int price { get; set; }
        public string image { get; set; }
        public bool availability { get; set; }
        public string CurrentLocation { get; set; }
        public BrandDto Brand { get; set; }
        public VehicleTypeDto VehicleType { get; set; }
        public List<CarFeatureDto> Features { get; set; }
    }


    public class CarCreationDto
    {
        public string CarId { get; set; }
        public string BrandId { get; set; }
        public string VehicleTypeId { get; set; }
        public string UserId { get; set; }
        public string model { get; set; }
        public string year { get; set; }
        public string plateNumber { get; set; }
        public string color { get; set; }
        public string description { get; set; }
        public decimal price { get; set; }
        public string image { get; set; }
        public bool availability { get; set; }
        public string currentLocation { get; set; }
        public virtual List<CarFeatureDto> Features { get; set; }

    }

    public class CarReservationDto
    {
        public string model { get; set; }
        public string year { get; set; }

        public string plateNumber { get; set; }
        public VehicleTypeReservationDto VehicleType { get; set; }

    }

}
