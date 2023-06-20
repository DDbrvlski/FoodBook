using FoodBook.ViewModels.UnitsOfMeasurementsVM;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FoodBook.Views.UnitsOfMeasurementsV
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UnitsOMDetailsPage : ContentPage
    {
        public UnitsOMDetailsPage()
        {
            InitializeComponent();
            BindingContext = new UnitsOMDetailsViewModel();
        }
    }
}