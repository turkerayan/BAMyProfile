using BAMyProfileApp.Business.Interfaces;
using BAMyProfileApp.Dtos.StudentLanguage;
using Microsoft.AspNetCore.Mvc;

namespace BAMyProfileApp.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StudentLanguageController : ControllerBase
{
    private readonly IStudentLanguageService _studentLanguageService;

    public StudentLanguageController(IStudentLanguageService studentLanguageService)
    {
        _studentLanguageService = studentLanguageService;
    }

    [HttpGet]
    [Route("[action]")]
    public async Task<IActionResult> GetAll()
    {
        var result = await _studentLanguageService.GetAllAsync();
        return result.IsSuccess ? Ok(result) : BadRequest(result);
    }

    [HttpGet]
    [Route("[action]/{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var result = await _studentLanguageService.GetByIdAsync(id);
        return result.IsSuccess ? Ok(result) : BadRequest(result);
    }

    [HttpPost]
    [Route("[action]")]
    public async Task<IActionResult> Create(StudentLanguageCreateDTO studentLanguageCreateDTO)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var result = await _studentLanguageService.CreateAsync(studentLanguageCreateDTO);
        return result.IsSuccess ? Ok(result) : BadRequest(result);
    }

    [HttpDelete]
    [Route("[action]/{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var result = await _studentLanguageService.DeleteAsync(id);
        return result.IsSuccess ? Ok(result) : BadRequest(result);
    }

    [HttpPut]
    [Route("[action]")]
    public async Task<IActionResult> Update(StudentLanguageUpdateDTO studentLanguageUpdateDTO)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var result = await _studentLanguageService.UpdateAsync(studentLanguageUpdateDTO);
        return result.IsSuccess ? Ok(result) : BadRequest(result);
    }
}
