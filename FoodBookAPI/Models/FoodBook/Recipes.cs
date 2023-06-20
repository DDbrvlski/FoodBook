using FoodBookAPI.Models.Helpers;
using FoodBookAPI.Models.Media;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodBookAPI.Models.FoodBook
{
    public class Recipes : BaseEntity
    {
        [Display(Name = "Czas robienia w minutach")]
        public int MakingTime { get; set; }

        //Składniki
        public virtual ICollection<IngredientsForRecipe> IngredientsForRecipe { get; set; }

        //Kroki w przepisie
        public virtual ICollection<RecipeSteps> RecipeSteps { get; set; }

        //Rodzaj kuchni
        [Display(Name = "Kuchnia")]
        public int? IdCuisineType { get; set; }
        [ForeignKey("IdCuisineType")]
        public virtual CuisineType CuisineType { get; set; }

        //Rodzaj dania
        [Display(Name = "Rodzaj dania")]
        public int? IdDishType { get; set; }
        [ForeignKey("IdDishType")]
        public virtual DishType DishType { get; set; }

        //Trudność
        [Display(Name = "Trudność")]
        public int? IdDifficulty { get; set; }
        [ForeignKey("IdDifficulty")]
        public virtual Difficulty Difficulty { get; set; }

        //Zdjęcie
        [Display(Name = "Zdjęcie")]
        public int? IdImage { get; set; }
        [ForeignKey("IdImage")]
        public virtual Images Image { get; set; }
    }
}
