using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RequestManagementSystem.Data.Models;
using RequestManagementSystem.DataAccess.Interfaces;
using RequestManagementSystem.DataAccess.Models;
using RequestManagementSystem.DataAccess.Services;
using RequestManagementSystem.Dtos.Request;
using RequestManagementSystem.Dtos.Response;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Security.Claims;

namespace RequestManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestController : ControllerBase
    {
        private readonly IRequestService _requestService;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;


        public RequestController(IRequestService requestService, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _requestService = requestService;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        }



        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Request>))]
        public IActionResult GetRequests(int pageIndex = 1, int pageSize = 2)
        {
            var categories = _mapper.Map<List<RequestResponseDto>>(_requestService.GetAll(pageIndex,pageSize));
            return Ok(categories);
        }
        

        [Route("/filtered")]
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Request>))]
        public IActionResult GetRequestsByFilters([FromQuery] RequestList requestList)
        {
            var requests = _requestService.GetList(_mapper.Map<ListRequest>(requestList));
            var mapRequests = _mapper.Map<List<RequestResponseDto>>(requests);
            return Ok(mapRequests);
        }


        //[HttpGet("{requestId}")]
        //[ProducesResponseType(200, Type = typeof(Request))]
        //[ProducesResponseType(400)]
        //public IActionResult GetRequest(int requestId) 
        //{
        //    if (!_requestService.RequestExists(requestId))
        //        return NotFound();

        //    var category = _mapper.Map<RequestResponseDto>(_requestService.GetById(requestId));

        //    return Ok(category);
        //}

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateRequest([FromBody][Required] RequestRequestDto requestCreate)
        {
            var request = _requestService.GetAll()
                .Where(c => c.Title.Trim().ToUpper() == requestCreate.Title.TrimEnd().ToUpper())
                .FirstOrDefault();

            if (request != null)
            {
                ModelState.AddModelError("", "Request already exists");
                return StatusCode(422, ModelState);
            }
            requestCreate.CreateUserId = Convert.ToInt32(_httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);
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
        public IActionResult UpdateRequest(int requestId, [FromBody] RequestRequestDto updatedRequest)
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


        [Route("/ChangeStatus")]
        [HttpPut]
        public IActionResult ChangeStatus([FromQuery] ActionRequestDto actionRequest)
        {
            if (actionRequest == null)
                return BadRequest(ModelState);

            if (!_requestService.RequestExists(actionRequest.RequestId))
                return NotFound();

            var requestMap = _mapper.Map<Request>(actionRequest);

            if (!_requestService.UpdateRequestStatus(actionRequest.RequestId, actionRequest.RequestStatusId))
            {
                ModelState.AddModelError("", "Something went wrong updating request status");
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

        //[HttpGet("[action]/{categoryName}")]
        //public IActionResult GetByCategory(string categoryName, int pageIndex=1, int pageSize=2)
        //{
        //    var filteredRequest = _requestService.GetRequestsByCategory(categoryName);
        //    filteredRequest = _requestService.GetByPage(pageIndex, pageSize, filteredRequest);
        //    var mapRequest = _mapper.Map<List<RequestResponseDto>>(filteredRequest);
        //    return Ok(mapRequest);
        //}

        //public string GetCurrentUser()
        //{
        //    var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
        //    return userId;
        //}
    }
}
