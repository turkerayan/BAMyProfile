using BAMyProfileApp.Business.Concretes;
using BAMyProfileApp.Business.Interfaces;
using BAMyProfileApp.Dtos.Capability;
using BAMyProfileApp.Dtos.Example;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace BAMyProfileApp.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize(Roles = "Admin")]
public class CapabilityController : ControllerBase
{
    private readonly ICapabilityService _capabilityService;

    public CapabilityController(ICapabilityService capabilityService)
    {
        _capabilityService = capabilityService;
    }

    [Route("[action]")]
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _capabilityService.GetAllAsync();
        return result.IsSuccess ? Ok(result) : BadRequest(result);
    }
    [HttpGet]
    [Route("[action]")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var result = await _capabilityService.GetByIdAsync(id);
        return result.IsSuccess ? Ok(result) : BadRequest(result);
    }
    [HttpPost]
    [Route("[action]")]
    public async Task<IActionResult> Create(CapabilityCreateDTO capabilityCreateDTO)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        var result = await _capabilityService.CreateAsync(capabilityCreateDTO);
        return result.IsSuccess ? Ok(result) : BadRequest(result);
    }
    [HttpDelete]
    [Route("[action]")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var result = await _capabilityService.DeleteAsync(id);
        return result.IsSuccess ? Ok(result) : BadRequest(result);
    }
    [HttpPut]
    [Route("[action]")]
    public async Task<IActionResult> Update(CapabilityUpdateDTO capabilityUpdateDTO)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        var result = await _capabilityService.UpdateAsync(capabilityUpdateDTO);
        return result.IsSuccess ? Ok(result) : BadRequest(result);
    }
}
