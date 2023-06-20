using FoodBookAPI.Data;
using FoodBookAPI.Helpers;
using FoodBookAPI.Models.FoodBook;
using FoodBookAPI.ViewModel;

namespace FoodBookAPI.Models.BusinessLogic
{
    public class IngredientsForRecipeB
    {

        public static async Task ConvertIngredientsForRecipeForViewToIngredientsForRecipe(IngredientsForRecipeForView ingridient, FoodBookContext _context)
        {
            var ingredientToAdd = new IngredientsForRecipe().CopyProperties(ingridient);
            ingredientToAdd.IsActive = true;
            _context.IngredientsForRecipe.Add(ingredientToAdd);
            await _context.SaveChangesAsync();
        }
    }
}
