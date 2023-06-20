using FoodBook.Service.Reference;
using FoodBook.ViewModels.IngredientsVM;
using FoodBook.ViewModels.RecipesVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FoodBook.Views.RecipesV
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditRecipesPage : ContentPage
    {
        public RecipeForView Item { get; set; }
        public EditRecipesPage()
        {
            InitializeComponent();
            BindingContext = new EditRecipesViewModel();
        }
    }
}