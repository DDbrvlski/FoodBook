using FoodBook.ViewModels.Abstract;
using FoodBook.Service.Reference;
using System;
using System.Collections.Generic;
using System.Text;

namespace FoodBook.ViewModels.UnitsOfMeasurementsVM
{
    public class NewUnitsOMViewModel : ANewViewModel<UnitsOfMeasurement>
    {

        #region Fields
        private string title = "";
        private string description = "";
        #endregion

        #region Properties
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

        public override UnitsOfMeasurement SetItem()
        {
            return new UnitsOfMeasurement
            {
                Title = this.Title,
                Description = this.Description,
                IsActive = true
            };
        }

        public override bool ValidateSave()
        {
            return true;
        }
    }
}
