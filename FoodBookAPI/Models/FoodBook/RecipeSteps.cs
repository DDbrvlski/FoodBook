using FoodBookAPI.Models.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodBookAPI.Models.FoodBook
{
    public class RecipeSteps : BaseEntity
    {
        [Display(Name = "Opis")]
        public string Description { get; set; }

        [Display(Name = "Numer kroku")]
        public string Position { get; set; }

        //Przepis
        [Display(Name = "Przepis")]
        public int? IdRecipe { get; set; }
        [ForeignKey("IdRecipe")]
        public virtual Recipes Recipe { get; set; }
    }
}
