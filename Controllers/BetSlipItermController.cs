using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SportAPISever.Contracts;
using Microsoft.Extensions.Logging;
using SportAPISever.Model;

namespace SportAPISever.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BetSlipItermController : ControllerBase
    {
        private readonly IBetSlipItem _Ibetslipiterm;
        private readonly ILogger<BetSlipItermController> _logger;
        public BetSlipItermController(IBetSlipItem betSlipItem, ILogger<BetSlipItermController> logger)
        {
            _Ibetslipiterm = betSlipItem;
            _logger = logger;
        }

        [HttpPost]
        public IActionResult BetStrike(BetSlipIterm betSlipIterm)
        {

            try
            {
                if (betSlipIterm == null)
                {
                    _logger.LogError("betSlipIterm object sent from client is null.");
                    return BadRequest("betSlipIterm object is null");
                   
                }

                if (!ModelState.IsValid)
                {
                    _logger.LogError("betSlipIterm object sent from client.");
                    return BadRequest("Invalid model object");
                }
                _Ibetslipiterm.Add(betSlipIterm);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside BetStrike action: {ex.Message}");
                return StatusCode(500, "Internal server error"+ex);
            }

        }
    }
}