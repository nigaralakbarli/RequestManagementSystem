using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RequestManagementSystem.Data.Models;
using RequestManagementSystem.DataAccess.Interfaces;
using RequestManagementSystem.DataAccess.Services;
using RequestManagementSystem.Dtos;
using System.ComponentModel.DataAnnotations;

namespace RequestManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestController : ControllerBase
    {
        private readonly IRequestService _requestService;
        private readonly IMapper _mapper;

        public RequestController(IRequestService requestService, IMapper mapper)
        {
            _requestService = requestService;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Request>))]
        public IActionResult GetRequests()
        {
            var requests = _mapper.Map<List<RequestDto>>(_requestService.GetAll());
            return Ok(requests);
        }


        [HttpGet("{requestId}")]
        [ProducesResponseType(200, Type = typeof(Request))]
        [ProducesResponseType(400)]
        public IActionResult GetRequest(int requestId) 
        {
            if (!_requestService.RequestExists(requestId))
                return NotFound();

            var category = _mapper.Map<RequestDto>(_requestService.GetById(requestId));

            return Ok(category);
        }


        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateRequest([FromBody][Required] RequestDto requestCreate)
        {
            var request = _requestService.GetAll()
                .Where(c => c.Title.Trim().ToUpper() == requestCreate.Title.TrimEnd().ToUpper())
                .FirstOrDefault();

            if (request != null)
            {
                ModelState.AddModelError("", "Request already exists");
                return StatusCode(422, ModelState);
            }

            var requestMap = _mapper.Map<Request>(requestCreate);

            if (!_requestService.Create(requestMap))
            {
                ModelState.AddModelError("", "Something went wrong while savin");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully created");
        }


        [HttpPut("{requestId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult UpdateRequest(int requestId, [FromBody] RequestDto updatedRequest)
        {
            if (updatedRequest == null)
                return BadRequest(ModelState);

            if (requestId != updatedRequest.Id)
                return BadRequest(ModelState);

            if (!_requestService.RequestExists(requestId))
                return NotFound();

            var requestMap = _mapper.Map<Request>(updatedRequest);

            if (!_requestService.Update(requestMap))
            {
                ModelState.AddModelError("", "Something went wrong updating request");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }


        [HttpDelete("{requestId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeleteRequest(int requestId)
        {
            if (!_requestService.RequestExists(requestId))
            {
                return NotFound();
            }

            var requestToDelete = _requestService.GetById(requestId);

            if (!_requestService.Delete(requestToDelete))
            {
                ModelState.AddModelError("", "Something went wrong deleting request");
            }

            return NoContent();
        }
    }
}
