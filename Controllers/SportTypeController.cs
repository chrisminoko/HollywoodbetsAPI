using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SportAPISever.Contracts;
using SportAPISever.Model;

namespace SportAPISever.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("MyPolicy")]
    public class SportTypeController : ControllerBase
    {
        private readonly ISportType _sportType;
        public SportTypeController(ISportType sportType)
        {
            _sportType = sportType;
        }

        [HttpGet]
        public IActionResult GetAll() 
        {
            var GetAllSportTypes = _sportType.GetAll();
            return Ok(GetAllSportTypes);
          
        }
    }
}