using FoodBook.Service.Reference;
using FoodBook.ViewModels.Abstract;
using FoodBook.Views.IngredientsV;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace FoodBook.ViewModels.IngredientsVM
{
    public class IngredientsViewModel : AListViewModel<IngredientsForView>
    {
        public IngredientsViewModel() : base("Ingredients")
        {

        }
        public async override void OnItemSelected(IngredientsForView item)
        {
            if (item == null) return;
            await Shell.Current.GoToAsync($"{nameof(IngredientsDetailsPage)}?{nameof(IngredientsDetailsViewModel.ItemId)}={item.Id}");
        }
        public override async void GoToAddPage()
        {
            await Shell.Current.GoToAsync(nameof(NewIngredientsPage));
        }
    }
}
