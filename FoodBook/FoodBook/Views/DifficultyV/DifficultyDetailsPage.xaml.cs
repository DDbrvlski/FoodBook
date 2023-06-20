using FoodBook.ViewModels.DifficultyVM;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FoodBook.Views.DifficultyV
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DifficultyDetailsPage : ContentPage
    {
        public DifficultyDetailsPage()
        {
            InitializeComponent();
            BindingContext = new DifficultyDetailsViewModel();
        }
    }
}