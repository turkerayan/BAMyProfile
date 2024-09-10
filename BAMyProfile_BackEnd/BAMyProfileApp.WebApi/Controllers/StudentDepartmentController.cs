using BAMyProfileApp.Business.Interfaces;
using BAMyProfileApp.Dtos.StudentDepartment;
using Microsoft.AspNetCore.Mvc;

namespace BAMyProfileApp.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StudentDepartmentController : ControllerBase
{
    private readonly IStudentDepartmentService _studentDepartmentService;

    public StudentDepartmentController(IStudentDepartmentService studentDepartmentService)
    {
        _studentDepartmentService = studentDepartmentService;
    }

    [HttpGet]
    [Route("[action]")]
    public async Task<IActionResult> GetAll()
    {
        var result = await _studentDepartmentService.GetAllAsync();
        return result.IsSuccess ? Ok(result) : BadRequest(result);
    }

    [HttpGet]
    [Route("[action]/{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var result = await _studentDepartmentService.GetByIdAsync(id);
        return result.IsSuccess ? Ok(result) : BadRequest(result);
    }

    [HttpPost]
    [Route("[action]")]
    public async Task<IActionResult> Create(StudentDepartmentCreateDTO studentDepartmentCreateDTO)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var result = await _studentDepartmentService.CreateAsync(studentDepartmentCreateDTO);
        return result.IsSuccess ? Ok(result) : BadRequest(result);
    }

    [HttpDelete]
    [Route("[action]/{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var result = await _studentDepartmentService.DeleteAsync(id);
        return result.IsSuccess ? Ok(result) : BadRequest(result);
    }

    [HttpPut]
    [Route("[action]")]
    public async Task<IActionResult> Update(StudentDepartmentUpdateDTO studentDepartmentUpdateDTO)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var result = await _studentDepartmentService.UpdateAsync(studentDepartmentUpdateDTO);
        return result.IsSuccess ? Ok(result) : BadRequest(result);
    }
}

