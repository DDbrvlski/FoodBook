using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodBookAPI.Models.FoodBook
{
    public class IngredientsForRecipe
    {
        [Key]
        public int Id { get; set; }

        //Ile
        [Display(Name = "Ile")]
        public float Amount { get; set; }

        //Produkt
        [Display(Name = "Produkt")]
        public int? IdIngredient { get; set; }
        [ForeignKey("IdIngredient")]
        public virtual Ingredients Ingredient { get; set; }

        //Przepis
        [Display(Name = "Przepis")]
        public int? IdRecipe { get; set; }
        [ForeignKey("IdRecipe")]
        public virtual Recipes Recipe { get; set; }

        public bool IsActive { get; set; }
    }
}
