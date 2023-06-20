using FoodBook.ViewModels.ClientVM;
using FoodBook.ViewModels.CuisineTypeVM;
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
    public partial class CuisinesPage : ContentPage
    {
        private CuisinesViewModel _viewModel;
        public CuisinesPage()
        {
            InitializeComponent();
            BindingContext = _viewModel = new CuisinesViewModel();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }
    }
}