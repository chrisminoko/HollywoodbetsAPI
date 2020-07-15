using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SportAPISever.Contracts;
using SportAPISever.Model;

namespace SportAPISever.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SportCountryController : ControllerBase
    {
        private readonly ISportCountry _sportcountry;
        private readonly ILogger<SportCountryController> _logger;
        public SportCountryController(ISportCountry sportCountry, ILogger<SportCountryController> logger)
        {
            _sportcountry = sportCountry;
            _logger = logger;
        }


        [HttpGet]
        [Route("GetAll")]
        public IActionResult Get()
        {
            var results = _sportcountry.GetAll();
            return Ok(results);
        }

        [HttpGet]
        [Route("Search")]
        public IActionResult Get(int? id)
        {
            var results = _sportcountry.Get(id);
            return Ok(results);
        }


        [HttpPost]
        public int Post([FromBody] SportCountry sportCountry)
        {
            return _sportcountry.Add(sportCountry);

        }


        [HttpPut]
        public int Put([FromBody] SportCountry sportCountry)
        {
            return _sportcountry.Update(sportCountry);
        }


        [HttpDelete("{id}")]
        public int Delete(int id)
        {
            return _sportcountry.Delete(id);
        }
    }
}