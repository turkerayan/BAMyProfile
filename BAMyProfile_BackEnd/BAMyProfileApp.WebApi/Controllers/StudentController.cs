using BAMyProfileApp.Business.Interfaces;
using BAMyProfileApp.Dtos.Student;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;
using System;
using System.IO;
using System.Threading.Tasks;

namespace BAMyProfileApp.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    [OutputCache]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [Route("[action]")]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _studentService.GetAllAsync();
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _studentService.GetByIdAsync(id);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> Create([FromForm] StudentCreateDTO studentCreateDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _studentService.CreateAsync(studentCreateDTO);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPut]
        [Route("[action]")]
        public async Task<IActionResult> Update([FromForm] StudentUpdateDTO studentUpdateDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _studentService.UpdateAsync(studentUpdateDTO);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpDelete]
        [Route("[action]")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _studentService.DeleteAsync(id);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }
    }
}