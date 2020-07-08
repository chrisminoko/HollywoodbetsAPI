using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SportAPISever.Contracts;

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
    }
}