using FoodBookAPI.Models;
using FoodBookAPI.Models.FoodBook;
using FoodBookAPI.Models.Helpers;
using System.Collections;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodBookAPI.ViewModel
{
	public class RecipeForView : BaseEntity
	{
		public int MakingTime { get; set; }
		public string? CuisineTypeTitle { get; set; }
		public int? IdCuisineType { get; set; }
		public string? DishTypeTitle { get; set; }
		public int? IdDishType { get; set; }
		public string? DifficultyName { get; set; }
		public int? IdDifficulty { get; set; }
		public string? ImageURL { get; set; }
		public string? ImageTitle { get; set; }
		public int? IdImage { get; set; }
        public List<RecipeStepsForView> RecipeStepsView { get; set; }
        public List<IngredientsForRecipeForView> IngredientsView { get; set; }

    }
}
