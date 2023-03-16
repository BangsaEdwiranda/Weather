using Xtramile.Services.DTOs;
using System.Collections.Generic;

namespace Xtramile.Models
{
    public class WeatherViewModel
    {
        public WeatherViewModel() { 
            Weathers = new List<ExtendedWeatherDTO>();
        }

        public List<ExtendedWeatherDTO> Weathers { get; set; }

        public int CountryId { get; set; }
        public int CityId { get; set; }
    }
}
