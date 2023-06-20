using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FoodBookAPI.Data;
using FoodBookAPI.Models.FoodBook;
using FoodBookAPI.ViewModel;
using FoodBookAPI.Helpers;
using FoodBookAPI.Models.BusinessLogic;

namespace FoodBookAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CuisineTypesController : ControllerBase
    {
        private readonly FoodBookContext _context;

        public CuisineTypesController(FoodBookContext context)
        {
            _context = context;
        }

        // GET: api/CuisineTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CuisineTypeForView>>> GetCuisineType()
        {
          if (_context.CuisineType == null)
          {
              return NotFound();
          }
          var items = await _context.CuisineType.Include(x => x.Image).Where(x => x.IsActive).ToListAsync();
          var result = items.Select(sl => new CuisineTypeForView { ImageURL = sl?.Image?.Image ?? "" , ImageTitle = sl?.Image?.Title ?? ""}.CopyProperties(sl)).ToList();
          return result;
        }

        // GET: api/CuisineTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CuisineTypeForView>> GetCuisineType(int id)
        {
          if (_context.CuisineType == null)
          {
              return NotFound();
          }
            var cuisineType = await _context.CuisineType.Include(x => x.Image).FirstOrDefaultAsync(i => i.Id == id);

            if (cuisineType == null)
            {
                return NotFound();
            }
            CuisineTypeForView c = new CuisineTypeForView();
            c.ImageURL = cuisineType?.Image?.Image ?? "";
            c.ImageTitle = cuisineType.Image?.Title ?? "";
            c.IdImage = cuisineType?.Image?.Id;
            c.CopyProperties(cuisineType);
            return c;
        }

        // PUT: api/CuisineTypes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCuisineType(int id, CuisineTypeForView cuisineType)
        {
            if (id != cuisineType.Id)
            {
                return BadRequest();
            }

            //_context.Entry(cuisineType).State = EntityState.Modified;
            var cuisineToModify = _context.CuisineType.Find(id);
            if (cuisineToModify == null)
            {
                return BadRequest();
            }
            cuisineToModify.CopyProperties(cuisineType);
            _context.Entry(cuisineToModify).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CuisineTypeExists(id))
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

        // POST: api/CuisineTypes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CuisineTypeForView>> PostCuisineType(CuisineTypeForView cuisineType)
        {
          if (_context.CuisineType == null)
          {
              return Problem("Entity set 'FoodBookContext.CuisineType'  is null.");
          }

            await CuisineTypeB.ConvertCuisineTypeForViewToCuisineAndSave(cuisineType, _context);
            return Ok(cuisineType);
        }

        // DELETE: api/CuisineTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCuisineType(int id)
        {
            if (_context.CuisineType == null)
            {
                return NotFound();
            }
            var cuisineType = await _context.CuisineType.FindAsync(id);
            var image = await _context.Images.FindAsync(cuisineType.IdImage);
            if (cuisineType == null)
            {
                return NotFound();
            }
            cuisineType.IsActive = false;
            image.IsActive = false;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CuisineTypeExists(int id)
        {
            return (_context.CuisineType?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
