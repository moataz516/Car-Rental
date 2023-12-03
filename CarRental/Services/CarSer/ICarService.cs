using CarRental.Models.Dtos;
using CarRental.Models;

namespace CarRental.Services.CarSer
{
    public interface ICarService
    {
         Task<IEnumerable<CarDto>> CarList();
        Task<IEnumerable<CarDto>> CarAvailableList();

        Task<CarDetailsDto> GetCarById(string id);
        Task<IEnumerable<CarDto>> GetCarByVehicleType(string name);
        Task<IEnumerable<VehicleTypeFiltering>> GetCarVehicleType();

        Task<bool> UpdateCar(string id , CarCreationDto car);
        Task<bool> UpdateCarAvailable(string id);
         CarDto EditCar(string id, CarDto car);
         Task<bool> AddCar(CarCreationDto car);
        Task<IEnumerable<CarDto>> GetOwnerCars(string id);
         Task<bool> DeleteCar(string id);
        bool CarExist (string id);
    }
}
