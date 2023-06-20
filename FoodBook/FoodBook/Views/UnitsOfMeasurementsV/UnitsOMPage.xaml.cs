using FoodBook.ViewModels.UnitsOfMeasurementsVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FoodBook.Views.UnitsOfMeasurementsV
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UnitsOMPage : ContentPage
    {
        private UnitsOMViewModel _viewModel;
        public UnitsOMPage()
        {
            InitializeComponent();
            BindingContext = _viewModel = new UnitsOMViewModel();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }
    }
}