using FoodBook.Service.Reference;
using FoodBook.ViewModels.Abstract;
using FoodBook.ViewModels.RecipesVM;
using FoodBook.Views.RecipesV;
using Xamarin.Forms;

namespace FoodBook.ViewModels.RecipesVM
{
	public class RecipesViewModel : AListViewModel<RecipeForView>
	{
		public RecipesViewModel() : base("Recipes")
		{
		}

		public async override void OnItemSelected(RecipeForView item)
		{
			if (item == null) return;
			await Shell.Current.GoToAsync($"{nameof(RecipesDetailsPage)}?{nameof(RecipesDetailsViewModel.ItemId)}={item.Id}");
		}
		public override async void GoToAddPage()
		{
			await Shell.Current.GoToAsync(nameof(NewRecipesPage));
		}
	}


}
