using FoodBook.Service.Reference;
using FoodBook.ViewModels.UnitsOfMeasurementsVM;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FoodBook.Views.UnitsOfMeasurementsV
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditUnitsOMPage : ContentPage
    {
        public UnitsOfMeasurement Item { get; set; }
        public EditUnitsOMPage()
        {
            InitializeComponent();
            BindingContext = new EditUnitsOMViewModel();
        }
    }
}