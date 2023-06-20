using FoodBook.Service.Reference;
using FoodBook.ViewModels.Abstract;
using FoodBook.Views.ClientV;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace FoodBook.ViewModels.ClientVM
{
    public class DishesViewModel : AListViewModel<DishTypeForView>
    {
        public DishesViewModel() : base("")
        {
        }

        public async override void OnItemSelected(DishTypeForView item)
        {
            if (item == null) return;
            await Shell.Current.GoToAsync($"{nameof(RecipeForDishPage)}?{nameof(RecipeForDishViewModel.ItemId)}={item.Id}");
        }
        public override async void GoToAddPage()
        {
        }

    }
}
