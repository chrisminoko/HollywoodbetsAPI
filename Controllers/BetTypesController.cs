using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SportAPISever.Contracts;
using SportAPISever.Model;

namespace SportAPISever.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
 
    public class BetTypesController : ControllerBase
    {
        private readonly IBetType _betType;
        private readonly ILogger<BetTypesController> _logger;
        public BetTypesController(IBetType betType ,ILogger<BetTypesController> logger)
        {
            _betType = betType;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult GetTournamentBetTypes(int ? tournamentID)
        {
            var bettypes = _betType.GetEventTournament(tournamentID);
            _logger.LogInformation("Get TournamentBetypes : ");
            return Ok(bettypes);
        }

        [HttpGet]
        [Route("GetAll")]
        public IActionResult Get()
        {
            var results= _betType.GetAll();
            return Ok(results);
        }

        [HttpPost]
        public int Post([FromBody] BetTypes  betTypes)
        {
            return _betType.Add(betTypes);

        }

        
        [HttpPut]
        public int Put([FromBody] BetTypes betTypes)
        {
            return _betType.Update(betTypes);
        }

        
        [HttpDelete("{id}")]
        public int Delete(int id)
        {
            return _betType.Delete(id);
        }


    }
}