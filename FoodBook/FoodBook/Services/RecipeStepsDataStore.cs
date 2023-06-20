using FoodBook.Helpers;
using FoodBook.Service.Reference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodBook.Services
{
    public class RecipeStepsDataStore : AListDataStore<RecipeStepsForView>
    {
        public RecipeStepsDataStore() : base()
        {
        }

        public override async Task<RecipeStepsForView> AddItemToService(RecipeStepsForView item)
        {
            return await _service.RecipeStepsPOSTAsync(item);
        }

        public override async Task<bool> DeleteItemFromService(RecipeStepsForView item)
        {
            return await _service.RecipeStepsDELETEAsync(item.Id).HandleRequest();
        }

        public override async Task<RecipeStepsForView> Find(RecipeStepsForView item)
        {
            return await _service.RecipeStepsGETAsync(item.Id);
        }

        public override async Task<RecipeStepsForView> Find(int id)
        {
            return await _service.RecipeStepsGETAsync(id);
        }

        public override async Task RefreshListFromService()
        {
            items = _service.RecipeStepsAllAsync().Result.ToList();
        }

        public override Task RefreshSelectedListFromService(int id, string tableName)
        {
            throw new NotImplementedException();
        }

        public override async Task<bool> UpdateItemInService(RecipeStepsForView item)
        {
            return await _service.RecipeStepsPUTAsync(item.Id, item).HandleRequest();
        }
    }
}
