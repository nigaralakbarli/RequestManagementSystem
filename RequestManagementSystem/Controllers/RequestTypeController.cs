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
    public class RequestTypeController : ControllerBase
    {
        private readonly IRequestTypeService _requestTypeService;
        private readonly IMapper _mapper;

        public RequestTypeController(IRequestTypeService requestTypeService, IMapper mapper)
        {
            _requestTypeService = requestTypeService;
            _mapper = mapper;
        }


        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<RequestType>))]
        public IActionResult GetRequestTypes()
        {
            var requestTypes = _mapper.Map<List<RequestTypeDto>>(_requestTypeService.GetAll());
            return Ok(requestTypes);
        }


        [HttpGet("{requestTypeId}")]
        [ProducesResponseType(200, Type = typeof(RequestType))]
        [ProducesResponseType(400)]
        public IActionResult GetRequestType(int requestTypeId)
        {
            if (!_requestTypeService.RequestTypeExists(requestTypeId))
                return NotFound();

            var requestType = _mapper.Map<RequestTypeDto>(_requestTypeService.GetById(requestTypeId));

            return Ok(requestType);
        }


        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateRequestType([FromBody][Required] RequestTypeDto requestTypeCreate)
        {
            var requestType = _requestTypeService.GetAll()
                .Where(c => c.Name.Trim().ToUpper() == requestTypeCreate.Name.TrimEnd().ToUpper())
                .FirstOrDefault();

            if (requestType != null)
            {
                ModelState.AddModelError("", "RequestType already exists");
                return StatusCode(422, ModelState);
            }

            var requestTypeMap = _mapper.Map<RequestType>(requestTypeCreate);

            if (!_requestTypeService.Create(requestTypeMap))
            {
                ModelState.AddModelError("", "Something went wrong while savin");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully created");
        }


        [HttpPut("{requestTypeId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult UpdateRequestType(int requestTypeId, [FromBody] RequestTypeDto updatedRequestType)
        {
            if (updatedRequestType == null)
                return BadRequest(ModelState);

            if (requestTypeId != updatedRequestType.Id)
                return BadRequest(ModelState);

            if (!_requestTypeService.RequestTypeExists(requestTypeId))
                return NotFound();

            var requestTypeMap = _mapper.Map<RequestType>(updatedRequestType);

            if (!_requestTypeService.Update(requestTypeMap))
            {
                ModelState.AddModelError("", "Something went wrong updating RequestType");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }


        [HttpDelete("{requestTypeId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeleteRequestType(int requestTypeId)
        {
            if (!_requestTypeService.RequestTypeExists(requestTypeId))
            {
                return NotFound();
            }

            var requestTypeToDelete = _requestTypeService.GetById(requestTypeId);

            if (!_requestTypeService.Delete(requestTypeToDelete))
            {
                ModelState.AddModelError("", "Something went wrong deleting RequestType");
            }

            return NoContent();
        }
        

        [HttpGet("{requestTypeId}/requests")]
        public IActionResult GetRequestsByCategory(int requestTypeId)
        {
            if (!_requestTypeService.RequestTypeExists(requestTypeId))
                return NotFound();
            var requests = _mapper.Map<List<RequestDto>>(
                _requestTypeService.GetRequestsByRequestType(requestTypeId));

            return Ok(requests);
        }


    }

}
