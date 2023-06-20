using FoodBook.ViewModels.Abstract;
using FoodBook.ViewModels.ClientVM;
using FoodBook.ViewModels.DishTypeVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FoodBook.Views.ClientV
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RecipePage : ContentPage
    {
        private RecipeForClientViewModel _viewModel;
        public RecipePage()
        {
            InitializeComponent();
            BindingContext = _viewModel = new RecipeForClientViewModel();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }
    }
}