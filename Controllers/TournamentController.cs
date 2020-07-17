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
        [HttpGet]
        [Route("Search")]
        public IActionResult Get(int? id)
        {
            var results = _tournament.Get(id);

            return Ok(results);
        }

        [HttpGet]
        [Route("GetAll")]
        public IActionResult Get()
        {
            var results = _tournament.GetAll();
            return Ok(results);
        }

        [HttpGet]
        [Route("TournamentBettype")]
        public IActionResult GetTournamentBettype()
        {
            var results = _tournament.GetTournamentBettypes();
            return Ok(results);
        }

        [HttpPost]
        public int Post([FromBody] Tournament tournament)
        {
            return _tournament.Add(tournament);

        }


        [HttpPut]
        public int Put([FromBody] Tournament tournament)
        {
            return _tournament.Update(tournament);
        }


        [HttpDelete("{id}")]
        public int Delete(int id)
        {
            return _tournament.Delete(id);
        }

    }
}