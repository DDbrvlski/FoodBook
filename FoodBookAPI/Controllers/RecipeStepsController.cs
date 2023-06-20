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
    public class RecipeStepsController : ControllerBase
    {
        private readonly FoodBookContext _context;

        public RecipeStepsController(FoodBookContext context)
        {
            _context = context;
        }

        // GET: api/RecipeSteps
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RecipeStepsForView>>> GetRecipeSteps()
        {
          if (_context.RecipeSteps == null)
          {
              return NotFound();
          }
            var items = await _context.RecipeSteps.Where(x => x.IsActive == true).ToListAsync();
            var result = items.Select(sl => new RecipeStepsForView { IdRecipe = sl?.Recipe.Id }.CopyProperties(sl)).ToList();
            return result;
        }

        // GET: api/RecipeSteps/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RecipeStepsForView>> GetRecipeSteps(int id)
        {
          if (_context.RecipeSteps == null)
          {
              return NotFound();
          }
            var recipeSteps = await _context.RecipeSteps.FindAsync(id);

            if (recipeSteps == null)
            {
                return NotFound();
            }
            RecipeStepsForView c = new RecipeStepsForView();
            c.IdRecipe = recipeSteps?.Recipe?.Id;
            c.CopyProperties(recipeSteps);
            return c;
        }

        // PUT: api/RecipeSteps/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRecipeSteps(int id, RecipeStepsForView recipeSteps)
        {
            if (id != recipeSteps.Id)
            {
                return BadRequest();
            }
            var recipeStepsToModify = _context.RecipeSteps.Find(id);
            if (recipeStepsToModify == null)
            {
                return BadRequest();
            }
            recipeStepsToModify.CopyProperties(recipeSteps);
            _context.Entry(recipeStepsToModify).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RecipeStepsExists(id))
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

        // POST: api/RecipeSteps
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<RecipeStepsForView>> PostRecipeSteps(RecipeStepsForView newRecipeSteps)
        {
          if (_context.RecipeSteps == null)
          {
              return Problem("Entity set 'FoodBookContext.RecipeSteps'  is null.");
          }
			#region NewShit
			//takie cos wykminilem, ciekawe ile bledow tu wywali... ;c 
			//List<RecipeStepsForView> newRecipeSteps = new List<RecipeStepsForView>();

			//foreach (var step in newRecipeSteps)
			//{
			//	var newStep = new RecipeStepsForView
			//	{
			//		Description = step.Description,
			//		Position = step.Position,
			//		IdRecipe = step.IdRecipe //Pewnie bedzie problem z podstawianiem tego Id 
			//	};

			//	newRecipeSteps.Add(newStep);
			//}

			#endregion
			await RecipeStepsB.ConvertRecipeStepsForViewToRecipeStepsAndSave(newRecipeSteps, _context);// trzeba by odkomentować zapisywanie w wersji AddRange  w RecipeStepsB a tu zmienic na newRecipeSteps
			return Ok(newRecipeSteps);
        }

        // DELETE: api/RecipeSteps/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRecipeSteps(int id)
        {
            if (_context.RecipeSteps == null)
            {
                return NotFound();
            }
            var recipeSteps = await _context.RecipeSteps.FindAsync(id);
            if (recipeSteps == null)
            {
                return NotFound();
            }

            recipeSteps.IsActive = false;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RecipeStepsExists(int id)
        {
            return (_context.RecipeSteps?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
