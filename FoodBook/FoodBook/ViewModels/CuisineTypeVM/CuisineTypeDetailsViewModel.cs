using FoodBook.Service.Reference;
using FoodBook.ViewModels.Abstract;
using FoodBook.Views.CuisineTypeV;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace FoodBook.ViewModels.CuisineTypeVM
{
    public class CuisineTypeDetailsViewModel : AItemDetailsViewModel<CuisineTypeForView>
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
        public CuisineTypeDetailsViewModel() : base()
        {
            EditItemCommand = new Command(OnEdit);
        }
        public override void LoadProperties(CuisineTypeForView item)
        {
            Id = item.Id;
            Title = item.Title;
            ImageURL = item.ImageURL;
            ImageTitle = item.ImageTitle;
            Description = item.Description;
        }
        public async void OnEdit()
        {
            await Shell.Current.GoToAsync($"{nameof(EditCuisineTypePage)}?{nameof(EditCuisineTypeViewModel.ItemId)}={Id}");
        }
    }
}
