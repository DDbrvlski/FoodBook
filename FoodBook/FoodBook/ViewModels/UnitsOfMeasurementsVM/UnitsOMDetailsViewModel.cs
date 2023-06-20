using FoodBook.ViewModels.Abstract;
using FoodBook.Service.Reference;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using FoodBook.Views.UnitsOfMeasurementsV;

namespace FoodBook.ViewModels.UnitsOfMeasurementsVM
{
    public class UnitsOMDetailsViewModel : AItemDetailsViewModel<UnitsOfMeasurement>
    {
        #region Fields
        private int id;
        private string title;
        private string description;
        #endregion
        #region Properties
        public int Id
        {
            get => id;
            set => SetProperty(ref id, value);
        }
        public string Title
        {
            get => title;
            set => SetProperty(ref title, value);
        }
        public string Description
        {
            get => description;
            set => SetProperty(ref description, value);
        }
        public Command EditItemCommand { get; }
        #endregion
        public UnitsOMDetailsViewModel() : base()
        {
            EditItemCommand = new Command(OnEdit);
        }
        public override void LoadProperties(UnitsOfMeasurement item)
        {
            Id = item.Id;
            Title = item.Title;
            Description = item.Description;
        }
        public async void OnEdit()
        {
            await Shell.Current.GoToAsync($"{nameof(EditUnitsOMPage)}?{nameof(EditUnitsOMViewModel.ItemId)}={Id}");
        }
    }
}
