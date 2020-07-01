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
    public class TournamentController : ControllerBase
    {
        private readonly ITournament _tournament;
        public TournamentController(ITournament tournament)
        {
            _tournament = tournament;
        }
        [HttpGet]
        public IActionResult GetTournamentBasedOnCountries(int? countryid)
        {
            var tournaments = _tournament.GetTournamentBasedOnCountries(countryid);
            return Ok(tournaments);
        }
    }
}