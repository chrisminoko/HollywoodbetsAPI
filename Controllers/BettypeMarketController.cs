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
    public class BettypeMarketController : ControllerBase
    {
        private readonly IBettyepeMarkets _betTypeMarket;
        private readonly ILogger<BettypeMarketController> _logger;
        public BettypeMarketController(IBettyepeMarkets bettyepeMarkets, ILogger<BettypeMarketController> logger)
        {
            _betTypeMarket = bettyepeMarkets;
            _logger = logger;
        }
        [HttpGet]
        public IActionResult Get() 
        {
            var result= _betTypeMarket.GetBetypeMarkets();
            _logger.LogInformation("Get Call forBettype market :");
            return Ok(result);

        }


        [HttpGet]
        [Route("Search")]
        public IActionResult Get(int? id)
        {
            var results = _betTypeMarket.Get(id);

            try
            {
                if (results == null)
                {
                    _logger.LogError("There is no matching Bettype with the specified Id");
                }
            }
            catch (Exception ex)
            {

                _logger.LogError($"Something went wrong inside Get Call for the Bettype market Get action: {ex.Message}");
                return BadRequest("Invalid model object");
            }

            return Ok(results);
        }


        [HttpPost]
        public IActionResult Post([FromBody] BettyepeMarkets bettyepeMarkets)
        {
            try
            {
                if (bettyepeMarkets == null)
                {
                    _logger.LogError("Bet type Market object sent from client is null.");
                    return BadRequest("Sport type object is null");
                }

                if (!ModelState.IsValid)
                {
                    _logger.LogError("Bet type Market object sent from client.");
                    return BadRequest("Invalid model object");
                }
                _betTypeMarket.Add(bettyepeMarkets);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside Post action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }

          

        }


        [HttpPut]
        public IActionResult Put([FromBody] BettyepeMarkets bettyepeMarkets)
        {

            try
            {
                if (bettyepeMarkets == null)
                {
                    _logger.LogError("Bet type Market object sent from client is null.");
                    return BadRequest("Sport type object is null");
                }

                if (!ModelState.IsValid)
                {
                    _logger.LogError("Bet type Market owner object sent from client.");
                    return BadRequest("Invalid model object");
                }

                _betTypeMarket.Update(bettyepeMarkets);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside Edit action: {ex.Message}");
                return BadRequest("Internal Server Error: " + ex);
            }

        }


        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {

            try
            {
                var sport = _betTypeMarket.Get(id);
                if (sport == null)
                {
                    _logger.LogError($"Sport with id :{id},hasn't been found in db");
                    return NotFound();
                }
                _betTypeMarket.Delete(id);
                return NoContent();
            }
            catch (Exception ex)
            {

                _logger.LogError($"Something went wrong inside DeleteSportType action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}