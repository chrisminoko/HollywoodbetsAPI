using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SportAPISever.Contracts;
using SportAPISever.Model;

namespace SportAPISever.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OddsEventController : ControllerBase
    {
        private readonly IOddsEvents _oddsEvents;
        public OddsEventController(IOddsEvents IOddsEvents)
        {
            _oddsEvents = IOddsEvents;
        }

        [HttpGet]
        [Route("Search")]
        public IActionResult Get(int? id)
        {
            var results = _oddsEvents.Get(id);

            return Ok(results);
        }

        [HttpGet]

        public IActionResult Get()
        {
            var results = _oddsEvents.GetOddsEvents();
            return Ok(results);
        }


        [HttpPost]
        public int Post([FromBody] OddsEvents oddsEvents)
        {
            return _oddsEvents.Add(oddsEvents);

        }

        [HttpPut]
        public int Put([FromBody]  OddsEvents oddsEvents)
        {
            return _oddsEvents.Update(oddsEvents);
        }

        [HttpDelete("{id}")]
        public int Delete(int id)
        {
            return _oddsEvents.Delete(id);
        }
    }
}