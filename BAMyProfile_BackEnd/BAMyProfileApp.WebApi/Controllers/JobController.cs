using BAMyProfileApp.Business.Interfaces;
using BAMyProfileApp.Dtos.Job;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BAMyProfileApp.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize(Roles = "Admin")]
public class JobController : ControllerBase
{
    private readonly IJobService _jobService;

    public JobController(IJobService jobService)
    {
        _jobService = jobService;
    }

    [Route("[action]")]
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _jobService.GetAllAsync();
        return result.IsSuccess ? Ok(result) : BadRequest(result);
    }
    [HttpGet]
    [Route("[action]")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var result = await _jobService.GetByIdAsync(id);
        return result.IsSuccess ? Ok(result) : BadRequest(result);
    }
    [HttpPost]
    [Route("[action]")]
    public async Task<IActionResult> Create(JobCreateDTO jobCreateDTO)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        var result = await _jobService.CreateAsync(jobCreateDTO);
        return result.IsSuccess ? Ok(result) : BadRequest(result);
    }
    [HttpDelete]
    [Route("[action]")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var result = await _jobService.DeleteAsync(id);
        return result.IsSuccess ? Ok(result) : BadRequest(result);
    }
    [HttpPut]
    [Route("[action]")]
    public async Task<IActionResult> Update(JobUpdateDTO jobUpdateDTO)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var result = await _jobService.UpdateAsync(jobUpdateDTO);
        return result.IsSuccess ? Ok(result) : BadRequest(result);
    }
}
