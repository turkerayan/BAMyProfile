using BAMyProfileApp.Business.Interfaces;
using BAMyProfileApp.Dtos.JobBenefit;
using Microsoft.AspNetCore.Mvc;

namespace BAMyProfileApp.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class JobBenefitController : ControllerBase
{
    private readonly IJobBenefitService _jobBenefitService;

    public JobBenefitController(IJobBenefitService jobBenefitService)
    {
        _jobBenefitService = jobBenefitService;
    }

    [Route("[action]")]
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _jobBenefitService.GetAllAsync();
        return result.IsSuccess ? Ok(result) : BadRequest(result);
    }
    [HttpGet]
    [Route("[action]")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var result = await _jobBenefitService.GetByIdAsync(id);
        return result.IsSuccess ? Ok(result) : BadRequest(result);
    }
    [HttpPost]
    [Route("[action]")]
    public async Task<IActionResult> Create(JobBenefitCreateDTO _jobBenefitCreateDTO)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        var result = await _jobBenefitService.CreateAsync(_jobBenefitCreateDTO);
        return result.IsSuccess ? Ok(result) : BadRequest(result);
    }
    [HttpDelete]
    [Route("[action]")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var result = await _jobBenefitService.DeleteAsync(id);
        return result.IsSuccess ? Ok(result) : BadRequest(result);
    }
    [HttpPut]
    [Route("[action]")]
    public async Task<IActionResult> Update(JobBenefitUpdateDTO _jobBenefitUpdateDTO)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var result = await _jobBenefitService.UpdateAsync(_jobBenefitUpdateDTO);
        return result.IsSuccess ? Ok(result) : BadRequest(result);
    }
}