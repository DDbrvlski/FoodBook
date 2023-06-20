using FoodBookAPI.ViewModel;
using FoodBookAPI.Data;
using FoodBookAPI.Helpers;
using FoodBookAPI.Models.FoodBook;
using FoodBookAPI.Models.Media;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace FoodBookAPI.Models
{
	public static class RecipesB
	{
		public static async Task ConvertRecipeForViewToRecipesAndSave(RecipeForView recipe, FoodBookContext _context)
		{
			var recipeToAdd = new Recipes().CopyProperties(recipe);
            recipeToAdd.IsActive = true;
            //Adding new image
            if (recipeToAdd.IdImage == 0 || recipe.IdImage == null)
			{
                var imageToAdd = new Images
                {
                    Title = recipe.ImageTitle,
                    Image = recipe.ImageURL,
                    CreatedDate = DateTime.Now,
                    IsActive = true,
                    ModifiedDate = DateTime.Now,
                };
                _context.Images.Add(imageToAdd);
                await _context.SaveChangesAsync();
                recipeToAdd.IdImage = imageToAdd.Id;
            }
			_context.Recipes.Add(recipeToAdd);
			await _context.SaveChangesAsync();
            int recipeid = recipeToAdd.Id;
            //Adding new recipe steps
            foreach (var item in recipe.RecipeStepsView)
            {
                RecipeSteps newStep = new RecipeSteps().CopyProperties(item);
				newStep.IdRecipe = recipeid;
                newStep.IsActive = true;
                _context.RecipeSteps.Add(newStep);
            }
            //Adding new ingredinets in recipe
			foreach(var item in recipe.IngredientsView)
			{
				IngredientsForRecipe newIngredient = new IngredientsForRecipe().CopyProperties(item);
				newIngredient.IdRecipe = recipeid;
                newIngredient.IsActive = true;
				newIngredient.Amount = (float)item.AmountOfUnit;
				_context.IngredientsForRecipe.Add(newIngredient);
			}
            await _context.SaveChangesAsync();

        }
		public static async Task EditAndConvertRecipeForViewToRecipesAndSave(Recipes recipe, RecipeForView recipefv, FoodBookContext _context)
        {
            recipe.CopyProperties(recipefv);
            recipe.IsActive = true;
            _context.Entry(recipe).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            int recipeid = recipe.Id;

            var oldRecipeSteps = await _context.RecipeSteps.Where(x => x.IdRecipe == recipeid).Where(x => x.IsActive == true).ToListAsync();
            var oldIngredients = await _context.IngredientsForRecipe.Where(x => x.IdRecipe == recipeid).Where(x => x.IsActive == true).ToListAsync();

            foreach (var item in oldIngredients)
            {
                _context.IngredientsForRecipe.Remove(item);
            }
            foreach (var item in oldRecipeSteps)
            {
                _context.RecipeSteps.Remove(item);
            }
            await _context.SaveChangesAsync();

            foreach (var item in recipefv.RecipeStepsView)
            {
                RecipeSteps newStep = new RecipeSteps().CopyProperties(item);
                newStep.IdRecipe = recipeid;
                newStep.IsActive = true;
                _context.RecipeSteps.Add(newStep);
            }
            foreach (var item in recipefv.IngredientsView)
            {
                IngredientsForRecipe newIngredient = new IngredientsForRecipe().CopyProperties(item);
                newIngredient.IdRecipe = recipeid;
                newIngredient.IsActive = true;
                newIngredient.Amount = (float)item.AmountOfUnit;
                newIngredient.IdIngredient = (int)item.IdIngredient;
                _context.IngredientsForRecipe.Add(newIngredient);
            }
            await _context.SaveChangesAsync();

        }

        public static async Task<List<RecipeStepsForView>> GetAllStepsForRecipe(int id, FoodBookContext _context)
		{
            var listOfSteps = _context.RecipeSteps.Where(x => x.IdRecipe == id).Where(x => x.IsActive == true).ToList();
			List<RecipeStepsForView> list = new List<RecipeStepsForView>();
			foreach (var step in listOfSteps)
			{
				list.Add(new RecipeStepsForView { IsActive = true }.CopyProperties(step));
			}
			return list;
        }
        public static async Task<List<IngredientsForRecipeForView>> GetAllIngredientsForRecipe(int id, FoodBookContext _context)
        {
            try
            {
                var listOfIngredients = _context.IngredientsForRecipe.Where(x => x.IdRecipe == id).Where(x => x.IsActive == true).Include(x => x.Ingredient).Include(x => x.Ingredient.UnitOfMeasurement).ToList();
                List<IngredientsForRecipeForView> list = new List<IngredientsForRecipeForView>();
				foreach (var item in listOfIngredients)
				{
					list.Add(new IngredientsForRecipeForView { 
                        AmountOfUnit = item.Amount, 
                        IsActive = true, 
                        Carbs = item.Ingredient.Carbs, 
                        Fats = item.Ingredient.Fats,
                        Sugar = item.Ingredient.Sugar,
                        Proteins = item.Ingredient.Proteins,
                        Kcal = item.Ingredient.Kcal,
                        Salt = item.Ingredient.Salt,
                        UnitTitle = item.Ingredient.UnitOfMeasurement.Title,
                        Title = item.Ingredient.Title,
                    }.CopyProperties(item));
				}
				return list;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
    }
}
