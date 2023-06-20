using FoodBookAPI.Data;
using FoodBookAPI.Helpers;
using FoodBookAPI.Models.FoodBook;
using FoodBookAPI.Models.Media;
using FoodBookAPI.ViewModel;

namespace FoodBookAPI.Models.BusinessLogic
{
    public class IngredientsB
    {
        public static async Task ConvertIngredientsForViewToIngredientsAndSave(IngredientsForView ingridient, FoodBookContext _context)
        {
            var ingridientToAdd = new Ingredients().CopyProperties(ingridient);
            ingridientToAdd.IsActive = true;
            _context.Ingredients.Add(ingridientToAdd);
            await _context.SaveChangesAsync();
        }
    }
}
