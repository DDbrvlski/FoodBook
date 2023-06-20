using FoodBook.Service.Reference;
using FoodBook.ViewModels.UnitsOfMeasurementsVM;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FoodBook.Views.UnitsOfMeasurementsV
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewUnitsOMPage : ContentPage
    {
        public UnitsOfMeasurement Item { get; set; }
        public NewUnitsOMPage()
        {
            InitializeComponent();
            BindingContext = new NewUnitsOMViewModel();
        }
    }
}