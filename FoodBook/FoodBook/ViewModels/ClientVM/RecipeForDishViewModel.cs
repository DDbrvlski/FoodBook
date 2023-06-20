﻿using FoodBook.Service.Reference;
using FoodBook.ViewModels.Abstract;
using FoodBook.Views.ClientV;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace FoodBook.ViewModels.ClientVM
{
    public class RecipeForDishViewModel : ASelectedListViewModel<RecipeForView, DishTypeForView>
    {
        public RecipeForDishViewModel() : base("")
        {
            selectedTableName = "DishType";
        }
        public override async void OnItemSelected(RecipeForView item)
        {
            if (item == null) return;
            await Shell.Current.GoToAsync($"{nameof(RecipeDetailsForClientPage)}?{nameof(RecipeDetailsForClientViewModel.ItemId)}={item.Id}");
        }
    }
}
