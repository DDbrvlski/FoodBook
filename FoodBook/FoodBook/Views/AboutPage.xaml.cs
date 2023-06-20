using FoodBook.ViewModels.Abstract;
using FoodBook.ViewModels.ClientVM;
using FoodBook.ViewModels.DishTypeVM;
using FoodBook.Views.ClientV.CustomControll;
using Xamarin.Forms;

namespace FoodBook.Views
{
	public partial class AboutPage : ContentPage
	{
		private DishTypeViewModel _viewmodel;
		public AboutPage()
		{
			InitializeComponent();
			BindingContext = _viewmodel = new DishTypeViewModel();
		}
		protected override void OnAppearing()
		{
			base.OnAppearing();
			_viewmodel.OnAppearing();
		}
	}
}