using FoodBook.Service.Reference;
using FoodBook.ViewModels.Abstract;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FoodBook.ViewModels.CuisineTypeVM
{
    public class EditCuisineTypeViewModel : AEditViewModel<CuisineTypeForView>
    {
        #region Fields
        private int id;
        private string title;
        private string imageURL;
        private int idImage;
        private string imageTitle;
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
        public string ImageURL
        {
            get => imageURL;
            set => SetProperty(ref imageURL, value);
        }
        public int IdImage
        {
            get => idImage;
            set => SetProperty(ref idImage, value);
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
        public override void LoadProperties(CuisineTypeForView item)
        {
            Id = item.Id;
            Title = item.Title;
            ImageURL = item.ImageURL;
            ImageTitle = item.ImageTitle;
            Description = item.Description;
        }

        public override async Task<CuisineTypeForView> SetItem()
        {
            CuisineTypeForView item = await DataStore.GetItemAsync(id);
            item.Title = Title;
            item.ImageURL = ImageURL;
            item.Description = Description;
            item.ImageTitle = imageTitle;
            return item;
        }

        public override bool ValidateSave()
        {
            return true;
        }
    }
}
