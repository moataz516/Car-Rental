using CarRental.Helpers.Enum;

namespace CarRental.Models.Data
{
    public class DataInitializer
    {
        public static void Seed(IApplicationBuilder appBuilder)
        {
            using(var serviceScope = appBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<CarRentingDbContext>();

                if(!context.Brands.Any())
                {
                    context.Brands.AddRange(
                    new Brand()
                    {
                        BrandId = "1",
                        name = "Nissan",
                    },
                    new Brand()
                    {
                        BrandId = "2",
                        name = "Kia",
                    },
                    new Brand()
                    {
                        BrandId = "3",
                        name = "Hundai",
                    }
                    );
                    context.SaveChanges();
                }


                if (!context.VehicleTypes.Any())
                {
                    context.VehicleTypes.AddRange(
                    new VehicleType()
                    {
                       VehicleTypeId = "1",
                       typeName = "Compact",
                       capacity = 4 ,
                       vehicleClass = "Economy",
                       transmissionType = "Manual",
                       mileage = "150",
                       fuelType = "Gasoline"
                    },
                    new VehicleType()
                    {
                        VehicleTypeId = "2",
                        typeName = "SUV",
                        capacity = 4 ,
                        vehicleClass = "Hybrid",
                        transmissionType = "Automatic",
                        mileage = "100",
                        fuelType = "Hybrid"
                    },
                    new VehicleType()
                    {
                        VehicleTypeId = "3",
                        typeName = "Compact",
                        capacity = 4 ,
                        vehicleClass = "Luxury",
                        transmissionType = "Automatic",
                        mileage = "200",
                        fuelType = "Gasoline"
                    },
                    new VehicleType()
                    {
                        VehicleTypeId = "4",
                        typeName = "Motorcycle",
                        capacity = 1 ,
                        vehicleClass = "Sports",
                        transmissionType = "Automatic",
                        mileage = "50",
                        fuelType = "Gasoline"
                    }
                    );
                    context.SaveChanges();
                }

                if (!context.CarFeatures.Any())
                {
                    context.CarFeatures.AddRange(
                    new CarFeature()
                    {
                        CarFeatureId = "1",
                        featureName = "GPS Navigation",
                        description = "",
                    },
                    new CarFeature()
                    {
                        CarFeatureId = "2",
                        featureName = "Sunroof",
                        description = "",
                    },
                    new CarFeature()
                    {
                        CarFeatureId = "3",
                        featureName = "FourWheelDrive",
                        description = "",
                    },
                    new CarFeature()
                    {
                        CarFeatureId = "4",
                        featureName = "AirConditioning",
                        description = "",
                    },
                    new CarFeature()
                    {
                        CarFeatureId = "5",
                        featureName = "HeatedSeats",
                        description = "",
                    }
                    );
                    context.SaveChanges();
                }





                if (!context.Cars.Any())
                {
                    context.Cars.AddRange(
                    new Car()
                    {

                        CarId = "1",
                        BrandId = "1",
                        VehicleTypeId = "1",
                        //UserId = "1",
                        model = "MM5662",
                        year = 2006,
                        plateNumber = "AB 5H32",
                        color = "red",
                        price= 15,
                        description = DefaultDescriptionCar(),
                        availability = true,
                        CurrentLocation = "Aqaba"

                    },
                    new Car()
                    {

                        CarId = "2",
                        BrandId = "1",
                        VehicleTypeId = "2",
                        model = "FX6002",
                        year = 2020,
                        plateNumber = "AC 5H32",
                        color = "red",
                        price = 151,
                        description = DefaultDescriptionCar(),
                        availability = true,
                        CurrentLocation = "Amman"
                    },
                    new Car()
                    {

                        CarId = "3",
                        BrandId = "2",
                        VehicleTypeId = "1",
                        model = "FF102",
                        year = 2050,
                        plateNumber = "AC 6532",
                        color = "black",
                        price = 50,
                        description = DefaultDescriptionCar(),
                        availability = true,
                        CurrentLocation = "Amman"

                    },
                    new Car()
                    {

                        CarId = "4",
                        BrandId = "3",
                        VehicleTypeId = "1",
                        model = "RM999",
                        year = 1996,
                        plateNumber = "BB 5E32",
                        color = "white",
                        price = 70,
                        description = DefaultDescriptionCar(),
                        availability = false,
                        CurrentLocation = "Zarqa"

                    },
                    new Car()
                    {

                        CarId = "5",
                        BrandId = "3",
                        VehicleTypeId = "2",
                        model = "FX5662",
                        year = 2005,
                        plateNumber = "Cl 5KSS",
                        color = "black",
                        price = 30,
                        description = DefaultDescriptionCar(),
                        availability = true,
                        CurrentLocation = "Amman"

                    }
                   );
                    context.SaveChanges();
                }


                if (!context.Car_CarFeatures.Any())
                {
                    context.Car_CarFeatures.AddRange(
                    new Car_CarFeature()
                    {
                        CarFeatureId = "1",
                        CarId = "1",
                    },
                    new Car_CarFeature()
                    {
                        CarFeatureId = "2",
                        CarId = "1",
                    },
                    new Car_CarFeature()
                    {
                        CarFeatureId = "3",
                        CarId = "2",
                    },
                    new Car_CarFeature()
                    {
                        CarFeatureId = "5",
                        CarId = "2",
                    },
                    new Car_CarFeature()
                    {
                        CarFeatureId = "2",
                        CarId = "3",
                    },
                    new Car_CarFeature()
                    {
                        CarFeatureId = "4",
                        CarId = "4",
                    }
                    );
                    context.SaveChanges();
                }



                if (!context.Reservations.Any())
                {
                    context.Reservations.AddRange(
                    new Reservation()
                    {
                        ReservationId = "1",
                        CarId = "1",
                        //UserId = "1",
                        startDate = DateTime.Now.ToString("yyyy-MM-dd"),
                        endDate = DateTime.Now.AddDays(3).ToString("yyyy-MM-dd"),
                        startLocation = "Amman",
                        endLocation = "Zarqa",
                        totalPrice = 150,
                        isConfirmed = true,
                        status = "Pending"
                    },
                    new Reservation()
                    {
                        ReservationId = "2",
                        CarId = "2",
                        //UserId = "2",
                        startDate = DateTime.Now.ToString("yyyy-MM-dd"),
                        endDate = DateTime.Now.AddDays(3).ToString("yyyy-MM-dd"),
                        startLocation = "Amman",
                        endLocation = "Zarqa",
                        totalPrice =  250,
                        isConfirmed = false,
                        status = "Pending"
                    },
                    new Reservation()
                    {
                        ReservationId = "3",
                        CarId = "3",
                        //UserId = "3",
                        startDate = DateTime.Now.ToString("yyyy-MM-dd"),
                        endDate = DateTime.Now.AddDays(3).ToString("yyyy-MM-dd"),
                        startLocation = "Amman",
                        endLocation = "Zarqa",
                        totalPrice = 100,
                        isConfirmed = false,
                        status = "Pending"
                    }
                    );
                    context.SaveChanges();
                }
            }
        
            
        }
        public static string DefaultDescriptionCar()
        {
            return "automobile, byname auto, also called motorcar or car, a usually four-wheeled vehicle designed primarily for passenger transportation and commonly propelled by an internal-combustion engine using a volatile fuel";
        }
    }
}
