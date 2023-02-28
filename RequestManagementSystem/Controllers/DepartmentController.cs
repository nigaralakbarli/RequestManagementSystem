using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RequestManagementSystem.Data.Models;
using RequestManagementSystem.DataAccess.Interfaces;
using RequestManagementSystem.DataAccess.Services;
using RequestManagementSystem.Dtos.Request;
using RequestManagementSystem.Dtos.Response;

namespace RequestManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentService _departmentService;
        private readonly IMapper _mapper;

        public DepartmentController(IDepartmentService departmentService, IMapper mapper)
        {
            _departmentService = departmentService;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Department>))]
        public IActionResult GetDepartments()
        {
            var departments = _mapper.Map<List<DepartmentResponseDto>>(_departmentService.GetAll());

            return Ok(departments);
        }


        [HttpGet("{departmentId}")]
        [ProducesResponseType(200, Type = typeof(Department))]
        [ProducesResponseType(400)]
        public IActionResult GetDepartment(int departmentId)
        {
            if (!_departmentService.DepartmentExists(departmentId))
                return NotFound();

            var department = _mapper.Map<DepartmentResponseDto>(_departmentService.GetById(departmentId));

            return Ok(department);
        }


        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateDepartment([FromBody] DepartmentRequestDto departmentCreate)
        {

            //new
            if (departmentCreate == null)
                return BadRequest(ModelState);

            var department = _departmentService.GetAll()
                .Where(c => c.Name.Trim().ToUpper() == departmentCreate.Name.TrimEnd().ToUpper())
                .FirstOrDefault();

            if (department != null)
            {
                ModelState.AddModelError("", "Department already exists");
                return StatusCode(422, ModelState);
            }

            var departmentMap = _mapper.Map<Department>(departmentCreate);

            if (!_departmentService.Create(departmentMap))
            {
                ModelState.AddModelError("", "Something went wrong while savin");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully created");
        }


        [HttpPut("{departmentId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult UpdateDepartment(int departmentId, [FromBody] DepartmentRequestDto updatedDepartment)
        {
            if (updatedDepartment == null)
                return BadRequest(ModelState);

            if (departmentId != updatedDepartment.Id)
                return BadRequest(ModelState);

            if (!_departmentService.DepartmentExists(departmentId))
                return NotFound();

            var departmentMap = _mapper.Map<Department>(updatedDepartment);

            if (!_departmentService.Update(departmentMap))
            {
                ModelState.AddModelError("", "Something went wrong updating department");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }


        [HttpDelete("{departmentId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeleteDepartment(int departmentId)
        {
            if (!_departmentService.DepartmentExists(departmentId))
            {
                return NotFound();
            }

            var departmentToDelete = _departmentService.GetById(departmentId);

            if (!_departmentService.Delete(departmentToDelete))
            {
                ModelState.AddModelError("", "Something went wrong deleting department");
            }

            return NoContent();
        }

    }
}
