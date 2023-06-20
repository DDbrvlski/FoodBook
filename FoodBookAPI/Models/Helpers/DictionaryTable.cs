using System.ComponentModel.DataAnnotations;

namespace FoodBookAPI.Models.Helpers
{
    public class DictionaryTable
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
