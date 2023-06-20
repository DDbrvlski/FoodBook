using FoodBook.ViewModels.CuisineTypeVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FoodBook.Views.CuisineTypeV
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CuisineTypePage : ContentPage
    {
        private CuisineTypeViewModel _viewModel;
        public CuisineTypePage()
        {
            InitializeComponent();
            BindingContext = _viewModel = new CuisineTypeViewModel();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }
    }
}