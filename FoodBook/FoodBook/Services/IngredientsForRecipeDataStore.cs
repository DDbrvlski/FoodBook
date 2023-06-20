using FoodBook.Services;
using FoodBook.Service.Reference;
using System;
using System.Threading.Tasks;

namespace FoodBook.Services
{
    public class IngredientsForRecipeDataStore : AListDataStore<IngredientsForRecipe>
    {
        public IngredientsForRecipeDataStore() : base()
        {
        }

        public override async Task<IngredientsForRecipe> AddItemToService(IngredientsForRecipe item)
        {
            throw new NotImplementedException();
        }

        public override async Task<bool> DeleteItemFromService(IngredientsForRecipe item)
        {
            throw new NotImplementedException();
        }

        public override async Task<IngredientsForRecipe> Find(IngredientsForRecipe item)
        {
            throw new NotImplementedException();
        }

        public override async Task<IngredientsForRecipe> Find(int id)
        {
            throw new NotImplementedException();
        }

        public override async Task RefreshListFromService()
        {
            throw new NotImplementedException();
        }

        public override Task RefreshSelectedListFromService(int id, string tableName)
        {
            throw new NotImplementedException();
        }

        public override async Task<bool> UpdateItemInService(IngredientsForRecipe item)
        {
            throw new NotImplementedException();
        }
    }
}
