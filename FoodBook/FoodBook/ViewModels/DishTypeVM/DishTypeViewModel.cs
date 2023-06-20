using FoodBook.Service.Reference;
using FoodBook.ViewModels.Abstract;
using FoodBook.Views.DishTypeV;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace FoodBook.ViewModels.DishTypeVM
{
    public class DishTypeViewModel : AListViewModel<DishTypeForView>
    {
        public DishTypeViewModel() : base("Dish type")
        {
        }

        public async override void OnItemSelected(DishTypeForView item)
        {
            if (item == null) return;
            await Shell.Current.GoToAsync($"{nameof(DishTypeDetailsPage)}?{nameof(DishTypeDetailsViewModel.ItemId)}={item.Id}");
        }
        public override async void GoToAddPage()
        {
            await Shell.Current.GoToAsync(nameof(NewDishTypePage));
        }
    }
}
