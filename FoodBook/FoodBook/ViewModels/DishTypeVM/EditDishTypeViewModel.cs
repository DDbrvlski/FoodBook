using FoodBook.Service.Reference;
using FoodBook.ViewModels.Abstract;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FoodBook.ViewModels.DishTypeVM
{
    public class EditDishTypeViewModel : AEditViewModel<DishTypeForView>
    {
        #region Fields
        private int id;
        private string title;
        private string description;
        private string imageURL;
        private string imageTitle;
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
        public override void LoadProperties(DishTypeForView item)
        {
            Id = item.Id;
            Title = item.Title;
            Description = item.Description;
            ImageURL = item.ImageURL;
            ImageTitle = item.ImageTitle;
        }

        public override async Task<DishTypeForView> SetItem()
        {
            DishTypeForView item = await DataStore.GetItemAsync(id);
            item.Title = Title;
            item.Description = Description;
            item.ImageURL = ImageURL;
            item.ImageTitle = ImageTitle;
            return item;
        }

        public override bool ValidateSave()
        {
            return true;
        }
    }
}
