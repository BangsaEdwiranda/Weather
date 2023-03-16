using RestSharp;
using System.Threading.Tasks;

namespace Xtramile.Services
{
    public interface IRestClientService
    {
        Task<IRestResponse> ExecuteRestClient(string url, Method method);
    }
}
