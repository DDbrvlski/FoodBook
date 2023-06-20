using FoodBook.Service.Reference;
using FoodBook.ViewModels.Abstract;
using FoodBook.Views.DishTypeV;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace FoodBook.ViewModels.DishTypeVM
{
    public class DishTypeDetailsViewModel : AItemDetailsViewModel<DishTypeForView>
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
        public Command EditItemCommand { get; }
        #endregion
        public DishTypeDetailsViewModel() : base()
        {
            EditItemCommand = new Command(OnEdit);
        }
        public override void LoadProperties(DishTypeForView item)
        {
            Id = item.Id;
            Title = item.Title;
            Description = item.Description;
            ImageTitle = item.ImageTitle;
            ImageURL = item.ImageURL;
        }
        public async void OnEdit()
        {
            await Shell.Current.GoToAsync($"{nameof(EditDishTypePage)}?{nameof(EditDishTypeViewModel.ItemId)}={Id}");
        }
    }
}
