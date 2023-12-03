using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CarRental.Models;
using CarRental.Models.Data;

namespace CarRental.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarFeaturesController : ControllerBase
    {
        private readonly CarRentingDbContext _context;

        public CarFeaturesController(CarRentingDbContext context)
        {
            _context = context;
        }

        // GET: api/CarFeatures
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CarFeature>>> GetCarFeatures()
        {
            return await _context.CarFeatures.ToListAsync();
        }

        // GET: api/CarFeatures/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CarFeature>> GetCarFeature(string id)
        {
            var carFeature = await _context.CarFeatures.FindAsync(id);

            if (carFeature == null)
            {
                return NotFound();
            }

            return carFeature;
        }

        // PUT: api/CarFeatures/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCarFeature(string id, CarFeature carFeature)
        {
            if (id != carFeature.CarFeatureId)
            {
                return BadRequest();
            }

            _context.Entry(carFeature).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CarFeatureExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/CarFeatures
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CarFeature>> PostCarFeature(CarFeature carFeature)
        {
            _context.CarFeatures.Add(carFeature);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CarFeatureExists(carFeature.CarFeatureId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetCarFeature", new { id = carFeature.CarFeatureId }, carFeature);
        }

        // DELETE: api/CarFeatures/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCarFeature(string id)
        {
            var carFeature = await _context.CarFeatures.FindAsync(id);
            if (carFeature == null)
            {
                return NotFound();
            }

            _context.CarFeatures.Remove(carFeature);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CarFeatureExists(string id)
        {
            return _context.CarFeatures.Any(e => e.CarFeatureId == id);
        }
    }
}
