using FoodBook.Services;
using FoodBook.Service.Reference;
using System;
using System.Threading.Tasks;
using System.Linq;
using FoodBook.Helpers;

namespace FoodBook.Services
{
    public class IngredientsDataStore : AListDataStore<IngredientsForView>
    {
        public IngredientsDataStore() : base()
        {
        }

        public override async Task<IngredientsForView> AddItemToService(IngredientsForView item)
        {
            return await _service.IngredientsPOSTAsync(item);
        }

        public override async Task<bool> DeleteItemFromService(IngredientsForView item)
        {
            return await _service.IngredientsDELETEAsync(item.Id).HandleRequest();
        }

        public override async Task<IngredientsForView> Find(IngredientsForView item)
        {
            return await _service.IngredientsGETAsync(item.Id);
        }

        public override async Task<IngredientsForView> Find(int id)
        {
            return await _service.IngredientsGETAsync(id);
        }

        public override async Task RefreshListFromService()
        {
            items = _service.IngredientsAllAsync().Result.ToList();
        }

        public override Task RefreshSelectedListFromService(int id, string tableName)
        {
            return null;
        }

        public override async Task<bool> UpdateItemInService(IngredientsForView item)
        {
            return await _service.IngredientsPUTAsync(item.Id, item).HandleRequest();
        }
    }
}
