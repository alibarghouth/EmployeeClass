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
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        private readonly IMapper _mapper;

        private readonly IDepartmentService _departmentService;


        private List<string> _alloExtensionsForImg = new List<string>()
        {
            ".jpg",
            ".png"
        };
        private List<string> _alloExtensionsForvideo = new List<string>()
        {
            ".mp4",
            ".ff"
        };

        private double _allowSizeForImg = 1048576;

        private double _allowSizeForVideo = 1048576777777;


        public EmployeeController(IEmployeeService employeeService, IMapper mapper, IDepartmentService departmentService)
        {
            _employeeService = employeeService;
            _mapper = mapper;
            _departmentService = departmentService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var employee =  await _employeeService.GetAllEmployee();


            return Ok(employee);
        }

        [HttpGet("EmpId")]
        public async Task<IActionResult> GetEmpByDepId(byte id)
        {
            var emp = await _employeeService.GetAllEmployee(id);
            return Ok(emp); 
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployeeById(int id)
        {
            var employee =await _employeeService.GetEmployeeById(id);
            return Ok(employee);
        }

        [HttpGet("{name}")]
        public async Task<IActionResult> GetEmployeeByName(string name)
        {
            var employee =await _employeeService.GetEmployeeByName(name);

            return Ok(employee);
        }

        [HttpPost]
        public async Task<IActionResult> AddEmployee([FromForm] EmployeeCreateDto employee)
        {
            if (!_alloExtensionsForImg.Contains(Path.GetExtension(employee.MyImg.FileName)))
            {
                return BadRequest("The Image Is Reqiuered");
            }
            
            if (employee.MyImg.Length > _allowSizeForImg)
            {
                return BadRequest("The Size Image Is High");
            }
            if (!_alloExtensionsForvideo.Contains(Path.GetExtension(employee.MyVideo.FileName)))
            {
                return BadRequest("The Video Is Reqiuered");
            }
            
            if (employee.MyVideo.Length > _allowSizeForVideo)
            {
                return BadRequest("The Size Video Is High");
            }


            var isValid = await _departmentService.isValid(employee.DepartmentId);

            if (!isValid)
            {
                return BadRequest("The Department Is Not Valid");
            }

            using var imgStream = new MemoryStream();
            await employee.MyImg.CopyToAsync(imgStream);
            await employee.MyVideo.CopyToAsync(imgStream);



            var emp = _mapper.Map<Employee>(employee);
            emp.MyImg = imgStream.ToArray();
            emp.MyVideo = imgStream.ToArray();


            var employees =await _employeeService.AddEmployee(emp);

   

            return Ok(employees);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployeeAsync(int id)
        {
            var emp = await _employeeService.GetEmployeeById(id);
            if(emp is null)
            {
                return NotFound();
            }

            var employee = _employeeService.DeleteEmployee(emp);

            return Ok(employee);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEmployeeAsync(int id,[FromForm] EmployeeUpdateDto dto)
        {
            var emp= await _employeeService.GetEmployeeById(id); 

            
            if(emp is null)
            {
                return NotFound("The Emp Is Not Found");
            }
               
            

            if(dto.MyImg != null)
            {
                if (!_alloExtensionsForImg.Contains(Path.GetExtension(dto.MyImg.FileName)))
                {
                    return BadRequest("The Image Is Reqiuered");
                }

                if (dto.MyImg.Length > _allowSizeForImg)
                {
                    return BadRequest("The Size Image Is High");
                }

                using var imgStream = new MemoryStream();
                await dto.MyImg.CopyToAsync(imgStream);
                emp.MyImg = imgStream.ToArray();
            }
            
            if(dto.MyVideo != null)
            {
                if (!_alloExtensionsForvideo.Contains(Path.GetExtension(dto.MyVideo.FileName)))
                {
                    return BadRequest("The Video Is Reqiuered");
                }

                if (dto.MyVideo.Length > _allowSizeForVideo)
                {
                    return BadRequest("The Size Video Is High");
                }
                var videoStream = new MemoryStream();
 
                await dto.MyVideo.CopyToAsync(videoStream);
                emp.MyVideo = videoStream.ToArray();
            }

            if(dto.Name != null)
            {
                emp.Name = dto.Name;
            }
            
            if(dto.gender != null)
            {
                emp.gender = dto.gender;
            }
            if(dto.Number != null)
            {
                emp.Number = dto.Number;
            }
            if(dto.Email != null)
            {
                emp.Email = dto.Email;
            }
           
            
            emp.DepartmentId = dto.DepartmentId;
            
            


            var employee = _employeeService.UpdateEmployee(emp);

            

            return Ok(employee);
        }
    }
}
