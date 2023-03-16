using Xtramile.Models;
using Xtramile.Services.DTOs;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Xtramile.Services
{
    public class WeatherService : IWeatherService
    {
        private readonly IRestClientService _restClientService;
        private readonly string _key = "d6205df813370874830af628013df39b";
        private readonly string _url = "http://api.openweathermap.org/data/2.5/forecast";

        public WeatherService(IRestClientService restClientService)
        {
            _restClientService = restClientService;
        }

        public async Task<List<ExtendedWeatherDTO>> GetWeatherList(int countryId, int cityId)
        {
            var countryName = Constant.GetListOfCountries().Where(x => x.Id == countryId).Select(x => x.Name).FirstOrDefault();
            var cityName = Constant.GetListOfCities().Where(x => x.Id == cityId).Select(x => x.Name).FirstOrDefault();

            var location = cityName + "," + countryName;

            var url = $"{_url}?q={location}&appid={_key}&units=imperial";

            IRestResponse responseCurrent = null;

            try
            {
                responseCurrent = await _restClientService.ExecuteRestClient(url, Method.GET);
            }
            catch
            {
                return new List<ExtendedWeatherDTO>();
            }

            if (!responseCurrent.IsSuccessful) return new List<ExtendedWeatherDTO>();

            var data = JObject.Parse(responseCurrent.Content);

            var count = Convert.ToInt32(data["cnt"]);

            var list = new List<ExtendedWeatherDTO>();

            for (int i = 0; i < count; i++)
            {
                list.Add(new ExtendedWeatherDTO()
                {
                    CityName = data["city"]["name"].ToString(),
                    Country = data["city"]["country"].ToString(),
                    TimeStamp = data["list"][i]["dt_txt"].ToString(),
                    WindSpeed = data["list"][i]["wind"]["speed"].ToString(),
                    WindDegree = data["list"][i]["wind"]["deg"].ToString(),
                    Visibility = data["list"][i]["visibility"].ToString(),
                    SkyDescription = data["list"][i]["weather"][0]["description"].ToString(),
                    TemperatureInC = ConvertToCelcius(data["list"][i]["main"]["temp"].ToString()),
                    TemperatureInF = data["list"][i]["main"]["temp"].ToString(),
                    DewPoint = data["list"][i]["pop"].ToString(),
                    Humidity = data["list"][i]["main"]["humidity"].ToString(),
                    Pressure = data["list"][i]["main"]["pressure"].ToString()
                }
                );
            }

            return list;
        }

        public string ConvertToCelcius(string fahrenheit)
        {
            var fahr = double.Parse(fahrenheit);
            var celc = (fahr - 32) * 5 / 9;
            return Math.Round(celc, 2).ToString();
        }
    }
}
