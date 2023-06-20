using FoodBook.Service.Reference;
using System.Net.Http;

namespace FoodBook.Services
{
    public abstract class ADataStore
    {
        protected readonly FoodBookService _service;
        public ADataStore()
        {
            //Use this code to test locally - localhost do not have certificate
            var handler = new HttpClientHandler();
#if DEBUG
            handler.ClientCertificateOptions = ClientCertificateOption.Manual;
            handler.ServerCertificateCustomValidationCallback =
                (httpRequestMessage, cert, cetChain, policyErrors) =>
                {
                    return true;
                };
#endif
            var client = new HttpClient(handler);
            _service = new FoodBookService("https://localhost:7226", client);
        }
    }
}
