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
    [EnableCors("MyPolicy")]

    public class SportTypeController : ControllerBase
    {
        private readonly ISportType _sportType;
        private readonly ILogger<SportTypeController> _logger;
        public SportTypeController(ISportType sportType, ILogger<SportTypeController> logger)
        {
            _sportType = sportType;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var GetAllSportTypes = _sportType.GetAll();
            _logger.LogInformation("Get Call for Sport Types :");
            return Ok(GetAllSportTypes);
        }

        [HttpPost]
        public IActionResult AddSportType(SportTypes sportTypes)
        {

            try
            {
                if (sportTypes == null)
                {
                    _logger.LogError("Sport type object sent from client is null.");
                    return BadRequest("Sport type object is null");
                }

                if (!ModelState.IsValid)
                {
                    _logger.LogError("Sport type owner object sent from client.");
                    return BadRequest("Invalid model object");
                }

                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside AddSportType action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }

        }

        [HttpPut("{id}")]
        public IActionResult UpdateSportType(Guid id, [FromBody]SportTypes sportTypes)
        {
            try
            {
                if (sportTypes == null)
                {
                    _logger.LogError("Sport type object sent from client is null.");
                    return BadRequest("Sport type object is null");
                }

                if (!ModelState.IsValid)
                {
                    _logger.LogError("Sport type owner object sent from client.");
                    return BadRequest("Invalid model object");
                }

                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside AddSportType action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }

        }
    }
}