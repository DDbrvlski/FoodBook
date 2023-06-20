using FoodBookAPI.Data;
using FoodBookAPI.Helpers;
using FoodBookAPI.Models.FoodBook;
using FoodBookAPI.Models.Media;
using FoodBookAPI.ViewModel;

namespace FoodBookAPI.Models.BusinessLogic
{
    public class RecipeStepsB
    {
        public static async Task ConvertRecipeStepsForViewToRecipeStepsAndSave(RecipeStepsForView recipeSteps, FoodBookContext _context)
        {
            var recipeStepsToAdd = new RecipeSteps().CopyProperties(recipeSteps);
            recipeStepsToAdd.IsActive = true;
            _context.RecipeSteps.Add(recipeStepsToAdd);
            await _context.SaveChangesAsync();
        }
    }
}
