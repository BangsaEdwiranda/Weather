using RestSharp;
using System.Threading.Tasks;

namespace Xtramile.Services
{
    public class RestClientService : IRestClientService
    {
        public RestClientService()
        {
        }

        public async Task<IRestResponse> ExecuteRestClient(string url, Method method)
        {
            var client = new RestClient(url);
            var request = new RestRequest(method);
            return await client.ExecuteAsync(request);
        }
    }
}
