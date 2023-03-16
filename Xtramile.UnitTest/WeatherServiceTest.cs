using Moq;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using System;
using System.Threading.Tasks;
using Xtramile.Services;
using RestSharp;
using System.Text.Json;
using NUnit.Framework.Internal.Execution;
using System.Collections.Generic;


namespace Xtramile.UnitTest
{
    public class WeatherServiceTest
    {
        private readonly IWeatherService _weatherService;
        private readonly Mock<IRestClientService> _restClientServiceMock;
        private string RestContent { get; set; }

        public WeatherServiceTest()
        {

            _restClientServiceMock = new Mock<IRestClientService>();
            _weatherService = new WeatherService(_restClientServiceMock.Object);

        }

        [SetUp]
        public void Setup()
        {
            RestContent = JsonSerializer.Serialize(
              new
              {
                  city = new
                  {
                      name = "Jakarta",
                      country = "ID"
                  },
                  cnt = "1",
                  list = new []
                  {
                      new 
                      {
                        main = new
                        {
                            temp = "100",
                            pressure = "1028",
                            humidity = "62"
                        },
                        weather = new []
                        {
                            new 
                            {
                                description = "Rainy"
                            }
                        },
                        wind = new
                        {
                            speed = "4.92",
                            deg = "78"
                        },
                        visibility = "10000",
                        pop = "10",
                        dt_txt = "2023-03-21 06:00:00"
                      },
                  }
              }
            );
        }

        [Test]
        public async Task GetWeatherList_should_return_as_expected_on_success()
        {
            // setup
            var countryId = 1;
            var cityId = 1;
            var restResponse = new RestResponse();
            restResponse.Content = RestContent;
            restResponse.StatusCode = System.Net.HttpStatusCode.OK;
            restResponse.ResponseStatus = ResponseStatus.Completed;

            _restClientServiceMock.Setup(x => x.ExecuteRestClient(It.IsAny<string>(), Method.GET)).ReturnsAsync(restResponse);
            

            // call
            var result = await _weatherService.GetWeatherList(countryId, cityId);

            // assert
            Assert.True(result.Count == 1);
            Assert.True(result[0].CityName == "Jakarta");
            Assert.True(result[0].Country == "ID");
        }

        [Test]
        public async Task GetWeatherList_should_return_as_expected_on_exception()
        {
            // setup
            var countryId = 1;
            var cityId = 1;
            var restResponse = new RestResponse();
            restResponse.Content = RestContent;
            restResponse.StatusCode = System.Net.HttpStatusCode.OK;
            restResponse.ResponseStatus = ResponseStatus.Completed;

            _restClientServiceMock.Setup(x => x.ExecuteRestClient(It.IsAny<string>(), Method.GET)).ThrowsAsync(new Exception());


            // call
            var result = await _weatherService.GetWeatherList(countryId, cityId);

            // assert
            Assert.True(result.Count == 0);
        }

        [Test]
        public async Task GetWeatherList_should_return_as_expected_on_unsuccessful_call()
        {
            // setup
            var countryId = 1;
            var cityId = 1;
            var restResponse = new RestResponse();
            restResponse.StatusCode = System.Net.HttpStatusCode.Forbidden;

            _restClientServiceMock.Setup(x => x.ExecuteRestClient(It.IsAny<string>(), Method.GET)).ReturnsAsync(restResponse);


            // call
            var result = await _weatherService.GetWeatherList(countryId, cityId);

            // assert
            Assert.True(result.Count == 0);
        }

        [Test]
        public async Task ConvertToCelcius_should_return_as_expected()
        {
            // setup

            // call
            var result1 = _weatherService.ConvertToCelcius("32");
            var result2 = _weatherService.ConvertToCelcius("41");
            var result3 = _weatherService.ConvertToCelcius("50");

            // assert
            Assert.True(result1 == "0");
            Assert.True(result2 == "5");
            Assert.True(result3 == "10");
        }
    }
}
