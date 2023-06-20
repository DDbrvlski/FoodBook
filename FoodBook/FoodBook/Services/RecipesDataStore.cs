using FoodBook.Services;
using FoodBook.Service.Reference;
using System;
using System.Threading.Tasks;
using FoodBook.Helpers;
using System.Linq;

namespace FoodBook.Services
{
    public class RecipesDataStore : AListDataStore<RecipeForView>
    {
        public RecipesDataStore() : base()
        {
        }

        public override async Task<RecipeForView> AddItemToService(RecipeForView item)
        {
            return await _service.RecipesPOSTAsync(item);
        }

        public override async Task<bool> DeleteItemFromService(RecipeForView item)
        {
            return await _service.RecipesDELETEAsync(item.Id).HandleRequest();
        }

        public override async Task<RecipeForView> Find(RecipeForView item)
        {
            return await _service.RecipesGETAsync(item.Id);
        }

        public override async Task<RecipeForView> Find(int id)
        {
            return await _service.RecipesGETAsync(id);
        }

        public override async Task RefreshListFromService()
        {
            items = _service.RecipesAllAsync().Result.ToList();
        }

        public override async Task RefreshSelectedListFromService(int id, string tableName)
        {
            if (tableName == "CuisineType")
            {
                items = _service.RecipesAllAsync().Result.Where(x => x.IdCuisineType == id).ToList();
            }
            else if (tableName == "DishType")
            {
                items = _service.RecipesAllAsync().Result.Where(x => x.IdDishType == id).ToList();
            }

        }

        public override async Task<bool> UpdateItemInService(RecipeForView item)
        {
            return await _service.RecipesPUTAsync(item.Id, item).HandleRequest();
        }
    }
}
