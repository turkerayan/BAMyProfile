using BAMyProfileApp.Business.Interfaces;
using BAMyProfileApp.Dtos.EventStudent;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BAMyProfileApp.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EventStudentController : ControllerBase
{
    private readonly IEventStudentService _eventStudentService;

    public EventStudentController(IEventStudentService eventStudentService)
    {
        _eventStudentService = eventStudentService;
    }

    [HttpGet]
    [Route("[action]")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> GetAll()
    {
        var result = await _eventStudentService.GetAllAsync();
        return result.IsSuccess ? Ok(result) : BadRequest(result);
    }

    [HttpGet]
    [Route("[action]/{id}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var result = await _eventStudentService.GetByIdAsync(id);
        return result.IsSuccess ? Ok(result) : BadRequest(result);
    }

    [HttpPost]
    [Route("[action]")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Create(EventStudentCreateDTO eventStudentCreateDTO)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var result = await _eventStudentService.CreateAsync(eventStudentCreateDTO);
        return result.IsSuccess ? Ok(result) : BadRequest(result);
    }

    [HttpDelete]
    [Route("[action]/{id}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var result = await _eventStudentService.DeleteAsync(id);
        return result.IsSuccess ? Ok(result) : BadRequest(result);
    }

    [HttpPut]
    [Route("[action]")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Update(EventStudentUpdateDTO eventStudentUpdateDTO)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var result = await _eventStudentService.UpdateAsync(eventStudentUpdateDTO);
        return result.IsSuccess ? Ok(result) : BadRequest(result);
    }
}

