using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CarRental.Models;
using CarRental.Models.Data;
using CarRental.Models.Dtos;
using CarRental.Services.CarSer;
using Microsoft.AspNetCore.Authorization;

namespace CarRental.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly ICarService _carService;

        public CarsController( ICarService carService)
        {
            _carService = carService;
        }

        [HttpGet("OwnerCarList/{id}")]
        public async Task<ActionResult<IEnumerable<CarDto>>> GetOwnerCarList(string id)
        {
            var data = await _carService.GetOwnerCars(id);
            if (data is null)
            {
                return NoContent();
            }
            return Ok(data);
        }

        [HttpGet("getbyvehicletype/{name}")]
        public async Task<IActionResult> GetByVehicleTypeAsync(string name)
        {
            var data = await  _carService.GetCarByVehicleType(name);
            return Ok(data);
        }

        [HttpGet("getvehicletype")]
        public async Task<IActionResult> GetVehicleTypeListAsync()
        {
            var data = await _carService.GetCarVehicleType();
            return Ok(data);
        }


        // GET: api/Cars
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CarDto>>> GetCars()
        {
            try
            {
            var cars = await _carService.CarList();
            return Ok(cars);

            }catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while retrieving the products.");
            }
            
        }

        [HttpGet("availablechange/{id}")]
        public async Task<bool> CarAvailableChange(string id)
        {
            
            try
            {
                await this._carService.UpdateCarAvailable(id);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }


        // GET: api/Cars
        [HttpGet("available")]
        public async Task<ActionResult<IEnumerable<CarDto>>> GetAvailableCars()
        {
            try
            {
                var cars = await _carService.CarAvailableList();
                return Ok(cars);

            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while retrieving the products.");
            }

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CarDetailsDto>> GetCar(string id)
        {
            var car = await _carService.GetCarById(id);

            if (car == null)
            {
                return NotFound("No car selected");
            }

            return car;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutCar(string id, [FromBody] CarCreationDto car)
        {
            if (id != car.CarId)
            {
                return BadRequest();
            }

            var updateCar = await _carService.UpdateCar(id ,car);
            if (!updateCar)
            {
                return BadRequest("Error occurs!");
            }

            return NoContent();
        }

        // POST: api/Cars
        [HttpPost]
        //[Authorize("Owner")]
        public async Task<ActionResult> PostCar( [FromBody] CarCreationDto car)
        {
            try
            {
                var data = await _carService.AddCar(car);
                return CreatedAtAction("GetCar", new {id = car.CarId}, car);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }

        //[HttpGet("carOwner/{id}")]
        ////[Authorize("Owner")]
        //public async Task<ActionResult<IEnumerable<CarDto>>> GetOwnerCars(string id)
        //{
        //    try
        //    {
        //        var data = await _carService.GetOwnerCars(id);
        //        return Ok(data);
                
        //    } catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }
        //}






        // DELETE: api/Cars/5

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCar(string id)
        {
            var deleteCar = await _carService.DeleteCar(id);
            if (!deleteCar)
            {
                return NotFound();
            }
            return NoContent();
        }


    }
}
