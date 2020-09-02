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
    public class EventMarketController : ControllerBase
    {
        private readonly IEventMarket _eventMarket;
        public EventMarketController(IEventMarket eventMarket)
        {
            _eventMarket = eventMarket;
        }

        [HttpGet]
        public IActionResult GetEvent(int ? tournamentID) 
        {
            var results = _eventMarket.GetEventsDetails(tournamentID);
            return Ok(results);
        }
    }
}