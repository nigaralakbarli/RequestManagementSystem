using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RequestManagementSystem.Data.Models;
using RequestManagementSystem.DataAccess.Interfaces;
using RequestManagementSystem.DataAccess.Services;
using RequestManagementSystem.Dtos;

namespace RequestManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PriorityController : ControllerBase
    {
        private readonly IPriorityService _priorityService;
        private readonly IMapper _mapper;

        public PriorityController(IPriorityService priorityService, IMapper mapper)
        {
            _priorityService= priorityService;
            _mapper= mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Priority>))]
        public IActionResult GetPriorities()
        {
            var priorities = _mapper.Map<List<PriorityDto>>(_priorityService.GetAll());

            return Ok(priorities);
        }


        [HttpGet("{priorityId}")]
        [ProducesResponseType(200, Type = typeof(Priority))]
        [ProducesResponseType(400)]
        public IActionResult GetPriority(int priorityId)
        {
            if (!_priorityService.PriorityExists(priorityId))
                return NotFound();

            var priority = _mapper.Map<PriorityDto>(_priorityService.GetById(priorityId));

            return Ok(priority);
        }


        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreatePriority([FromBody] PriorityDto priorityCreate)
        {

            //new
            if (priorityCreate == null)
                return BadRequest(ModelState);

            var priority = _priorityService.GetAll()
                .Where(c => c.Level.Trim().ToUpper() == priorityCreate.Level.TrimEnd().ToUpper())
                .FirstOrDefault();

            if (priority != null)
            {
                ModelState.AddModelError("", "Priority already exists");
                return StatusCode(422, ModelState);
            }

            var priorityMap = _mapper.Map<Priority>(priorityCreate);

            if (!_priorityService.Create(priorityMap))
            {
                ModelState.AddModelError("", "Something went wrong while savin");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully created");
        }


        [HttpPut("{priorityId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult UpdatePriority(int priorityId, [FromBody] PriorityDto updatedPriority)
        {
            if (updatedPriority == null)
                return BadRequest(ModelState);

            if (priorityId != updatedPriority.Id)
                return BadRequest(ModelState);

            if (!_priorityService.PriorityExists(priorityId))
                return NotFound();

            var priorityMap = _mapper.Map<Priority>(updatedPriority);

            if (!_priorityService.Update(priorityMap))
            {
                ModelState.AddModelError("", "Something went wrong updating priority");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }


        [HttpDelete("{priorityId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeletePriority(int priorityId)
        {
            if (!_priorityService.PriorityExists(priorityId))
            {
                return NotFound();
            }

            var priorityToDelete = _priorityService.GetById(priorityId);

            if (!_priorityService.Delete(priorityToDelete))
            {
                ModelState.AddModelError("", "Something went wrong deleting priority");
            }

            return NoContent();
        }


        [HttpGet("{priorityId}/requests")]
        public IActionResult GetRequestsByCategory(int priorityId)
        {
            if (!_priorityService.PriorityExists(priorityId))
                return NotFound();

            var requests = _mapper.Map<List<RequestDto>>(
                _priorityService.GetRequestsByPriority(priorityId));

            return Ok(requests);
        }
    }
}
