using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RequestManagementSystem.Data.Models;
using RequestManagementSystem.DataAccess.Interfaces;
using RequestManagementSystem.DataAccess.Services;
using RequestManagementSystem.Dtos.Request;
using RequestManagementSystem.Dtos.Response;
using System.ComponentModel.DataAnnotations;

namespace RequestManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestStatusController : ControllerBase
    {
        private readonly IRequestStatusService _requestStatusService;
        private readonly IMapper _mapper;

        public RequestStatusController(IRequestStatusService requestStatusService, IMapper mapper)
        {
            _requestStatusService = requestStatusService;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<RequestStatus>))]
        public IActionResult GetRequestStatuses()
        {
            var categories = _mapper.Map<List<RequestStatusResponseDto>>(_requestStatusService.GetAll());
            return Ok(categories);
        }


        [HttpGet("{requestStatusId}")]
        [ProducesResponseType(200, Type = typeof(RequestStatus))]
        [ProducesResponseType(400)]
        public IActionResult GetRequestStatus(int requestStatusId)
        {
            if (!_requestStatusService.RequestStatusExists(requestStatusId))
                return NotFound();

            var requestStatus = _mapper.Map<RequestStatusResponseDto>(_requestStatusService.GetById(requestStatusId));

            return Ok(requestStatus);
        }


        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateRequestStatus([FromBody][Required] RequestStatusRequestDto requestStatusCreate)
        {
            var requestStatus = _requestStatusService.GetAll()
                .Where(c => c.Name.Trim().ToUpper() == requestStatusCreate.Name.TrimEnd().ToUpper())
                .FirstOrDefault();

            if (requestStatus != null)
            {
                ModelState.AddModelError("", "RequestStatus already exists");
                return StatusCode(422, ModelState);
            }

            var requestStatusMap = _mapper.Map<RequestStatus>(requestStatusCreate);

            if (!_requestStatusService.Create(requestStatusMap))
            {
                ModelState.AddModelError("", "Something went wrong while savin");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully created");
        }


        [HttpPut("{requestStatusId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult RequestStatus(int requestStatusId, [FromBody] RequestStatusRequestDto updatedRequestStatus)
        {
            if (updatedRequestStatus == null)
                return BadRequest(ModelState);

            if (requestStatusId != updatedRequestStatus.Id)
                return BadRequest(ModelState);

            if (!_requestStatusService.RequestStatusExists(requestStatusId))
                return NotFound();

            var requestStatusMap = _mapper.Map<RequestStatus>(updatedRequestStatus);

            if (!_requestStatusService.Update(requestStatusMap))
            {
                ModelState.AddModelError("", "Something went wrong updating RequestStatus");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }


        [HttpDelete("{requestStatusId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeleteRequestStatus(int requestStatusId)
        {
            if (!_requestStatusService.RequestStatusExists(requestStatusId))
            {
                return NotFound();
            }

            var requestStatusToDelete = _requestStatusService.GetById(requestStatusId);

            if (!_requestStatusService.Delete(requestStatusToDelete))
            {
                ModelState.AddModelError("", "Something went wrong deleting RequestStatus");
            }

            return NoContent();
        }

    }

}
