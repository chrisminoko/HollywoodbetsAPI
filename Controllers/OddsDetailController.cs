using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SportAPISever.Contracts;

namespace SportAPISever.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OddsDetailController : ControllerBase
    {
        private readonly IOddsDetails _oddsDetails;
        public OddsDetailController(IOddsDetails oddsDetails)
        {
            _oddsDetails = oddsDetails;
        }

        [HttpGet]
        public IActionResult GetOdds(int? tournamentID) 
        {
            var results= _oddsDetails.GetOddsDetails(tournamentID);
            return Ok(results);
        }
    }
}