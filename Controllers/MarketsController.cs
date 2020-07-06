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
    }
}