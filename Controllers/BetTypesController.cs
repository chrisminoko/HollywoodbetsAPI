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
 
    public class BetTypesController : ControllerBase
    {
        private readonly IBetType _betType;
        public BetTypesController(IBetType betType)
        {
            _betType = betType;
        }

        [HttpGet]
        public IActionResult GetTournamentBetTypes(int ? tournamentID)
        {
            var bettypes = _betType.GetEventTournament(tournamentID);
            return Ok(bettypes);
        }
    }
}