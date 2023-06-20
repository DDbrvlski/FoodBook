using System.Collections.Generic;
using System.Threading.Tasks;

namespace FoodBook.Services
{
    public interface IDataStore<T>
    {
        Task<bool> AddItemAsync(T item);
        Task<bool> UpdateItemAsync(T item);
        Task<bool> DeleteItemAsync(int id);
        Task<T> GetItemAsync(int id);
        Task<T> GetItemAsync(T item);
        Task<IEnumerable<T>> GetItemsAsync(bool forceRefresh = false);
        Task<IEnumerable<T>> GetSelectedItemsAsync(bool forceRefresh = false, int id = 0, string tableName = "");
    }
}
