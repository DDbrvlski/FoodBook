using FoodBook.ViewModels.Abstract;
using FoodBook.Service.Reference;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using FoodBook.Views.DifficultyV;

namespace FoodBook.ViewModels.DifficultyVM
{
    public class DifficultyDetailsViewModel : AItemDetailsViewModel<Difficulty>
    {
        #region Fields
        private int id;
        private string title;
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
        public string Description
        {
            get => description;
            set => SetProperty(ref description, value);
        }
        public Command EditItemCommand { get; }
        #endregion
        public DifficultyDetailsViewModel() : base()
        {
            EditItemCommand = new Command(OnEdit);
        }
        public override void LoadProperties(Difficulty item)
        {
            Id = item.Id;
            Title = item.Title;
            Description = item.Description;
        }
        public async void OnEdit()
        {
            await Shell.Current.GoToAsync($"{nameof(EditDifficultyPage)}?{nameof(EditUnitsOMViewModel.ItemId)}={Id}");
        }
    }
}
