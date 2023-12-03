using AutoMapper;
using CarRental.Models.Data;
using CarRental.Models.Dtos;
using Microsoft.EntityFrameworkCore;
using CarRental.Models;
using System.Drawing;
using System.Net.Mime;

namespace CarRental.Services.CarSer
{
    public class CarService : ICarService
    {
        private readonly CarRentingDbContext _context;
        private readonly IMapper _mapper;
        private readonly string filePathUrl = @"P:\Angular and .Net\CarRental\wwwroot\Images\carImage";

        public CarService(CarRentingDbContext context , IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<IEnumerable<CarDto>> CarList()
        {
            var data = await _context.Cars.Include(v => v.VehicleType).ToListAsync();
            return _mapper.Map<IEnumerable<CarDto>>(data);
        }

        public async Task<IEnumerable<CarDto>> CarAvailableList()
        {
            var data = await _context.Cars.Where(x=>x.availability == true).ToListAsync();
            return _mapper.Map<IEnumerable<CarDto>>(data);
        }





        public async Task<bool> UpdateCar(string id, CarCreationDto car)
        {
            var data = await _context.Cars.Include(c => c.CarFeatures).FirstOrDefaultAsync(x => x.CarId == id);
            if (data == null)
            {
                return false;
            }

            var image = car.image;
            if (image != null && image.Length > 0 && image != data.image)
            {
                await RemoveFile(image);
                
                var imageName = await this.SaveImageFile(car.image);
                car.image = imageName;
            }
            _mapper.Map(car,data);



            var existingFeatureIds = data.CarFeatures.Select(cf => cf.CarFeatureId).ToList();
            var newFeatureIds = car.Features.Select(cf => cf.CarFeatureId).ToList();

            // Add new features to the Car entity that don't already exist
            foreach (var newFeatureId in newFeatureIds.Except(existingFeatureIds))
            {
                var newFeature = await _context.CarFeatures.FindAsync(newFeatureId);
                if (newFeature != null)
                {
                    data.CarFeatures.Add(new Car_CarFeature
                    {
                        CarFeature = newFeature,
                        CarId = car.CarId,
                    });
                }
            }


            _context.Entry(data).State = EntityState.Modified;
           // _context.Cars.Update(data2);

            await _context.SaveChangesAsync();
            return true;
        }








        public async Task<IEnumerable<CarDto>> GetCarByVehicleType(string name)
        {
            var data = await _context.Cars.Where(x => x.VehicleType.typeName.ToLower() == name).ToListAsync();
            var car = _mapper.Map<IEnumerable<CarDto>>(data);
            return car;
        }
        public async Task<IEnumerable<VehicleTypeFiltering>> GetCarVehicleType()
        {
            var data = await _context.VehicleTypes.AsNoTracking().ToListAsync();
            var car = _mapper.Map<IEnumerable<VehicleTypeFiltering>>(data);
            return car;
        }




        public async Task<bool> UpdateCarAvailable(string id)
        {
            var data = await _context.Cars.FirstOrDefaultAsync(x => x.CarId == id);
            if (data == null)
            {
                return false;
            }


            data.availability = !data.availability;
            
            _context.Entry(data).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return true;
        }





        // Add Car and Image Proceess 
        public async Task<bool> AddCar(CarCreationDto car)
        {
            var image = car.image;
            if (image != null && image.Length > 0)
            {
                var imageName = await this.SaveImageFile(image);
                car.image = imageName;
            }

            car.CarId = Guid.NewGuid().ToString();

            var data = _mapper.Map<Car>(car);
            _context.Cars.Add(data);
            await _context.SaveChangesAsync();
            
            if(car.Features != null)
            {
                foreach (var feature in car.Features)
                {
                    _context.Car_CarFeatures.Add(new Car_CarFeature
                    {
                        CarId = car.CarId,
                        CarFeatureId = feature.CarFeatureId,
                    });
                }
                _context.SaveChanges();
            }
            return true;
        }



        public async Task<bool> DeleteCar(string id)
           {
            var data = await _context.Cars.Include(x => x.CarFeatures).Include(x=>x.Reservations).FirstOrDefaultAsync(x=>x.CarId == id);
            if(data == null)
            {
                return false;
            }

            
            if (data.CarFeatures != null)
            {
                foreach (var feature in data.CarFeatures)
                {
                    _context.Car_CarFeatures.Remove(feature);
                }
                await _context.SaveChangesAsync();
            }

            if(data.Reservations != null)
            {
                foreach (var reservation in data.Reservations)
                {
                    _context.Reservations.Remove(reservation);
                }
                await _context.SaveChangesAsync();

            }

            _context.Cars.Remove(data);
            await _context.SaveChangesAsync();



            return true;
        }

        public CarDto EditCar(string id, CarDto car)
        {
            throw new NotImplementedException();
        }

        public async Task<CarDetailsDto> GetCarById(string id)
        {
            var data = await _context.Cars.Include(c => c.CarFeatures)
                .ThenInclude(cc => cc.CarFeature)
                .Include(c => c.Brand)
                .Include(c=>c.VehicleType)
                .FirstOrDefaultAsync(x=>x.CarId == id);

            var dataDto = _mapper.Map<CarDetailsDto>(data);
            return dataDto; 
        }



        public async Task<Boolean> RemoveFile(string fileName)
        {
            string path = Path.Combine(filePathUrl, fileName);
            if (System.IO.File.Exists(path))
            {
                System.IO.File.Delete(path);
                return true;
            }
            return false;

        }
        public async Task<string> SaveImageFile(string file)
        {
            byte[] binaryImage = Convert.FromBase64String(file);
            string fileExtension = GetImageFileExtension(file);

            string imageName = Guid.NewGuid().ToString() + fileExtension;
            string path = Path.Combine(filePathUrl, imageName);

            if (!Directory.Exists(filePathUrl))
            {
                Directory.CreateDirectory(filePathUrl);
            }

            File.WriteAllBytes(path, binaryImage);
            return imageName;
        }


        private string GetImageFileExtension(string base64Data)
        {
            string[] dataParts = base64Data.Split(',');
            if (dataParts.Length > 0)
            {
                string contentType = dataParts[0];
                if (!string.IsNullOrEmpty(contentType))
                {
                    return GetFileExtensionFromContentType(contentType);
                }
            }
            return ".jpg"; // Default extension if content type is not found or invalid
        }



        private string GetFileExtensionFromContentType(string contentType)
        {
            string extension = ".jpg"; // Default extension if content type is not recognized

            try
            {
                string mediaType = new ContentType(contentType).MediaType.ToLower();
                switch (mediaType)
                {
                    case "image/jpeg":
                        extension = ".jpg";
                        break;
                    case "image/png":
                        extension = ".png";
                        break;
                    case "image/gif":
                        extension = ".gif";
                        break;
                        // Add more cases for other image formats if needed
                }
            }
            catch
            {
                // Handle exception if the content type is invalid
            }

            return extension;
        }





        public async Task<IEnumerable<CarDto>> GetOwnerCars(string id)
        {
            var data = await _context.Cars.Where(x=>x.UserId == id).Include(x=>x.Brand).Include(v =>v.VehicleType).ToListAsync();
            var cars = _mapper.Map<List<CarDto>>(data);
            return cars;
        }


        public bool CarExist(string id)
        {
            return _context.Cars.Any(e => e.CarId == id);
        }
    }
}
