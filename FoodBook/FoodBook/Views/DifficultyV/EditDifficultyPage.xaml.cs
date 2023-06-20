using FoodBook.Service.Reference;
using FoodBook.ViewModels.DifficultyVM;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FoodBook.Views.DifficultyV
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditDifficultyPage : ContentPage
    {
        public Difficulty Item { get; set; }
        public EditDifficultyPage()
        {
            InitializeComponent();
            BindingContext = new EditUnitsOMViewModel();
        }
    }
}