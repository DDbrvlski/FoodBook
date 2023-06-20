using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodBookAPI.Models.Helpers
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Nazwa")]
        public string Title { get; set; }

        [Display(Name = "Data dodania")]
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        [Display(Name = "Data zmodyfikowania")]
        public DateTime ModifiedDate { get; set; } = DateTime.Now;

        [Display(Name = "Czy aktywny?")]
        public bool IsActive { get; set; } = true;
    }
}
