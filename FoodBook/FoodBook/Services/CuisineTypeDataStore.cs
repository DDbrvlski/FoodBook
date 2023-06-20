using FoodBook.Services;
using FoodBook.Service.Reference;
using System;
using System.Threading.Tasks;
using FoodBook.Helpers;
using System.Linq;
using System.Collections.Generic;

namespace FoodBook.Services
{
    public class CuisineTypeDataStore : AListDataStore<CuisineTypeForView>
    {
        public CuisineTypeDataStore() : base()
        {
        }

        public override async Task<CuisineTypeForView> AddItemToService(CuisineTypeForView item)
        {
            return await _service.CuisineTypesPOSTAsync(item);
        }

        public override async Task<bool> DeleteItemFromService(CuisineTypeForView item)
        {
            return await _service.CuisineTypesDELETEAsync(item.Id).HandleRequest();
        }

        public override async Task<CuisineTypeForView> Find(CuisineTypeForView item)
        {
            return await _service.CuisineTypesGETAsync(item.Id);
        }

        public override async Task<CuisineTypeForView> Find(int id)
        {
            return await _service.CuisineTypesGETAsync(id);
        }

        public override async Task RefreshListFromService()
        {
            items = _service.CuisineTypesAllAsync().Result.ToList();
        }

        public override Task RefreshSelectedListFromService(int id, string tableName)
        {
            return null;
        }

        public override async Task<bool> UpdateItemInService(CuisineTypeForView item)
        {
            return await _service.CuisineTypesPUTAsync(item.Id, item).HandleRequest();
        }
    }
}
