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
    public class MarketsController : ControllerBase
    {
        private readonly IMarket _market;
        public MarketsController(IMarket market)
        {
            _market = market;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var markets = _market.GetAll();
            return Ok(markets);
        }

        [HttpGet]
        [Route("Search")]
        public IActionResult Get(int? id)
        {
            var results = _market.Get(id);
            return Ok(results);
        }


        [HttpPost]
        public int Post([FromBody] Market market)
        {
            return _market.Add(market);

        }


        [HttpPut]
        public int Put([FromBody] Market market)
        {
            return _market.Update(market);
        }


        [HttpDelete("{id}")]
        public int Delete(int id)
        {
            return _market.Delete(id);
        }
    }
}