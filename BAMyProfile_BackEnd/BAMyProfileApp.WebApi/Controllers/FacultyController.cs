using BAMyProfileApp.Business.Interfaces;
using BAMyProfileApp.Core.Enums;
using BAMyProfileApp.Dtos.Faculty;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BAMyProfileApp.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FacultyController : ControllerBase
{
    private readonly IFacultyService _facultyService;

    public FacultyController(IFacultyService facultyService)
    {
        _facultyService = facultyService;
    }

    [Authorize(Roles = "Admin")]
    [HttpGet]
    [Route("[action]")]
    public async Task<IActionResult> GetAll()
    {
        var result = await _facultyService.GetAllAsync();
        return result.IsSuccess ? Ok(result) : BadRequest(result);
    }

    [Authorize(Roles = "Admin")]
    [HttpGet]
    [Route("[action]")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var result = await _facultyService.GetByIdAsync(id);
        return result.IsSuccess ? Ok(result) : BadRequest(result);
    }

    [Authorize(Roles = "Admin")]
    [HttpPost]
    [Route("[action]")]
    public async Task<IActionResult> Create(FacultyCreateDTO facultyCreateDTO)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var result = await _facultyService.CreateAsync(facultyCreateDTO);
        return result.IsSuccess ? Ok(result) : BadRequest(result);
    }

    [Authorize(Roles = "Admin")]
    [HttpDelete]
    [Route("[action]")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var result = await _facultyService.DeleteAsync(id);
        return result.IsSuccess ? Ok(result) : BadRequest(result);
    }

    [Authorize(Roles = "Admin")]
    [HttpPut]
    [Route("[action]")]
    public async Task<IActionResult> Update(FacultyUpdateDTO facultyUpdateDTO)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var result = await _facultyService.UpdateAsync(facultyUpdateDTO);
        return result.IsSuccess ? Ok(result) : BadRequest(result);
    }
}
