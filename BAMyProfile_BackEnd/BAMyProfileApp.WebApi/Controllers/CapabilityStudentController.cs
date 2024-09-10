using BAMyProfileApp.Business.Interfaces;
using BAMyProfileApp.Dtos.CapabilityStudent;
using Microsoft.AspNetCore.Mvc;

namespace BAMyProfileApp.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CapabilityStudentController : ControllerBase
{
    private readonly ICapabilityStudentService _capabilityStudentService;

    public CapabilityStudentController(ICapabilityStudentService capabilityStudentService)
    {
        _capabilityStudentService = capabilityStudentService;
    }

    [HttpGet]
    [Route("[action]")]
    public async Task<IActionResult> GetAll()
    {
        var result = await _capabilityStudentService.GetAllAsync();
        return result.IsSuccess ? Ok(result) : BadRequest(result);
    }

    [HttpGet]
    [Route("[action]/{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var result = await _capabilityStudentService.GetByIdAsync(id);
        return result.IsSuccess ? Ok(result) : BadRequest(result);
    }

    [HttpPost]
    [Route("[action]")]
    public async Task<IActionResult> Create(CapabilityStudentCreateDTO capabilityStudentCreateDTO)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var result = await _capabilityStudentService.CreateAsync(capabilityStudentCreateDTO);
        return result.IsSuccess ? Ok(result) : BadRequest(result);
    }

    [HttpDelete]
    [Route("[action]/{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var result = await _capabilityStudentService.DeleteAsync(id);
        return result.IsSuccess ? Ok(result) : BadRequest(result);
    }

    [HttpPut]
    [Route("[action]")]
    public async Task<IActionResult> Update(CapabilityStudentUpdateDTO capabilityStudentUpdateDTO)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var result = await _capabilityStudentService.UpdateAsync(capabilityStudentUpdateDTO);
        return result.IsSuccess ? Ok(result) : BadRequest(result);
    }
}

