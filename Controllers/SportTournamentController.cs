using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SportAPISever.Contracts;
using SportAPISever.Model;

namespace SportAPISever.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SportTournamentController : ControllerBase
    {
        private readonly ISportTournament _sportTournament;
        private readonly ILogger<SportTournamentController> _logger;
        public SportTournamentController(ISportTournament sportTournament, ILogger<SportTournamentController> logger)
        {
            _sportTournament = sportTournament;
            _logger = logger;
        }


        [HttpGet]
        [Route("GetAll")]
        public IActionResult Get()
        {
            var results = _sportTournament.GetAll();
            return Ok(results);
        }

        [HttpGet]
        [Route("GetDetails")]
        public IActionResult GetDetails()
        {
            var results = _sportTournament.GetSportCountryTournaments();
            return Ok(results);
        }

        [HttpGet]
        [Route("Search")]
        public IActionResult Get(int? id)
        {
            var results = _sportTournament.Get(id);
            return Ok(results);
        }


        [HttpPost]
        public int Post([FromBody] SportTournament  sportTournament)
        {
            return _sportTournament.Add(sportTournament);

        }


        [HttpPut]
        public int Put([FromBody] SportTournament sportTournament)
        {
            return _sportTournament.Update(sportTournament);
        }


        [HttpDelete("{id}")]
        public int Delete(int id)
        {
            return _sportTournament.Delete(id);
        }
    }
}