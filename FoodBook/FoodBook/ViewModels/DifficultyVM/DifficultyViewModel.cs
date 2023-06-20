using FoodBook.Service.Reference;
using FoodBook.ViewModels.Abstract;
using FoodBook.Views;
using FoodBook.Views.DifficultyV;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace FoodBook.ViewModels.DifficultyVM
{
    public class DifficultyViewModel : AListViewModel<Difficulty>
    {
        public DifficultyViewModel() : base("Difficulty")
        {
        }

        public async override void OnItemSelected(Difficulty item)
        {
            if (item == null) return;
            await Shell.Current.GoToAsync($"{nameof(DifficultyDetailsPage)}?{nameof(DifficultyDetailsViewModel.ItemId)}={item.Id}");
        }
        public override async void GoToAddPage()
        {
            await Shell.Current.GoToAsync(nameof(NewDifficultyPage));
        }
    }
}
