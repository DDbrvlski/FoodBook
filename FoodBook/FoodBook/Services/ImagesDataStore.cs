using FoodBook.Helpers;
using FoodBook.Service.Reference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodBook.Services
{
    public class ImagesDataStore : AListDataStore<Images>
    {

        public override async Task<Images> AddItemToService(Images item)
        {
            return await _service.ImagesPOSTAsync(item);
        }

        public override async Task<bool> DeleteItemFromService(Images item)
        {
            return await _service.CuisineTypesDELETEAsync(item.Id).HandleRequest();
        }

        public override async Task<Images> Find(Images item)
        {
            return await _service.ImagesGETAsync(item.Id);
        }

        public override async Task<Images> Find(int id)
        {
            return await _service.ImagesGETAsync(id);
        }

        public override async Task RefreshListFromService()
        {
            items = _service.ImagesAllAsync().Result.ToList();
        }

        public override Task RefreshSelectedListFromService(int id, string tableName)
        {
            throw new NotImplementedException();
        }

        public override async Task<bool> UpdateItemInService(Images item)
        {
            return await _service.ImagesPUTAsync(item.Id, item).HandleRequest();
        }
    }
}
