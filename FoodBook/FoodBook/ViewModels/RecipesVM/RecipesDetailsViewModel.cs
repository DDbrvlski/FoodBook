using FoodBook.Service.Reference;
using FoodBook.ViewModels.Abstract;
using FoodBook.Views.DifficultyV;
using FoodBook.Views.RecipesV;
using System;
using Xamarin.Forms;

namespace FoodBook.ViewModels.RecipesVM
{
    public class RecipesDetailsViewModel : AItemDetailsViewModel<RecipeForView>
    {
        #region Fields
        private int id;
        private int makingTime;
        private string title;
        private string cuisineTypeTitle;
        private string difficultyName;
        private string dishTypeTitle;
        private string imageURL;
        #endregion
        #region Properties
        public int Id
        {
            get => id;
            set => SetProperty(ref id, value);
        }
        public int MakingTime
        {
            get => makingTime;
            set => SetProperty(ref makingTime, value);
        }
        public string Title
        {
            get => title;
            set => SetProperty(ref title, value);
        }
        public string CuisineTypeTitle
        {
            get => cuisineTypeTitle;
            set => SetProperty(ref cuisineTypeTitle, value);
        }
        public string DifficultyName
        {
            get => difficultyName;
            set => SetProperty(ref difficultyName, value);
        }
        public string DishTypeTitle
        {
            get => dishTypeTitle;
            set => SetProperty(ref dishTypeTitle, value);
        }
        public string ImageURL
        {
            get => imageURL;
            set => SetProperty(ref imageURL, value);
        }
        public Command EditItemCommand { get; }
        #endregion
        public RecipesDetailsViewModel() : base()
        {
            EditItemCommand = new Command(OnEdit);
        }
        public override void LoadProperties(RecipeForView item)
        {
            Id = item.Id;
            Title = item.Title;
            DifficultyName = item.DifficultyName;
            DishTypeTitle = item.DishTypeTitle;
            CuisineTypeTitle = item.CuisineTypeTitle;
            MakingTime = item.MakingTime;
            ImageURL = item.ImageURL;
        }
        public async void OnEdit()
        {
            await Shell.Current.GoToAsync($"{nameof(EditRecipesPage)}?{nameof(EditRecipesViewModel.ItemId)}={Id}");
        }
    }
}
