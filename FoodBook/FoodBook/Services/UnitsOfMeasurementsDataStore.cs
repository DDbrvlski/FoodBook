using FoodBook.Services;
using FoodBook.Service.Reference;
using System;
using System.Threading.Tasks;
using FoodBook.Helpers;
using System.Linq;

namespace FoodBook.Services
{
    public class UnitsOfMeasurementsDataStore : AListDataStore<UnitsOfMeasurement>
    {
        public UnitsOfMeasurementsDataStore() : base()
        {
        }

        public override async Task<UnitsOfMeasurement> AddItemToService(UnitsOfMeasurement item)
        {
            return await _service.UnitsOfMeasurementsPOSTAsync(item);
        }

        public override async Task<bool> DeleteItemFromService(UnitsOfMeasurement item)
        {
            return await _service.UnitsOfMeasurementsDELETEAsync(item.Id).HandleRequest();
        }

        public override async Task<UnitsOfMeasurement> Find(UnitsOfMeasurement item)
        {
            return await _service.UnitsOfMeasurementsGETAsync(item.Id);
        }

        public override async Task<UnitsOfMeasurement> Find(int id)
        {
            return await _service.UnitsOfMeasurementsGETAsync(id);
        }

        public override async Task RefreshListFromService()
        {
            items = _service.UnitsOfMeasurementsAllAsync().Result.ToList();
        }

        public override Task RefreshSelectedListFromService(int id, string tableName)
        {
            throw new NotImplementedException();
        }

        public override async Task<bool> UpdateItemInService(UnitsOfMeasurement item)
        {
            return await _service.UnitsOfMeasurementsPUTAsync(item.Id, item).HandleRequest();
        }
    }
}
