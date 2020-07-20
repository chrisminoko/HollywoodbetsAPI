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
    public class TournamentBettpeController : ControllerBase
    {
        private readonly ITournamentBettype _tournamentBettype;
        public TournamentBettpeController(ITournamentBettype tournamentBettype)
        {
            _tournamentBettype = tournamentBettype;
        }

        [HttpGet]
        [Route("Search")]
        public IActionResult Get(int? id)
        {
            var results = _tournamentBettype.Get(id);

            return Ok(results);
        }

        [HttpGet]
        
        public IActionResult Get()
        {
            var results = _tournamentBettype.GetTournamentBettypes();
            return Ok(results);
        }


        [HttpPost]
        public int Post([FromBody] TournamentBeTypes tournamentBeTypes)
        {
            return _tournamentBettype.Add(tournamentBeTypes);

        }

        [HttpPut]
        public int Put([FromBody]  TournamentBeTypes tournamentBeTypes)
        {
            return _tournamentBettype.Update(tournamentBeTypes);
        }

        [HttpDelete("{id}")]
        public int Delete(int id)
        {
            return _tournamentBettype.Delete(id);
        }
    }
}