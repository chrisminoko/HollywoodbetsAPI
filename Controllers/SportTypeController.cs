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

        [HttpGet]
        [Route("Get")]
        public IActionResult Get(int? id)
        {
            var results = _sportType.Get(id);
            try
            {
                if (results == null)
                {
                    _logger.LogError("There is no matching sports with the specified Id");
                }
            }
            catch (Exception ex)
            {

                _logger.LogError($"Something went wrong inside AddSportType action: {ex.Message}");
                return BadRequest("Invalid model object");
            }

            return Ok(results);
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
                _sportType.Add(sportTypes);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside AddSportType action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }

        }

        [HttpPut]
        public IActionResult UpdateSportType([FromBody]SportTypes sportTypes)
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

                _sportType.Update(sportTypes);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside AddSportType action: {ex.Message}");
                return BadRequest("Internal Server Error: "+ex);
            }

        }

        [HttpDelete("{id}")]

        public IActionResult DeleteSportType(int id) 
        {
            try
            {
                var sport = _sportType.Get(id);
                if (sport==null)
                {
                    _logger.LogError($"Sport with id :{id},hasn't been found in db");
                    return NotFound();
                }
                _sportType.DeleteSportTree(id);
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