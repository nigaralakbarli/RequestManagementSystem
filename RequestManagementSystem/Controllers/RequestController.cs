using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RequestManagementSystem.DataAccess.Interfaces;

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




    }
}
