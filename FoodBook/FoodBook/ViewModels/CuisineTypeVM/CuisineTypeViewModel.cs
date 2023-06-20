using FoodBook.Service.Reference;
using FoodBook.ViewModels.Abstract;
using FoodBook.Views.CuisineTypeV;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace FoodBook.ViewModels.CuisineTypeVM
{
    public class CuisineTypeViewModel : AListViewModel<CuisineTypeForView>
    {
        public CuisineTypeViewModel() : base("Cuisine type")
        {
        }

        public async override void OnItemSelected(CuisineTypeForView item)
        {
            if (item == null) return;
            await Shell.Current.GoToAsync($"{nameof(CuisineTypeDetailsPage)}?{nameof(CuisineTypeDetailsViewModel.ItemId)}={item.Id}");
        }
        public override async void GoToAddPage()
        {
            await Shell.Current.GoToAsync(nameof(NewCuisineTypePage));
        }
    }
}
