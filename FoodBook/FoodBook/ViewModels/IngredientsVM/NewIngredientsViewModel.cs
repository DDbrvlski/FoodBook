using FoodBook.Service.Reference;
using FoodBook.Services;
using FoodBook.ViewModels.Abstract;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FoodBook.ViewModels.IngredientsVM
{
    public class NewIngredientsViewModel : ANewViewModel<IngredientsForView>
    {
        #region Fields
        private string title = "";
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
        public string Title
        {
            get => title;
            set => SetProperty(ref title, value);
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
        //Collection for picker
        private ObservableCollection<UnitsOfMeasurement> unitsList;
        public ObservableCollection<UnitsOfMeasurement> UnitsList
        {
            get { return unitsList; }
            set { SetProperty(ref unitsList, value); }
        }
        //Getting collection of units for picker
        public async Task<ObservableCollection<UnitsOfMeasurement>> SetUnitsList()
        {
            return new ObservableCollection<UnitsOfMeasurement>(await DependencyService.Get<IDataStore<UnitsOfMeasurement>>().GetItemsAsync(true));
        }
        #endregion

        public NewIngredientsViewModel() : base()
        {
            //Setting collection for picker
            SetUnitsList().ContinueWith(task => UnitsList = task.Result);
        }
        public override IngredientsForView SetItem()
        {
            return new IngredientsForView
            {
                Title = this.Title,
                Kcal = this.Kcal,
                Fats = this.Fats,
                Proteins = this.Proteins,
                Salt = this.Salt,
                Sugar = this.Sugar,
                Carbs = this.Carbs,
                AmountOfUnit = this.AmountOfUnit,
                //this.IdUnitOfMeasurement and this.IdUnitOfMeasurement returns index of selected item
                IdUnitOfMeasurement = UnitsList[(int)this.IdUnitOfMeasurement].Id,
                UnitTitle = UnitsList[(int)this.IdUnitOfMeasurement].Title,
                IsActive = true
            };
        }

        public override bool ValidateSave()
        {
            return true;
        }
    }
}
