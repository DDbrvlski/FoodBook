using FoodBook.Service.Reference;
using FoodBook.Services;
using FoodBook.ViewModels.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace FoodBook.ViewModels.CuisineTypeVM
{
    public class NewCuisineTypeViewModel : ANewViewModel<CuisineTypeForView>
    {
        #region Fields
        private string title = "";
        private string description = "";
        private string imageTitle = "";
        private string imageURL = "";
        #endregion

        #region Properties
        public string Title
        {
            get => title;
            set => SetProperty(ref title, value);
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
        public string Description
        {
            get => description;
            set => SetProperty(ref description, value);
        }

        #endregion

        public override CuisineTypeForView SetItem()
        {
            return new CuisineTypeForView
            {
                Title = this.Title,
                IsActive = true,
                ImageURL = this.ImageURL,
                ImageTitle = this.ImageTitle,
                Description = this.Description,
            };
        }

        public override bool ValidateSave()
        {
            return true;
        }
    }
}
