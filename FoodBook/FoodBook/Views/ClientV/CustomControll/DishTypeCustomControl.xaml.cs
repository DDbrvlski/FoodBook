using FoodBook.ViewModels.ClientVM;
using FoodBook.ViewModels.DishTypeVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FoodBook.Views.ClientV.CustomControll
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class DishTypeCustomControl : ContentView
	{
		private DishesViewModel _viewModel;
		public DishTypeCustomControl()
		{

			InitializeComponent();
			BindingContext = _viewModel = new DishesViewModel();
			_viewModel.OnAppearing();
		}
		//protected override void OnAppearing()
		//{
		//	base.OnAppearing();
		//	_viewModel.OnAppearing();
		//}
	}
}