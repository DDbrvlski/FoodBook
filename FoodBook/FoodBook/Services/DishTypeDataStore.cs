using FoodBook.Services;
using FoodBook.Service.Reference;
using System;
using System.Threading.Tasks;
using FoodBook.Helpers;
using System.Linq;

namespace FoodBook.Services
{
    public class DishTypeDataStore : AListDataStore<DishTypeForView>
    {
        public DishTypeDataStore() : base()
        {
        }

        public override async Task<DishTypeForView> AddItemToService(DishTypeForView item)
        {
            return await _service.DishTypesPOSTAsync(item);
        }

        public override async Task<bool> DeleteItemFromService(DishTypeForView item)
        {
            return await _service.DishTypesDELETEAsync(item.Id).HandleRequest();
        }

        public override async Task<DishTypeForView> Find(DishTypeForView item)
        {
            return await _service.DishTypesGETAsync(item.Id);
        }

        public override async Task<DishTypeForView> Find(int id)
        {
            return await _service.DishTypesGETAsync(id);
        }

        public override async Task RefreshListFromService()
        {
            items = _service.DishTypesAllAsync().Result.ToList();
        }

        public override Task RefreshSelectedListFromService(int id, string tableName)
        {
            throw new NotImplementedException();
        }

        public override async Task<bool> UpdateItemInService(DishTypeForView item)
        {
            return await _service.DishTypesPUTAsync(item.Id, item).HandleRequest();
        }
    }
}
