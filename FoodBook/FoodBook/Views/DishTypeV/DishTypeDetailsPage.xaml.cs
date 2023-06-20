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
    public partial class DishTypeDetailsPage : ContentPage
    {
        private DishTypeViewModel _viewModel;

        public DishTypeDetailsPage()
        {
            InitializeComponent();
            BindingContext = new DishTypeDetailsViewModel();
        }     
    }
}