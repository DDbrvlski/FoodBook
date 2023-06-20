using FoodBookAPI.Models.Helpers;

namespace FoodBookAPI.ViewModel
{
    public class IngredientsForView : BaseEntity
    {
        public float Kcal { get; set; }
        public float Fats { get; set; }
        public float Proteins { get; set; }
        public float Salt { get; set; }
        public float Sugar { get; set; }
        public float Carbs { get; set; }
        public float AmountOfUnit { get; set; }
		public int? IdUnitOfMeasurement { get; set; }
        public string? UnitTitle { get; set; }

    }
}
