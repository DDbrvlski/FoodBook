using FoodBook.ViewModels.DishTypeVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FoodBook.Views.DishTypeV
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DishTypePage : ContentPage
    {
        private DishTypeViewModel _viewModel;
        public DishTypePage()
        {
            InitializeComponent();
            BindingContext = _viewModel = new DishTypeViewModel();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }
    }
}