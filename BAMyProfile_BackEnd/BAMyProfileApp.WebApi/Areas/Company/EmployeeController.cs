using BAMyProfileApp.Business.Interfaces;
using BAMyProfileApp.Dtos.Employee;
using BAMyProfileApp.WebApi.Validations.Employee;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BAMyProfileApp.WebApi.Areas.Company
{
    [Route("api/[area]/[controller]")]
    [ApiController]
    [Area("Company")]
    [Authorize(Roles = "Admin")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetAll() 
        {
           var result = await _employeeService.GetAllAsync();
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetById(Guid id)
        {
          var result = await _employeeService.GetByIdAsync(id);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> Create(EmployeeCreateDTO employeeCreateDTO) 
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = await _employeeService.CreateAsync(employeeCreateDTO);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpDelete]
        [Route("[action]")]
        public async Task<IActionResult> Delete(Guid id) 
        {
          var result = await _employeeService.DeleteAsync(id);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPut]
        [Route("[action]")]
        public async Task<IActionResult> Update(EmployeeUpdateDTO employeeUpdateDTO) 
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = await _employeeService.UpdateAsync(employeeUpdateDTO);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }
    }
}
