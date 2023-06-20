using FoodBook.Services;
using FoodBook.Helpers;
using FoodBook.Service.Reference;
using System;
using System.Threading.Tasks;
using System.Linq;

namespace FoodBook.Services
{
    public class DifficultyDataStore : AListDataStore<Difficulty>
    {
        public DifficultyDataStore()
            : base()
        {
        }

        public override async Task<Difficulty> AddItemToService(Difficulty item)
        {
            return await _service.DifficultiesPOSTAsync(item);
        }

        public override async Task<bool> DeleteItemFromService(Difficulty item)
        {
            return await _service.DifficultiesDELETEAsync(item.Id).HandleRequest();
        }

        public override async Task<Difficulty> Find(Difficulty item)
        {
            return await _service.DifficultiesGETAsync(item.Id);
        }

        public override async Task<Difficulty> Find(int id)
        {
            return await _service.DifficultiesGETAsync(id);
        }

        public override async Task RefreshListFromService()
        {
            items = _service.DifficultiesAllAsync().Result.ToList();
        }

        public override Task RefreshSelectedListFromService(int id, string tableName)
        {
            throw new NotImplementedException();
        }

        public override async Task<bool> UpdateItemInService(Difficulty item)
        {
            return await _service.DifficultiesPUTAsync(item.Id, item).HandleRequest();
        }
    }
}
