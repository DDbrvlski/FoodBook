using FoodBookAPI.Models.Helpers;

namespace FoodBookAPI.ViewModel
{
    public class RecipeStepsForView : BaseEntity
    {
        public string? Description { get; set; }
        public string? Position { get; set; }
        public int? IdRecipe { get; set; }
    }
}
