using FoodBook.ViewModels.RecipesVM;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FoodBook.Views.RecipesV
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RecipesPage : ContentPage
    {
		private RecipesViewModel _viewModel;
		public RecipesPage()
		{
			InitializeComponent();
			BindingContext = _viewModel = new RecipesViewModel();
		}
		protected override void OnAppearing()
		{
			base.OnAppearing();
			_viewModel.OnAppearing();
		}
	}
}