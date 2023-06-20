using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FoodBookAPI.Models.FoodBook;
using FoodBookAPI.Models.Media;

namespace FoodBookAPI.Data
{
    public class FoodBookContext : DbContext
    {
        public FoodBookContext (DbContextOptions<FoodBookContext> options)
            : base(options)
        {

        }
        //Media
        public DbSet<Images> Images { get; set; }

        //FoodBook
        public DbSet<CuisineType> CuisineType { get; set; }
        public DbSet<Difficulty> Difficulty { get; set; }
        public DbSet<DishType> DishType { get; set; }
        public DbSet<Ingredients> Ingredients { get; set; }
        public DbSet<Recipes> Recipes { get; set; }
        public DbSet<RecipeSteps> RecipeSteps { get; set; }
        public DbSet<UnitsOfMeasurement> UnitsOfMeasurement { get; set; }
        public DbSet<IngredientsForRecipe> IngredientsForRecipe { get; set; }

    }
}
