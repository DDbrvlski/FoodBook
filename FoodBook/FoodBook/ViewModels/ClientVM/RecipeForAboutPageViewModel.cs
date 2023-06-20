using FoodBook.Models;
using FoodBook.Service.Reference;
using FoodBook.ViewModels.Abstract;
using FoodBook.Views.ClientV;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace FoodBook.ViewModels.ClientVM
{
    public class RecipeForAboutPageViewModel : AListViewModel<RecipeForView>
    {
        public RecipeForAboutPageViewModel() : base("")
        {
            option = "last";
        }
        public override async void OnItemSelected(RecipeForView item)
        {
            if (item == null) return;
            await Shell.Current.GoToAsync($"{nameof(RecipeDetailsForClientPage)}?{nameof(RecipeDetailsForClientViewModel.ItemId)}={item.Id}");
        }
        public override void GoToAddPage()
        {

        }
        public override IEnumerable<RecipeForView> LastThree(IEnumerable<RecipeForView> item)
        {
            return item.OrderByDescending(x => x.Id).Take(3);
        }
    }
}
