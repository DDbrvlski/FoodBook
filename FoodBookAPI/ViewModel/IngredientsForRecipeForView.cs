using FoodBookAPI.Models.FoodBook;

namespace FoodBookAPI.ViewModel
{
    public class IngredientsForRecipeForView
    {
        public int Id { get; set; }
        public float? AmountOfUnit { get; set; }
        public string? UnitTitle { get; set; }
        public string? Title { get; set; }
        public int? IdRecipe { get; set; }
        public int? IdIngredient { get; set; }
        public bool IsActive { get; set; }
        public float Kcal { get; set; }
        public float Fats { get; set; }
        public float Proteins { get; set; }
        public float Salt { get; set; }
        public float Sugar { get; set; }
        public float Carbs { get; set; }
    }
}
