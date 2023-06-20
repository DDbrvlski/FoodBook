using FoodBook.Services;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FoodBook.Services
{
    public abstract class AListDataStore<T> : ADataStore, IDataStore<T> where T : class
    {
        public List<T> items = new List<T>();
        public AListDataStore()
            : base()
        {
            RefreshListFromService();
        }

        public async Task<bool> AddItemAsync(T item)
        {
            items.Add(await AddItemToService(item));
            return await Task.FromResult(true);
        }
        public abstract Task<T> Find(int id);
        public abstract Task<T> Find(T item);
        public abstract Task RefreshListFromService();
        public abstract Task RefreshSelectedListFromService(int id, string tableName);
        public abstract Task<bool> DeleteItemFromService(T item);
        public abstract Task<bool> UpdateItemInService(T item);
        public abstract Task<T> AddItemToService(T item);

        public async Task<bool> UpdateItemAsync(T item)
        {
            await UpdateItemInService(item);
            await RefreshListFromService();
            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(int id)
        {
            var oldItem = await Find(id);
            items.Remove(oldItem);
            await DeleteItemFromService(oldItem);
            await RefreshListFromService();
            return await Task.FromResult(true);
        }

        public async Task<T> GetItemAsync(int id)
        {
            return await Task.FromResult(await Find(id));
        }
        public async Task<T> GetItemAsync(T item)
        {
            return await Task.FromResult(await Find(item));
        }
        public async Task<IEnumerable<T>> GetItemsAsync(bool forceRefresh = false)
        {
            await RefreshListFromService();
            return await Task.FromResult(items);
        }
        public async Task<IEnumerable<T>> GetSelectedItemsAsync(bool forceRefresh = false, int id = 0, string tableName = "")
        {
            await RefreshSelectedListFromService(id, tableName);
            return await Task.FromResult(items);
        }

    }
}