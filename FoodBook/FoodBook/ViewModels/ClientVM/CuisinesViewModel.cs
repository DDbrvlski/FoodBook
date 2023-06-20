using FoodBook.Service.Reference;
using FoodBook.ViewModels.Abstract;
using FoodBook.Views.ClientV;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace FoodBook.ViewModels.ClientVM
{
    public class CuisinesViewModel : AListViewModel<CuisineTypeForView>
    {
        public CuisinesViewModel() : base("")
        {
        }

        public async override void OnItemSelected(CuisineTypeForView item)
        {
            if (item == null) return;
            await Shell.Current.GoToAsync($"{nameof(RecipeForCuisinePage)}?{nameof(RecipeForCuisineViewModel.ItemId)}={item.Id}");
        }
        public override async void GoToAddPage()
        {
        }

    }
}
