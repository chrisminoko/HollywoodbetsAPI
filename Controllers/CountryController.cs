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
    public class CountryController : ControllerBase
    {
        private readonly ICountry _country;
    
        public CountryController(ICountry country)
        {
            _country = country;
            
        }
        [HttpGet]
        public IActionResult GetCountrySport(int ? sportid) 
        {
            var results = _country.GetSportCountry(sportid);
       
            return Ok(results);
        }

        [HttpGet]
        [Route("GetAll")]
        public IActionResult Get()
        {
            var results = _country.GetAll();
            return Ok(results);
        }

        [HttpPost]
        public int Post([FromBody] Country country)
        {
            return _country.Add(country);

        }


        [HttpPut]
        public int Put([FromBody] Country country)
        {
            return _country.Update(country);
        }


        [HttpDelete("{id}")]
        public int Delete(int id)
        {
            return _country.Delete(id);
        }


    }
}