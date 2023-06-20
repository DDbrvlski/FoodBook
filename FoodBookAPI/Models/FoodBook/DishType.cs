using FoodBookAPI.Models.Helpers;
using FoodBookAPI.Models.Media;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodBookAPI.Models.FoodBook
{
    public class DishType : DictionaryTable
    {
        //Zdjęcie
        [Display(Name = "Zdjęcie")]
        public int? IdImage { get; set; }
        [ForeignKey("IdImage")]
        public virtual Images? Image { get; set; }
    }
}
