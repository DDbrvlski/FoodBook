using FoodBook.Service.Reference;
using FoodBook.ViewModels.Abstract;
using FoodBook.Views;
using FoodBook.Views.UnitsOfMeasurementsV;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace FoodBook.ViewModels.UnitsOfMeasurementsVM
{
    public class UnitsOMViewModel : AListViewModel<UnitsOfMeasurement>
    {
        public UnitsOMViewModel() : base("Units")
        {
        }

        public async override void OnItemSelected(UnitsOfMeasurement item)
        {
            if (item == null) return;
            await Shell.Current.GoToAsync($"{nameof(UnitsOMDetailsPage)}?{nameof(UnitsOMDetailsViewModel.ItemId)}={item.Id}");
        }
        public override async void GoToAddPage()
        {
            await Shell.Current.GoToAsync(nameof(NewUnitsOMPage));
        }
    }
}
