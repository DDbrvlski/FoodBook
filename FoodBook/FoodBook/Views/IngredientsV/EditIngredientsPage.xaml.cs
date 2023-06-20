using FoodBook.Service.Reference;
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
    public partial class EditIngredientsPage : ContentPage
    {
        public Ingredients Item { get; set; }
        public EditIngredientsPage()
        {
            InitializeComponent();
            BindingContext = new EditIngredientsViewModel();
        }
    }
}