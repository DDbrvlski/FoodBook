using FoodBook.Service.Reference;
using FoodBook.Services;
using FoodBook.ViewModels.Abstract;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FoodBook.ViewModels.IngredientsVM
{
    public class EditIngredientsViewModel : AEditViewModel<IngredientsForView>
    {
        #region Fields
        private int id;
        private string title;
        private string unitTitle;
        private DateTimeOffset modifiedDate = DateTime.Now;
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
        public EditIngredientsViewModel() : base()
        {
            //Setting collection for picker
            SetUnitsList().ContinueWith(task => UnitsList = task.Result);
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
            this.IdUnitOfMeasurement = unitsList.IndexOf(unitsList.FirstOrDefault(x => x.Id == item.IdUnitOfMeasurement));
            UnitTitle = item.UnitTitle;
        }

        public override async Task<IngredientsForView> SetItem()
        {
            IngredientsForView item = await DataStore.GetItemAsync(id);
            item.Title = Title;
            item.Kcal = Kcal;
            item.Fats = Fats;
            item.Proteins = Proteins;
            item.Salt = Salt;
            item.Carbs = Carbs;
            item.Sugar = Sugar;
            item.ModifiedDate = DateTime.Now;
            item.AmountOfUnit = AmountOfUnit;
            //this.IdUnitOfMeasurement and this.IdUnitOfMeasurement returns index of selected item
            item.IdUnitOfMeasurement = UnitsList[(int)this.IdUnitOfMeasurement].Id;
            item.UnitTitle = UnitsList[(int)this.IdUnitOfMeasurement].Title;
            return item;
        }

        public override bool ValidateSave()
        {
            return true;
        }
    }
}
