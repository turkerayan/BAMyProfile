using BAMyProfileApp.Business.Interfaces;
using BAMyProfileApp.Dtos.ReferenceStudent;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BAMyProfileApp.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ReferenceStudentController : ControllerBase
{
    private readonly IReferenceStudentService _referenceStudentService;

    public ReferenceStudentController(IReferenceStudentService referenceStudentService)
    {
        _referenceStudentService = referenceStudentService;
    }

    [HttpGet]
    [Route("[action]")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> GetAll()
    {
        var result = await _referenceStudentService.GetAllAsync();
        return result.IsSuccess ? Ok(result) : BadRequest(result);
    }

    [HttpGet]
    [Route("[action]/{id}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var result = await _referenceStudentService.GetByIdAsync(id);
        return result.IsSuccess ? Ok(result) : BadRequest(result);
    }

    [HttpPost]
    [Route("[action]")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Create(ReferenceStudentCreateDTO referenceStudentCreateDTO)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var result = await _referenceStudentService.CreateAsync(referenceStudentCreateDTO);
        return result.IsSuccess ? Ok(result) : BadRequest(result);
    }

    [HttpDelete]
    [Route("[action]/{id}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var result = await _referenceStudentService.DeleteAsync(id);
        return result.IsSuccess ? Ok(result) : BadRequest(result);
    }

    [HttpPut]
    [Route("[action]")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Update(ReferenceStudentUpdateDTO referenceStudentUpdateDTO)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var result = await _referenceStudentService.UpdateAsync(referenceStudentUpdateDTO);
        return result.IsSuccess ? Ok(result) : BadRequest(result);
    }
}
