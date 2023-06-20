using FoodBook.ViewModels.ClientVM;
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
    public partial class RecipeForCuisinePage : ContentPage
    {
        public RecipeForCuisinePage()
        {
            InitializeComponent();
            BindingContext = new RecipeForCuisineViewModel();
        }
    }
}