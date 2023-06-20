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
    public class IngredientsForRecipesController : ControllerBase
    {
        private readonly FoodBookContext _context;

        public IngredientsForRecipesController(FoodBookContext context)
        {
            _context = context;
        }

        // GET: api/IngredientsForRecipes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<IngredientsForRecipeForView>>> GetIngredientsForRecipe()
        {
          if (_context.IngredientsForRecipe == null)
          {
              return NotFound();
          }
            var items = await _context.IngredientsForRecipe.Include(x => x.Ingredient).Include(x => x.Recipe).Where(x => x.IsActive == true).ToListAsync();
            var result = items.Select(sl => new IngredientsForRecipeForView {  }.CopyProperties(sl)).ToList();
            return result;
        }

        // GET: api/IngredientsForRecipes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IngredientsForRecipeForView>> GetIngredientsForRecipe(int id)
        {
          if (_context.IngredientsForRecipe == null)
          {
              return NotFound();
          }
            var ingredientsForRecipe = await _context.IngredientsForRecipe.Include(x => x.Recipe).Include(x => x.Ingredient).FirstOrDefaultAsync(i => i.Id == id);

            if (ingredientsForRecipe == null)
            {
                return NotFound();
            }
            IngredientsForRecipeForView c = new IngredientsForRecipeForView();
            c.CopyProperties(ingredientsForRecipe);
            return c;
        }

        // PUT: api/IngredientsForRecipes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutIngredientsForRecipe(int id, IngredientsForRecipeForView ingredientsForRecipe)
        {
            if (id != ingredientsForRecipe.Id)
            {
                return BadRequest();
            }

            var ingredientsForRecipeToModify = _context.IngredientsForRecipe.Find(id);
            if (ingredientsForRecipeToModify == null)
            {
                return BadRequest();
            }
            ingredientsForRecipeToModify.CopyProperties(ingredientsForRecipe);
            _context.Entry(ingredientsForRecipeToModify).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IngredientsForRecipeExists(id))
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

        // POST: api/IngredientsForRecipes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<IngredientsForRecipe>> PostIngredientsForRecipe(IngredientsForRecipeForView ingredientsForRecipe)
        {
          if (_context.IngredientsForRecipe == null)
          {
              return Problem("Entity set 'FoodBookContext.IngredientsForRecipe'  is null.");
          }
            await IngredientsForRecipeB.ConvertIngredientsForRecipeForViewToIngredientsForRecipe(ingredientsForRecipe, _context);
            await _context.SaveChangesAsync();

            return Ok(ingredientsForRecipe);
        }

        // DELETE: api/IngredientsForRecipes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteIngredientsForRecipe(int id)
        {
            if (_context.IngredientsForRecipe == null)
            {
                return NotFound();
            }
            var ingredientsForRecipe = await _context.IngredientsForRecipe.FindAsync(id);
            if (ingredientsForRecipe == null)
            {
                return NotFound();
            }

            ingredientsForRecipe.IsActive = false;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool IngredientsForRecipeExists(int id)
        {
            return (_context.IngredientsForRecipe?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
