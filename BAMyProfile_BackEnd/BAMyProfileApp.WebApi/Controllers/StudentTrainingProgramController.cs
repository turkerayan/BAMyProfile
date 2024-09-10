using BAMyProfileApp.Business.Interfaces;
using BAMyProfileApp.Dtos.StudentTrainingProgram;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BAMyProfileApp.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize(Roles = "Admin")]
public class StudentTrainingProgramController : ControllerBase
{
    private readonly IStudentTrainingProgramService _studentTrainingProgramService;

    public StudentTrainingProgramController(IStudentTrainingProgramService studentTrainingProgramService)
    {
        _studentTrainingProgramService = studentTrainingProgramService;
    }

    [HttpGet]
    [Route("[action]")]
    public async Task<IActionResult> GetAll()
    {
        var result = await _studentTrainingProgramService.GetAllAsync();
        return result.IsSuccess ? Ok(result) : BadRequest(result);
    }

    [HttpGet]
    [Route("[action]/{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var result = await _studentTrainingProgramService.GetByIdAsync(id);
        return result.IsSuccess ? Ok(result) : BadRequest(result);
    }

    [HttpPost]
    [Route("[action]")]
    public async Task<IActionResult> Create(StudentTrainingProgramCreateDTO studentTrainingProgramCreateDTO)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var result = await _studentTrainingProgramService.CreateAsync(studentTrainingProgramCreateDTO);
        return result.IsSuccess ? Ok(result) : BadRequest(result);
    }

    [HttpDelete]
    [Route("[action]/{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var result = await _studentTrainingProgramService.DeleteAsync(id);
        return result.IsSuccess ? Ok(result) : BadRequest(result);
    }

    [HttpPut]
    [Route("[action]")]
    public async Task<IActionResult> Update(StudentTrainingProgramUpdateDTO studentTrainingProgramUpdateDTO)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var result = await _studentTrainingProgramService.UpdateAsync(studentTrainingProgramUpdateDTO);
        return result.IsSuccess ? Ok(result) : BadRequest(result);
    }
}
