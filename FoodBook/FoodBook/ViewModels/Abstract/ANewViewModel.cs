using FoodBook.ViewModels;
using FoodBook.Services;
using Xamarin.Forms;
using System;
using System.Net.Http;
using FoodBook.Service.Reference;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace FoodBook.ViewModels.Abstract
{
    public abstract class ANewViewModel<T> : BaseViewModel
    {
        public IDataStore<T> DataStore => DependencyService.Get<IDataStore<T>>();
        public ANewViewModel()
        {
            SaveCommand = new Command(OnSave, ValidateSave);
            CancelCommand = new Command(OnCancel);
            this.PropertyChanged +=
                (_, __) => SaveCommand.ChangeCanExecute();
        }
        public abstract bool ValidateSave();
        public Command SaveCommand { get; }
        public Command CancelCommand { get; }
        private async void OnCancel()
        {
            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }
        public abstract T SetItem();
        private async void OnSave()
        {
            try
            {
                var item = SetItem();
                await DataStore.AddItemAsync(item);
                await Shell.Current.GoToAsync("..");
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Wystąpił błąd podczas wysyłania żądania HTTP: {ex.Message}");
                Console.WriteLine($"Szczegóły: {ex.InnerException}");
            }
        }

    }
}