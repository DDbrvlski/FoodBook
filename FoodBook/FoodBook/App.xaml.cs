using FoodBook.Services;
using Xamarin.Forms;

namespace FoodBook
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();
            DependencyService.Register<DifficultyDataStore>();
            DependencyService.Register<CuisineTypeDataStore>();
            DependencyService.Register<DishTypeDataStore>();
            DependencyService.Register<IngredientsDataStore>();
            DependencyService.Register<IngredientsForRecipeDataStore>();
            DependencyService.Register<RecipesDataStore>();
            DependencyService.Register<UnitsOfMeasurementsDataStore>();
            DependencyService.Register<RecipeStepsDataStore>();
            DependencyService.Register<ImagesDataStore>();

            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
