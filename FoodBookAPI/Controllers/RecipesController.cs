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
using FoodBookAPI.Models;

namespace FoodBookAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipesController : ControllerBase
    {
        private readonly FoodBookContext _context;

        public RecipesController(FoodBookContext context)
        {
            _context = context;
        }

        // GET: api/Recipes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RecipeForView>>> GetRecipes()
        {
          if (_context.Recipes == null)
          {
              return NotFound();
          }
            var recipeList = await _context.Recipes.Include(x => x.Difficulty).Include(x => x.CuisineType).Include(x => x.DishType).Include(x => x.Image).Where(x => x.IsActive == true).ToListAsync();

            var result = recipeList.Select(recipe => new RecipeForView{CuisineTypeTitle = recipe.CuisineType.Title, DishTypeTitle = recipe.DishType.Title, DifficultyName = recipe.Difficulty.Title, ImageURL = recipe.Image.Image, ImageTitle = recipe.Image.Title}.CopyProperties(recipe)).ToList();
            return result;
        }

        // GET: api/Recipes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RecipeForView>> GetRecipes(int id)
        {
          if (_context.Recipes == null)
          {
              return NotFound();
          }
            var recipes = await _context.Recipes.Include(x => x.CuisineType).Include(x => x.DishType).Include(x => x.Difficulty).Include(x => x.Image).FirstOrDefaultAsync(i => i.Id == id);

            if (recipes == null)
            {
                return NotFound();
            }
            var item = new RecipeForView { CuisineTypeTitle = recipes.CuisineType.Title, DishTypeTitle = recipes.DishType.Title, DifficultyName = recipes.Difficulty.Title, ImageURL = recipes.Image.Image, ImageTitle = recipes.Image.Title, RecipeStepsView = await RecipesB.GetAllStepsForRecipe(id, _context), IngredientsView = await RecipesB.GetAllIngredientsForRecipe(id, _context)}.CopyProperties(recipes);
            return item;
        }

        // PUT: api/Recipes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRecipes(int id, RecipeForView recipes)
        {
            if (id != recipes.Id)
            {
                return BadRequest();
            }

           //_context.Entry(recipes).State = EntityState.Modified;
           var recipeToModify = _context.Recipes.Find(id);
            if(recipeToModify == null)
            {
                return BadRequest();
            }
            await RecipesB.EditAndConvertRecipeForViewToRecipesAndSave(recipeToModify, recipes, _context);
          
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RecipesExists(id))
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

        // POST: api/Recipes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<RecipeForView>> PostRecipes(RecipeForView recipes)
        {
          if (_context.Recipes == null)
          {
              return Problem("Entity set 'FoodBookContext.Recipes'  is null.");
          }
			if (_context.CuisineType == null)
			{
				return Problem("Entity set 'FoodBookContext.CuisineType'  is null.");
			}
			if (_context.DishType == null)
			{
				return Problem("Entity set 'FoodBookContext.DishType'  is null.");
			}
			if (_context.Difficulty == null)
			{
				return Problem("Entity set 'FoodBookContext.Difficulty'  is null.");
			}
			if (_context.Images == null)
			{
				return Problem("Entity set 'FoodBookContext.Images'  is null.");
			}
			if (recipes == null)
			{
                return BadRequest();
			}
            //_context.Recipes.Add(recipes);
            //await _context.SaveChangesAsync();
            await RecipesB.ConvertRecipeForViewToRecipesAndSave(recipes, _context);

            return Ok(recipes);
        }

        // DELETE: api/Recipes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRecipes(int id)
        {
            if (_context.Recipes == null)
            {
                return NotFound();
            }
            var recipes = await _context.Recipes.FindAsync(id);
            if (recipes == null)
            {
                return NotFound();
            }

            recipes.IsActive = false;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RecipesExists(int id)
        {
            return (_context.Recipes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
