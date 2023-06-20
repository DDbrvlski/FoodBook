using FoodBookAPI.Models.Helpers;

namespace FoodBookAPI.ViewModel
{
    public class DishTypeForView : DictionaryTable
    {
        public string? ImageURL { get; set; }
        public int? IdImage { get; set; }
        public string? ImageTitle { get; set; }
    }
}
