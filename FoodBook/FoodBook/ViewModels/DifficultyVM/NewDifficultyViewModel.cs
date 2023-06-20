using FoodBook.ViewModels.Abstract;
using FoodBook.Service.Reference;
using System;
using System.Collections.Generic;
using System.Text;

namespace FoodBook.ViewModels.DifficultyVM
{
    public class NewDifficultyViewModel : ANewViewModel<Difficulty>
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

        public override Difficulty SetItem()
        {
            return new Difficulty
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
