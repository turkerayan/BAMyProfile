using BAMyProfileApp.Business.Interfaces;
using BAMyProfileApp.Dtos.Benefit;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BAMyProfileApp.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize(Roles = "Admin")]
public class BenefitController : ControllerBase
{
    private readonly IBenefitService _benefitService;

    public BenefitController(IBenefitService benefitService)
    {
        _benefitService = benefitService;
    }

    [Route("[action]")]
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _benefitService.GetAllAsync();
        return result.IsSuccess ? Ok(result) : BadRequest(result);
    }
    [HttpGet]
    [Route("[action]")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var result = await _benefitService.GetByIdAsync(id);
        return result.IsSuccess ? Ok(result) : BadRequest(result);
    }
    [HttpPost]
    [Route("[action]")]
    public async Task<IActionResult> Create(BenefitCreateDTO benefitCreateDTO)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        var result = await _benefitService.CreateAsync(benefitCreateDTO);
        return result.IsSuccess ? Ok(result) : BadRequest(result);
    }
    [HttpDelete]
    [Route("[action]")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var result = await _benefitService.DeleteAsync(id);
        return result.IsSuccess ? Ok(result) : BadRequest(result);
    }
    [HttpPut]
    [Route("[action]")]
    public async Task<IActionResult> Update(BenefitUpdateDTO benefitUpdateDTO)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var result = await _benefitService.UpdateAsync(benefitUpdateDTO);
        return result.IsSuccess ? Ok(result) : BadRequest(result);
    }
}