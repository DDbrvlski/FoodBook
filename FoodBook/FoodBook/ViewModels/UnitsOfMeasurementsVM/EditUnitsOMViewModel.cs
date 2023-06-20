using FoodBook.Service.Reference;
using FoodBook.ViewModels.Abstract;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FoodBook.ViewModels.UnitsOfMeasurementsVM
{
    public class EditUnitsOMViewModel : AEditViewModel<UnitsOfMeasurement>
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
        #endregion
        public override void LoadProperties(UnitsOfMeasurement item)
        {
            Id = item.Id;
            Title = item.Title;
            Description = item.Description;
        }

        public override async Task<UnitsOfMeasurement> SetItem()
        {
            UnitsOfMeasurement item = await DataStore.GetItemAsync(id);
            item.Title = Title;
            item.Description = Description;
            return item;
        }

        public override bool ValidateSave()
        {
            return true;
        }
    }
}
