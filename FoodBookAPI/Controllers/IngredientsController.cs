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
    public class IngredientsController : ControllerBase
    {
        private readonly FoodBookContext _context;

        public IngredientsController(FoodBookContext context)
        {
            _context = context;
        }

        // GET: api/Ingredients
        [HttpGet]
        public async Task<ActionResult<IEnumerable<IngredientsForView>>> GetIngredients()
        {
          if (_context.Ingredients == null)
          {
              return NotFound();
          }
            var items = await _context.Ingredients.Include(x => x.UnitOfMeasurement).Where(x => x.IsActive).ToListAsync();
            var result = items.Select(sl => new IngredientsForView { IdUnitOfMeasurement = sl?.UnitOfMeasurement.Id, UnitTitle = sl?.UnitOfMeasurement?.Title ?? "" }.CopyProperties(sl)).ToList();
            return result;
        }

        // GET: api/Ingredients/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IngredientsForView>> GetIngredients(int id)
        {
          if (_context.Ingredients == null)
          {
              return NotFound();
          }
            var ingredients = await _context.Ingredients.Include(x => x.UnitOfMeasurement).FirstOrDefaultAsync(i => i.Id == id);

            if (ingredients == null)
            {
                return NotFound();
            }

            IngredientsForView c = new IngredientsForView();
            c.IdUnitOfMeasurement = ingredients?.UnitOfMeasurement?.Id;
            c.UnitTitle = ingredients?.UnitOfMeasurement?.Title ?? "";
            c.CopyProperties(ingredients);
            return c;
        }

        // PUT: api/Ingredients/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutIngredients(int id, IngredientsForView ingredients)
        {
            if (id != ingredients.Id)
            {
                return BadRequest();
            }

            var ingridientToModify = _context.Ingredients.Find(id);
            if (ingridientToModify == null)
            {
                return BadRequest();
            }
            ingridientToModify.CopyProperties(ingredients);
            _context.Entry(ingridientToModify).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IngredientsExists(id))
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

        // POST: api/Ingredients
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<IngredientsForView>> PostIngredients(IngredientsForView ingredients)
        {
          if (_context.Ingredients == null)
          {
              return Problem("Entity set 'FoodBookContext.Ingredients'  is null.");
          }
            await IngredientsB.ConvertIngredientsForViewToIngredientsAndSave(ingredients, _context);
            return Ok(ingredients);
        }

        // DELETE: api/Ingredients/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteIngredients(int id)
        {
            if (_context.Ingredients == null)
            {
                return NotFound();
            }
            var ingredients = await _context.Ingredients.FindAsync(id);
            if (ingredients == null)
            {
                return NotFound();
            }

            ingredients.IsActive = false;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool IngredientsExists(int id)
        {
            return (_context.Ingredients?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
