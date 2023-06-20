using FoodBook.Services;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FoodBook.ViewModels.Abstract
{
    [QueryProperty(nameof(ItemId), nameof(ItemId))]
    public abstract class ASelectedListViewModel<T, T2> : BaseViewModel
    {
        public IDataStore<T> DataStore => DependencyService.Get<IDataStore<T>>();
        public IDataStore<T2> DataStore2 => DependencyService.Get<IDataStore<T2>>();
        private T _selectedItem;
        public ObservableCollection<T> Items { get; }
        public Command LoadItemsCommand { get; }
        public Command<T> ItemTapped { get; }
        public string selectedTableName = "";
        public T2 Item { get; set; }
        public ASelectedListViewModel(string title)
        {
            Title = title;
            Items = new ObservableCollection<T>();
            ItemTapped = new Command<T>(OnItemSelected);

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
                ExecuteLoadItemsCommand(value);
            }
        }
        async Task ExecuteLoadItemsCommand(int id)
        {
            IsBusy = true;
            try
            {
                Items.Clear();
                Item = await DataStore2.GetItemAsync(id);
                var items = await DataStore.GetSelectedItemsAsync(true, id, selectedTableName);
                foreach (var item in items)
                {
                    Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
        public void OnAppearing()
        {
            IsBusy = true;
            SelectedItem = default(T);
        }

        public T SelectedItem
        {
            get => _selectedItem;
            set
            {
                SetProperty(ref _selectedItem, value);
                OnItemSelected(value);
            }
        }
        public async virtual void OnItemSelected(T item)
        {
            if (item == null)
                return;
            //await Shell.Current.GoToAsync($"{nameof(ClientDetailPage)}?{nameof(ClientDetailViewModel.ItemId)}={item.IdClient}");
        }
    }

}