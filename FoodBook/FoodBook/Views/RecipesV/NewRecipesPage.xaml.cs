using FoodBook.Service.Reference;
using FoodBook.ViewModels.DifficultyVM;
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
    public partial class NewRecipesPage : ContentPage
    {
        public Recipes Item { get; set; }
        public NewRecipesPage()
        {
            InitializeComponent();
			BindingContext = new NewRecipesViewModel();
		}
        
    }
}