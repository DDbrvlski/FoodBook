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
    public class DishTypesController : ControllerBase
    {
        private readonly FoodBookContext _context;

        public DishTypesController(FoodBookContext context)
        {
            _context = context;
        }

        // GET: api/DishTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DishTypeForView>>> GetDishType()
        {
          if (_context.DishType == null)
          {
              return NotFound();
          }

			var items = await _context.DishType.Include(x => x.Image).Where(x => x.IsActive).ToListAsync();
			var result = items.Select(sl => new DishTypeForView { ImageURL = sl?.Image?.Image ?? "", ImageTitle = sl?.Image?.Title ?? ""}.CopyProperties(sl)).ToList();
          return result;
        }

        // GET: api/DishTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DishTypeForView>> GetDishType(int id)
        {
          if (_context.DishType == null)
          {
              return NotFound();
          }
            var dishType = await _context.DishType.Include(x => x.Image).FirstOrDefaultAsync(i => i.Id == id);

            if (dishType == null)
            {
                return NotFound();
            }
            DishTypeForView c = new DishTypeForView();
            c.ImageURL = dishType?.Image?.Image ?? "";
            c.ImageTitle = dishType?.Image?.Title ?? "";
            c.IdImage = dishType?.Image?.Id;
            c.CopyProperties(dishType);
            return c;
        }

        // PUT: api/DishTypes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDishType(int id, DishTypeForView dishType)
        {
            if (id != dishType.Id)
            {
                return BadRequest();
            }

            DishType dishToModify = _context.DishType.Include(x => x.Image).First(x => x.Id == id);
            if (dishToModify == null)
            {
                return BadRequest();
            }
            DishTypeB.EditConvertDishTypeForViewToDishAndSave(dishToModify, dishType, _context);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DishTypeExists(id))
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

        // POST: api/DishTypes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DishTypeForView>> PostDishType(DishTypeForView dishType)
        {
          if (_context.DishType == null)
          {
              return Problem("Entity set 'FoodBookContext.DishType'  is null.");
          }
            await DishTypeB.ConvertDishTypeForViewToDishAndSave(dishType, _context);

            return Ok(dishType);
        }

        // DELETE: api/DishTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDishType(int id)
        {
            if (_context.DishType == null)
            {
                return NotFound();
            }
            var dishType = await _context.DishType.FindAsync(id);
            var image = await _context.Images.FindAsync(dishType.IdImage);
            if (dishType == null)
            {
                return NotFound();
            }

            dishType.IsActive = false;
            image.IsActive = false;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DishTypeExists(int id)
        {
            return (_context.DishType?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
