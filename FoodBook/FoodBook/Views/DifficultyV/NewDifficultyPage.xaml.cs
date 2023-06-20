using FoodBook.Service.Reference;
using FoodBook.ViewModels.DifficultyVM;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FoodBook.Views.DifficultyV
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewDifficultyPage : ContentPage
    {
        public Difficulty Item { get; set; }
        public NewDifficultyPage()
        {
            InitializeComponent();
            BindingContext = new NewDifficultyViewModel();
        }
    }
}