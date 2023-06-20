using FoodBook.ViewModels.DifficultyVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FoodBook.Views.DifficultyV
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DifficultyPage : ContentPage
    {
        private DifficultyViewModel _viewModel;
        public DifficultyPage()
        {
            InitializeComponent();
            BindingContext = _viewModel = new DifficultyViewModel();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }
    }
}