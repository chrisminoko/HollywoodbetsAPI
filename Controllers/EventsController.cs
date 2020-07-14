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
    public class EventsController : ControllerBase
    {
        private readonly IEvents _events;
        public EventsController(IEvents events)
        {
            _events = events;
        }

        [HttpGet]
        public IActionResult GetEventsByTournamentID(int? TournamentID)
        {
            var Tournaments = _events.GetTournamentEventsByID(TournamentID);
            return Ok(Tournaments);
        }

        [HttpGet]
        [Route("GetAll")]
        public IActionResult Get()
        {
            var results = _events.GetAll();
            return Ok(results);
        }

        [HttpGet]
        [Route("Search")]
        public IActionResult Get(int? id)
        {
            var results = _events.Get(id);
            return Ok(results);
        }


        [HttpPost]
        public int Post([FromBody] Events events)
        {
            return _events.Add(events);

        }


        [HttpPut]
        public int Put([FromBody] Events events)
        {
            return _events.Update(events);
        }


        [HttpDelete("{id}")]
        public int Delete(int id)
        {
            return _events.Delete(id);
        }


    }
}