using FoodBook.Service.Reference;
using FoodBook.ViewModels.Abstract;
using FoodBook.Views.DifficultyV;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace FoodBook.ViewModels.ClientVM
{
    public class RecipeDetailsForClientViewModel : AItemDetailsViewModel<RecipeForView>
    {
        #region Fields
        private int id;
        private int makingTime;
        private int heightNumberForSteps;
        private int heightNumberForIngredients;
        private float amoutOfUnit;
        private string title;
        private string cuisineTypeTitle;
        private string difficultyName;
        private string dishTypeTitle;
        private string imageURL;
        private float kcal;
        private float fats;
        private float proteins;
        private float salt;
        private float sugar;
        private float carbs;
        private string description;
        private int position;
        private ObservableCollection<RecipeStepsForView> stepsForView;
        private ObservableCollection<IngredientsForRecipeForView> ingredientsForRecipeForView;
        #endregion
        #region Properties
        public int Id
        {
            get => id;
            set => SetProperty(ref id, value);
        }
        public int HeightNumberForSteps
        {
            get => heightNumberForSteps;
            set => SetProperty(ref heightNumberForSteps, value);
        }
        public int HeightNumberForIngredients
        {
            get => heightNumberForIngredients;
            set => SetProperty(ref heightNumberForIngredients, value);
        }
        public int Position
        {
            get => position;
            set => SetProperty(ref position, value);
        }
        public int MakingTime
        {
            get => makingTime;
            set => SetProperty(ref makingTime, value);
        }
        public float AmoutOfUnit
        {
            get => amoutOfUnit;
            set => SetProperty(ref amoutOfUnit, value);
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
        public float Kcal
        {
            get => kcal;
            set => SetProperty(ref kcal, value);
        }
        public float Fats
        {
            get => fats;
            set => SetProperty(ref fats, value);
        }
        public float Proteins
        {
            get => proteins;
            set => SetProperty(ref proteins, value);
        }
        public float Salt
        {
            get => salt;
            set => SetProperty(ref salt, value);
        }
        public float Sugar
        {
            get => sugar;
            set => SetProperty(ref sugar, value);
        }
        public float Carbs
        {
            get => carbs;
            set => SetProperty(ref carbs, value);
        }
        //Collection with ingredients for listview
        public ObservableCollection<IngredientsForRecipeForView> IngredientsForRecipeForView
        {
            get => ingredientsForRecipeForView;
            set => SetProperty(ref ingredientsForRecipeForView, value);
        }
        //Collection with recipesteps for listview
        public ObservableCollection<RecipeStepsForView> StepsForView
        {
            get => stepsForView;
            set => SetProperty(ref stepsForView, value);
        }
        public Command CancelCommand { get; }
        #endregion
        public RecipeDetailsForClientViewModel() : base()
        {
            ingredientsForRecipeForView = new ObservableCollection<IngredientsForRecipeForView>();
            stepsForView = new ObservableCollection<RecipeStepsForView>();
            CancelCommand = new Command(OnCancel);
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
            //Sorting item.RecipeStepsView collection by id
            ObservableCollection<RecipeStepsForView> temp = new ObservableCollection<RecipeStepsForView>(item.RecipeStepsView.OrderBy(x => int.Parse(x.Position)));
            //Adding every element from collection to observablecollection to display it inside listview
            foreach (var element in temp)
            {
                stepsForView.Add(element);
                //increasing height for listview elements
                this.HeightNumberForSteps += 100;
            }
            //Adding every element from collection to observablecollection to display it inside listview
            foreach (var element in item.IngredientsView)
            {
                //Sum every nutritions
                this.Carbs += (float)(element.Carbs * element.AmountOfUnit);
                this.Kcal += (float)(element.Kcal * element.AmountOfUnit);
                this.Fats += (float)(element.Fats * element.AmountOfUnit);
                this.Salt += (float)(element.Salt * element.AmountOfUnit);
                this.Proteins += (float)(element.Proteins * element.AmountOfUnit);
                this.Sugar += (float)(element.Sugar * element.AmountOfUnit);
                ingredientsForRecipeForView.Add(element);
                //increasing height for listview elements
                this.HeightNumberForIngredients += 35;
            }
        }
        public async void OnCancel()
        {
            await Shell.Current.Navigation.PopToRootAsync();
        }
    }
}
