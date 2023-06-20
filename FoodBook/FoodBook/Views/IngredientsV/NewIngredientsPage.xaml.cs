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
    public partial class NewIngredientsPage : ContentPage
    {
        public Ingredients Item { get; set; }
        public NewIngredientsPage()
        {
            InitializeComponent();
            BindingContext = new NewIngredientsViewModel();
        }
    }
}