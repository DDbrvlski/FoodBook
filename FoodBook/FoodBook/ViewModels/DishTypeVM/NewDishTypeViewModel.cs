using FoodBook.Service.Reference;
using FoodBook.ViewModels.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace FoodBook.ViewModels.DishTypeVM
{
    public class NewDishTypeViewModel : ANewViewModel<DishTypeForView>
    {
        #region Fields
        private string title = "";
        private string description = "";
        private string imageURL = "";
        private string imageTitle = "";
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
        public string ImageURL
        {
            get => imageURL;
            set => SetProperty(ref imageURL, value);
        }
        public string ImageTitle
        {
            get => imageTitle;
            set => SetProperty(ref imageTitle, value);
        }
        #endregion

        public override DishTypeForView SetItem()
        {
            return new DishTypeForView
            {
                Title = this.Title,
                Description = this.Description,
                IsActive = true,
                ImageURL = this.ImageURL,
                ImageTitle = this.ImageTitle,
            };
        }

        public override bool ValidateSave()
        {
            return true;
        }
    }
}
