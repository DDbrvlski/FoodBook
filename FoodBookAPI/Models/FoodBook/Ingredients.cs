using FoodBookAPI.Models.Helpers;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodBookAPI.Models.FoodBook
{
    public class Ingredients : BaseEntity
    {
        [Display(Name = "Kalorie")]
        public float Kcal { get; set; }

        [Display(Name = "Tłuszcze")]
        public float Fats { get; set; }

        [Display(Name = "Białko")]
        public float Proteins { get; set; }

        [Display(Name = "Sól")]
        public float Salt { get; set; }

        [Display(Name = "Cukier")]
        public float Sugar { get; set; }

        [Display(Name = "Węglowodany")]
        public float Carbs { get; set; }

        [Display(Name = "Ilość dla jednostki miary")]
        public float AmountOfUnit { get; set; }

        //Jednostka miary
        [Display(Name = "Jednostka miary")] 
        public int? IdUnitOfMeasurement { get; set; }
        [ForeignKey("IdUnitOfMeasurement")]
        public virtual UnitsOfMeasurement UnitOfMeasurement { get; set; }

    }
}
