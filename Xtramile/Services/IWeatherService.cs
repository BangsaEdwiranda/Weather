using Xtramile.Services.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Xtramile.Services
{
    public interface IWeatherService
    {
        Task<List<ExtendedWeatherDTO>> GetWeatherList(int countryId, int cityId);
        string ConvertToCelcius(string fahrenheit);
    }
}
