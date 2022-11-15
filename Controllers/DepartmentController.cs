using AutoMapper;
using EmployeeClass.Dto;
using EmployeeClass.Model;
using EmployeeClass.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeClass.Controllers
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
        public async Task<IActionResult> GetAllDepAsync()
        {
            var dep =  await _departmentService.GetAllDepartment();

            return Ok(dep);
        }

        [HttpPost]
        public async Task<IActionResult> AddDepartmentsync([FromForm] DeparmentDto dto)
        {
            if (dto == null)
                return NotFound();

            var map = _mapper.Map<Department>(dto);


            var dep =await _departmentService.PostDepartment(map);

            return Ok(dep);
        }
        [HttpDelete("{id}")]

        public async Task<IActionResult> DeleteDepartmentAsync(byte id)
        {
            var department = await _departmentService.GetDepartmentById(id);

            var dep =  _departmentService.DeleteDepartment(department);

            return Ok(department);

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> updateTheDepartment(byte id, [FromBody] DeparmentDto dto)
        {
            var dep = await _departmentService.GetDepartmentById(id);

            if(dep is null)
            {
                return NotFound();
            }

            var map = _mapper.Map<Department>(dto);

            var deparment = _departmentService.UpdateDepartment(map);

            return Ok(deparment);
        }
    }
}
