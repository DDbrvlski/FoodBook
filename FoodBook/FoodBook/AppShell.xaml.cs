using FoodBook.Views;
using FoodBook.Views.ClientV;
using FoodBook.Views.CuisineTypeV;
using FoodBook.Views.DifficultyV;
using FoodBook.Views.DishTypeV;
using FoodBook.Views.IngredientsV;
using FoodBook.Views.RecipesV;
using FoodBook.Views.UnitsOfMeasurementsV;
using System;
using Xamarin.Forms;

namespace FoodBook
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            //Difficulty
            Routing.RegisterRoute(nameof(NewDifficultyPage), typeof(NewDifficultyPage));
            Routing.RegisterRoute(nameof(DifficultyDetailsPage), typeof(DifficultyDetailsPage));
            Routing.RegisterRoute(nameof(EditDifficultyPage), typeof(EditDifficultyPage));
            //UnitsOfMeasurement
            Routing.RegisterRoute(nameof(NewUnitsOMPage), typeof(NewUnitsOMPage));
            Routing.RegisterRoute(nameof(UnitsOMDetailsPage), typeof(UnitsOMDetailsPage));
            Routing.RegisterRoute(nameof(EditUnitsOMPage), typeof(EditUnitsOMPage));
            //CuisineType
            Routing.RegisterRoute(nameof(NewCuisineTypePage), typeof(NewCuisineTypePage));
            Routing.RegisterRoute(nameof(CuisineTypeDetailsPage), typeof(CuisineTypeDetailsPage));
            Routing.RegisterRoute(nameof(EditCuisineTypePage), typeof(EditCuisineTypePage));
            Routing.RegisterRoute(nameof(CuisineTypePage), typeof(CuisineTypePage));
            //DishType
            Routing.RegisterRoute(nameof(NewDishTypePage), typeof(NewDishTypePage));
            Routing.RegisterRoute(nameof(DishTypeDetailsPage), typeof(DishTypeDetailsPage));
            Routing.RegisterRoute(nameof(EditDishTypePage), typeof(EditDishTypePage));
            //Ingredients
            Routing.RegisterRoute(nameof(NewIngredientsPage), typeof(NewIngredientsPage));
            Routing.RegisterRoute(nameof(IngredientsDetailsPage), typeof(IngredientsDetailsPage));
            Routing.RegisterRoute(nameof(EditIngredientsPage), typeof(EditIngredientsPage));
            //Recipes
            Routing.RegisterRoute(nameof(NewRecipesPage), typeof(NewRecipesPage));
            Routing.RegisterRoute(nameof(RecipesDetailsPage), typeof(RecipesDetailsPage));
            Routing.RegisterRoute(nameof(EditRecipesPage), typeof(EditRecipesPage));
            //Client Views
            Routing.RegisterRoute(nameof(AboutPage), typeof(AboutPage));
            Routing.RegisterRoute(nameof(RecipePage), typeof(RecipePage));
            Routing.RegisterRoute(nameof(CuisinesPage), typeof(CuisinesPage));
            Routing.RegisterRoute(nameof(RecipeForCuisinePage), typeof(RecipeForCuisinePage));
            Routing.RegisterRoute(nameof(DishesPage), typeof(DishesPage));
            Routing.RegisterRoute(nameof(RecipeForDishPage), typeof(RecipeForDishPage));
            Routing.RegisterRoute(nameof(RecipeDetailsForClientPage), typeof(RecipeDetailsForClientPage));
        }

        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//LoginPage");
        }
    }
}
