using FoodBook.Service.Reference;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace FoodBook.ViewModels.RecipesVM.Helpers
{
    //Helper class for listview to display and set every step in recipe
    public class RecipeStep : BaseViewModel
    {
        public int Id { get; set; }

        private string description;
        private string position;

        public string Description
        {
            get => description;
            set => SetProperty(ref description, value);
        }
        public string Position
        {
            get => position;
            set => SetProperty(ref position, value);
        }
        public ICommand RemoveCommand { get; set; }
        private ObservableCollection<RecipeStep> parentCollection;

        public RecipeStep(ObservableCollection<RecipeStep> collection)
        {
            RemoveCommand = new Command(RemoveIngredient);
            parentCollection = collection;
        }

        private void RemoveIngredient()
        {
            parentCollection.Remove(this);
        }
    }
}
