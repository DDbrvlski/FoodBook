using FoodBook.ViewModels.ClientVM;
using FoodBook.ViewModels.RecipesVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FoodBook.Views.ClientV.CustomControll
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LatestRecipesCustomControl : ContentView
    {
        private RecipeForAboutPageViewModel _viewModel;
        public LatestRecipesCustomControl()
        {
            InitializeComponent();
            BindingContext = _viewModel = new RecipeForAboutPageViewModel();
            _viewModel.OnAppearing();
        }
    }
}