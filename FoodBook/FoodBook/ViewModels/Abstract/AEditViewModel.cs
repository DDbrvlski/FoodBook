using FoodBook.ViewModels;
using FoodBook.Services;
using Xamarin.Forms;
using System;
using System.Net.Http;
using System.Diagnostics;
using System.Threading.Tasks;
using FoodBook.Service.Reference;
using System.Collections.ObjectModel;

namespace FoodBook.ViewModels.Abstract
{
    [QueryProperty(nameof(ItemId), nameof(ItemId))]
    public abstract class AEditViewModel<T> : BaseViewModel
    {
        public IDataStore<T> DataStore => DependencyService.Get<IDataStore<T>>();
        public AEditViewModel()
        {
            AddStepCommand = new Command(AddStep);
            SaveCommand = new Command(OnSave, ValidateSave);
            CancelCommand = new Command(OnCancel);
            this.PropertyChanged +=
                (_, __) => SaveCommand.ChangeCanExecute();
        }
        public abstract bool ValidateSave();
        public Command AddStepCommand { get; }
        public Command SaveCommand { get; }
        public Command CancelCommand { get; }
        public abstract void LoadProperties(T item);
        private async void OnCancel()
        {
            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }
        public abstract Task<T> SetItem();
        private async void OnSave()
        {
            try
            {
                T item = await SetItem();
                await DataStore.UpdateItemAsync(item);
                await Shell.Current.GoToAsync("..");
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Wystąpił błąd podczas wysyłania żądania HTTP: {ex.Message}");
                Console.WriteLine($"Szczegóły: {ex.InnerException}");
            }
        }
        private int itemId;
        public int ItemId
        {
            get
            {
                return itemId;
            }
            set
            {
                itemId = value;
                LoadItemId(value);
            }
        }
        public async void LoadItemId(int itemId)
        {
            try
            {
                var item = await DataStore.GetItemAsync(itemId);
                LoadProperties(item);
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Item");
            }
        }
        public ObservableCollection<RecipeStepsForView> RecipeSteps { get; set; } = new ObservableCollection<RecipeStepsForView>();



        private void AddStep()
        {
            RecipeSteps.Add(new RecipeStepsForView()); // Dodanie nowego pustego kroku przepisu do listy
        }
    }
}
