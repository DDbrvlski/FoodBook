using FoodBook.Service.Reference;
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
    public partial class NewCuisineTypePage : ContentPage
    {
        public CuisineType Item { get; set; }
        public NewCuisineTypePage()
        {
            InitializeComponent();
            BindingContext = new NewCuisineTypeViewModel();
        }
    }
}