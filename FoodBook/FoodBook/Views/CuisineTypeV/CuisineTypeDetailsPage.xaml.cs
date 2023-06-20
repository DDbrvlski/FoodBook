using FoodBook.ViewModels.CuisineTypeVM;
using FoodBook.ViewModels.DishTypeVM;
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
    public partial class CuisineTypeDetailsPage : ContentPage
    {
        private CuisineTypeDetailsViewModel _viewModel;

        public CuisineTypeDetailsPage()
        {
            InitializeComponent();
            BindingContext = new CuisineTypeDetailsViewModel();
        }
    }
}