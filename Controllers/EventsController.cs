using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SportAPISever.Contracts;

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

        //[HttpGet]
        //public IActionResult GetEventsByTournamentID(int? TournamentID) 
        //{
        //    var Tournaments = _events.GetTournamentEventsByID(TournamentID);
        //    return Ok(Tournaments);
        //}


        [HttpGet]
        public IActionResult GetBetEvents(int? tournamentID)
        {
            var Tournaments = _events.GetBetEvents(tournamentID);
            return Ok(Tournaments);
        }
    }
}