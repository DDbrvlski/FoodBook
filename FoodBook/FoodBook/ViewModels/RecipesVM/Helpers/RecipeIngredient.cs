using FoodBook.Service.Reference;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace FoodBook.ViewModels.RecipesVM.Helpers
{
    //Helper class for listview to display and set every ingredient in recipe
    public class RecipeIngredient : BaseViewModel
    {
        private ObservableCollection<IngredientsForView> ingredientsInRecipeList;
        public ObservableCollection<IngredientsForView> IngredientsInRecipeList
        {
            get { return ingredientsInRecipeList; }
            set { SetProperty(ref ingredientsInRecipeList, value); }
        }
        public int Id { get; set; }
        private int idIngredient;
        public int IdIngredient
        {
            get => idIngredient;
            set
            {
                if (value != -1)
                {
                    SetProperty(ref idIngredient, value);
                    try
                    {
                        UnitTitle = IngredientsInRecipeList[value].UnitTitle;
                    }
                    catch (Exception ex) { }
                }
            }
        }
        private string title;
        public string Title
        {
            get => title;
            set => SetProperty(ref title, value);
        }

        private float amount;
        private string unitTitle;
        public string UnitTitle
        {
            get => unitTitle;
            set => SetProperty(ref unitTitle, value);
        }
        public float Amount
        {
            get => amount;
            set => SetProperty(ref amount, value);
        }
        public ICommand RemoveCommand { get; set; }
        private ObservableCollection<RecipeIngredient> parentCollection;

        public RecipeIngredient(ObservableCollection<RecipeIngredient> collection)
        {
            try
            {
                RemoveCommand = new Command(RemoveIngredient);
                parentCollection = collection;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void RemoveIngredient()
        {
            parentCollection.Remove(this);
        }
    }
}
