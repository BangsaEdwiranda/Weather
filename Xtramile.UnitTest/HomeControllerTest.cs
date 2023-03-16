using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System;
using System.Threading.Tasks;
using Xtramile.Controllers;
using Xtramile.Services;
using Xtramile.Services.DTOs;

namespace Xtramile.UnitTest
{
    public class HomeControllerTest
    {
        private readonly HomeController _homeController;
        private readonly Mock<IWeatherService> _weatherServiceMock;

        public HomeControllerTest() {

            _weatherServiceMock = new Mock<IWeatherService>();
            _homeController = new HomeController(_weatherServiceMock.Object);

        }

        [Test]
        public async Task ExtendedWeather_should_return_as_expected_on_success()
        {
            // setup
            var countryId = 1;
            var cityId = 1;
            var expectedView = "ExtendedWeather";

            // call
            _weatherServiceMock.Setup(x => x.GetWeatherList(It.IsAny<int>(), It.IsAny<int>())).ReturnsAsync(new System.Collections.Generic.List<ExtendedWeatherDTO>());

            var viewResult = (await _homeController.ExtendedWeather(countryId, cityId)) as ViewResult;

            // assert
            Assert.AreEqual(viewResult.ViewName, expectedView);
        }

        [Test]
        public async Task ExtendedWeather_should_return_as_expected_on_error()
        {
            // setup
            var countryId = 1;
            var cityId = 1;
            var expectedView = "Error";

            // call
            _weatherServiceMock.Setup(x => x.GetWeatherList(It.IsAny<int>(), It.IsAny<int>())).ThrowsAsync(new Exception());

            var viewResult = (await _homeController.ExtendedWeather(countryId, cityId)) as ViewResult;

            // assert
            Assert.AreEqual(viewResult.ViewName, expectedView);
        }
    }
}