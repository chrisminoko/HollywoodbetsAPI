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

        public IActionResult GetEvent(int id) 
        {
            var results = _eventMarket.GetEventsDetails(id);
            return Ok(results);
        }
    }
}