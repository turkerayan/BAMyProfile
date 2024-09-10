using BAMyProfileApp.Business.Interfaces;
using BAMyProfileApp.Dtos.JobSkill;
using Microsoft.AspNetCore.Mvc;

namespace BAMyProfileApp.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class JobSkillController : ControllerBase
{
    private readonly IJobSkillService _jobSkillService;

    public JobSkillController(IJobSkillService jobSkillService)
    {
        _jobSkillService = jobSkillService;
    }

    [Route("[action]")]
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _jobSkillService.GetAllAsync();
        return result.IsSuccess ? Ok(result) : BadRequest(result);
    }
    [HttpGet]
    [Route("[action]")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var result = await _jobSkillService.GetByIdAsync(id);
        return result.IsSuccess ? Ok(result) : BadRequest(result);
    }
    [HttpPost]
    [Route("[action]")]
    public async Task<IActionResult> Create(JobSkillCreateDTO _jobSkillCreateDTO)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        var result = await _jobSkillService.CreateAsync(_jobSkillCreateDTO);
        return result.IsSuccess ? Ok(result) : BadRequest(result);
    }
    [HttpDelete]
    [Route("[action]")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var result = await _jobSkillService.DeleteAsync(id);
        return result.IsSuccess ? Ok(result) : BadRequest(result);
    }
    [HttpPut]
    [Route("[action]")]
    public async Task<IActionResult> Update(JobSkillUpdateDTO _jobSkillUpdateDTO)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var result = await _jobSkillService.UpdateAsync(_jobSkillUpdateDTO);
        return result.IsSuccess ? Ok(result) : BadRequest(result);
    }
}