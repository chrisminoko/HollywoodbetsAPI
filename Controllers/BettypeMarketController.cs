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
            return Ok(result);

        }


        [HttpGet]
        [Route("Search")]
        public IActionResult Get(int? id)
        {
            var results = _betTypeMarket.Get(id);
            return Ok(results);
        }


        [HttpPost]
        public int Post([FromBody] BettyepeMarkets bettyepeMarkets)
        {
            return _betTypeMarket.Add(bettyepeMarkets);

        }


        [HttpPut]
        public int Put([FromBody] BettyepeMarkets bettyepeMarkets)
        {
            return _betTypeMarket.Update(bettyepeMarkets);
        }


        [HttpDelete("{id}")]
        public int Delete(int id)
        {
            return _betTypeMarket.Delete(id);
        }
    }
}