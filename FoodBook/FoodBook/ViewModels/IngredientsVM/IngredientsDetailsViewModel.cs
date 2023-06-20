using FoodBook.Service.Reference;
using FoodBook.ViewModels.Abstract;
using FoodBook.Views.IngredientsV;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace FoodBook.ViewModels.IngredientsVM
{
    public class IngredientsDetailsViewModel : AItemDetailsViewModel<IngredientsForView>
    {
        #region Fields
        private int id;
        private string title;
        private string unitTitle;
        private float kcal;
        private float fats;
        private float proteins;
        private float salt;
        private float sugar;
        private float carbs;
        private float amountOfUnit;
        private int? idUnitOfMeasurement;
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
        public string UnitTitle
        {
            get => unitTitle;
            set => SetProperty(ref unitTitle, value);
        }
        public float Kcal
        {
            get => kcal;
            set => SetProperty(ref kcal, value);
        }
        public float Fats
        {
            get => fats;
            set => SetProperty(ref fats, value);
        }
        public float Proteins
        {
            get => proteins;
            set => SetProperty(ref proteins, value);
        }
        public float Salt
        {
            get => salt;
            set => SetProperty(ref salt, value);
        }
        public float Sugar
        {
            get => sugar;
            set => SetProperty(ref sugar, value);
        }
        public float Carbs
        {
            get => carbs;
            set => SetProperty(ref carbs, value);
        }
        public float AmountOfUnit
        {
            get => amountOfUnit;
            set => SetProperty(ref amountOfUnit, value);
        }
        public int? IdUnitOfMeasurement
        {
            get => idUnitOfMeasurement;
            set => SetProperty(ref idUnitOfMeasurement, value);
        }

        public Command EditItemCommand { get; }
        #endregion
        public IngredientsDetailsViewModel() : base()
        {
            EditItemCommand = new Command(OnEdit);
        }
        public override void LoadProperties(IngredientsForView item)
        {
            Id = item.Id;
            Title = item.Title;
            Kcal = item.Kcal;
            Fats = item.Fats;
            Proteins = item.Proteins;
            Salt = item.Salt;
            Sugar = item.Sugar;
            Carbs = item.Carbs;
            AmountOfUnit = item.AmountOfUnit;
            IdUnitOfMeasurement = item.IdUnitOfMeasurement;
            UnitTitle = item.UnitTitle;
        }
        public async void OnEdit()
        {
            await Shell.Current.GoToAsync($"{nameof(EditIngredientsPage)}?{nameof(EditIngredientsViewModel.ItemId)}={Id}");
        }
    }
}
