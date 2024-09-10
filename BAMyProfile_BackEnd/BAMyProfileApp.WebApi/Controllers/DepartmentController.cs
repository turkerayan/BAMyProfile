using BAMyProfileApp.Business.Interfaces;
using BAMyProfileApp.Dtos.Department;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BAMyProfileApp.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize(Roles = "Admin")]
public class DepartmentController : ControllerBase
{
    private readonly IDepartmentService _departmentService;

    public DepartmentController(IDepartmentService departmentService)
    {
        _departmentService = departmentService;
    }

    [HttpGet]
    [Route("[action]")]
    public async Task<IActionResult> GetAll()
    {
        var result = await _departmentService.GetAllAsync();
        return result.IsSuccess ? Ok(result) : BadRequest(result);
    }

    [HttpGet]
    [Route("[action]")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var result = await _departmentService.GetByIdAsync(id);
        return result.IsSuccess ? Ok(result) : BadRequest(result);
    }

    [HttpPost]
    [Route("[action]")]
    public async Task<IActionResult> Create(DepartmentCreateDTO departmentCreateDTO)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var result = await _departmentService.CreateAsync(departmentCreateDTO);
        return result.IsSuccess ? Ok(result) : BadRequest(result);
    }

    [HttpDelete]
    [Route("[action]")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var result = await _departmentService.DeleteAsync(id);
        return result.IsSuccess ? Ok(result) : BadRequest(result);
    }

    [HttpPut]
    [Route("[action]")]
    public async Task<IActionResult> Update(DepartmentUpdateDTO departmentUpdateDTO)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var result = await _departmentService.UpdateAsync(departmentUpdateDTO);
        return result.IsSuccess ? Ok(result) : BadRequest(result);
    }
}
