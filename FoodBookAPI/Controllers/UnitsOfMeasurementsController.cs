using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FoodBookAPI.Data;
using FoodBookAPI.Models.FoodBook;

namespace FoodBookAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UnitsOfMeasurementsController : ControllerBase
    {
        private readonly FoodBookContext _context;

        public UnitsOfMeasurementsController(FoodBookContext context)
        {
            _context = context;
        }

        // GET: api/UnitsOfMeasurements
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UnitsOfMeasurement>>> GetUnitsOfMeasurement()
        {
          if (_context.UnitsOfMeasurement == null)
          {
              return NotFound();
          }
            return await _context.UnitsOfMeasurement.Where(x => x.IsActive == true).ToListAsync();
        }

        // GET: api/UnitsOfMeasurements/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UnitsOfMeasurement>> GetUnitsOfMeasurement(int id)
        {
          if (_context.UnitsOfMeasurement == null)
          {
              return NotFound();
          }
            var unitsOfMeasurement = await _context.UnitsOfMeasurement.FindAsync(id);

            if (unitsOfMeasurement == null)
            {
                return NotFound();
            }

            return unitsOfMeasurement;
        }

        // PUT: api/UnitsOfMeasurements/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUnitsOfMeasurement(int id, UnitsOfMeasurement unitsOfMeasurement)
        {
            if (id != unitsOfMeasurement.Id)
            {
                return BadRequest();
            }

            _context.Entry(unitsOfMeasurement).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UnitsOfMeasurementExists(id))
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

        // POST: api/UnitsOfMeasurements
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<UnitsOfMeasurement>> PostUnitsOfMeasurement(UnitsOfMeasurement unitsOfMeasurement)
        {
          if (_context.UnitsOfMeasurement == null)
          {
              return Problem("Entity set 'FoodBookContext.UnitsOfMeasurement'  is null.");
          }
            _context.UnitsOfMeasurement.Add(unitsOfMeasurement);
            await _context.SaveChangesAsync();

            return Ok(unitsOfMeasurement);
        }

        // DELETE: api/UnitsOfMeasurements/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUnitsOfMeasurement(int id)
        {
            if (_context.UnitsOfMeasurement == null)
            {
                return NotFound();
            }
            var unitsOfMeasurement = await _context.UnitsOfMeasurement.FindAsync(id);
            if (unitsOfMeasurement == null)
            {
                return NotFound();
            }

            unitsOfMeasurement.IsActive = false;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UnitsOfMeasurementExists(int id)
        {
            return (_context.UnitsOfMeasurement?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
