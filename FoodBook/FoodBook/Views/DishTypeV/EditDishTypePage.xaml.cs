using FoodBook.Service.Reference;
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
    public partial class EditDishTypePage : ContentPage
    {
        public DishTypeForView Item { get; set; }
        public EditDishTypePage()
        {
            InitializeComponent();
            BindingContext = new EditDishTypeViewModel();
        }
    }
}