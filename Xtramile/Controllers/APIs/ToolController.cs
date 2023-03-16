using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Xtramile.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Xtramile.Controllers.APIs
{
    [Route("api/tool")]
    [ApiController]
    public class ToolController : ControllerBase
    {
        [HttpGet, Route("country")]
        public List<Country> GetCountries()
        {
            return Constant.GetListOfCountries();
        }

        [HttpGet, Route("city/{countryId}")]
        public List<City> Get([FromRoute] int countryId)
        {
            return Constant.GetListOfCities().Where(x => x.CountryId == countryId).ToList();
        }
    }
}
