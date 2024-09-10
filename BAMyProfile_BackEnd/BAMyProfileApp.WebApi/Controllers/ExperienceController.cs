using BAMyProfileApp.Business.Interfaces;
using BAMyProfileApp.Core.Enums;
using BAMyProfileApp.Dtos.Experience;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BAMyProfileApp.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize(Roles = "Admin, Candidate")]
public class ExperienceController : ControllerBase
{
    //private readonly IExperienceService _experienceService;

    //public ExperienceController(IExperienceService experienceService)
    //{
    //    _experienceService = experienceService;
    //}
    private readonly IExperienceService _experienceService;

    public ExperienceController(IExperienceService experienceService)
    {
        _experienceService = experienceService;
    }

    [Route("[action]")]
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _experienceService.GetAllAsync();
        return result.IsSuccess ? Ok(result) : BadRequest(result);
    }
    [HttpGet]
    [Route("[action]")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var result = await _experienceService.GetByIdAsync(id);
        return result.IsSuccess ? Ok(result) : BadRequest(result);
    }
    [HttpPost]
    [Route("[action]")]
    public async Task<IActionResult> Create(ExperienceCreateDTO experienceCreateDTO)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        var result = await _experienceService.CreateAsync(experienceCreateDTO);
        return result.IsSuccess ? Ok(result) : BadRequest(result);
    }
    [HttpDelete]
    [Route("[action]")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var result = await _experienceService.DeleteAsync(id);
        return result.IsSuccess ? Ok(result) : BadRequest(result);
    }
    [HttpPut]
    [Route("[action]")]
    public async Task<IActionResult> Update(ExperienceUpdateDTO experienceUpdateDTO)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        var result = await _experienceService.UpdateAsync(experienceUpdateDTO);
        return result.IsSuccess ? Ok(result) : BadRequest(result);
    }
}
