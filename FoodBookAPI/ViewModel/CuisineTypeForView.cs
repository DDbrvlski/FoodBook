using FoodBookAPI.Models;
using FoodBookAPI.Models.Helpers;
using System.Collections;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodBookAPI.ViewModel
{
	public class CuisineTypeForView : DictionaryTable
	{
		public string? ImageURL { get; set; }
		public int? IdImage { get; set; }
		public string? ImageTitle { get; set; }

	}
}
