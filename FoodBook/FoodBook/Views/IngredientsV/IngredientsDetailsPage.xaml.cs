using FoodBook.ViewModels.IngredientsVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FoodBook.Views.IngredientsV
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class IngredientsDetailsPage : ContentPage
    {
        public IngredientsDetailsPage()
        {
            InitializeComponent();
            BindingContext = new IngredientsDetailsViewModel();
        }
    }
}