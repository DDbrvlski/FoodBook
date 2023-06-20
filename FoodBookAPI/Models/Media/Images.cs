using FoodBookAPI.Models.Helpers;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodBookAPI.Models.Media
{
    public class Images : BaseEntity
    {
        [Display(Name = "URL")]
        public string? Image { get; set; }
    }
}