using BAMyProfileApp.Business.Interfaces;
using BAMyProfileApp.Dtos.TrainingProgram;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BAMyProfileApp.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize(Roles = "Admin, Candidate")]
public class TrainingProgramController : ControllerBase
{
    private readonly ITrainingProgramService _trainingProgramService;

    public TrainingProgramController(ITrainingProgramService trainingProgramService)
    {
        _trainingProgramService = trainingProgramService;
    }

    [Route("[action]")]
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _trainingProgramService.GetAllAsync();
        return result.IsSuccess ? Ok(result) : BadRequest(result);
    }

    [HttpGet]
    [Route("[action]")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var result = await _trainingProgramService.GetByIdAsync(id);
        return result.IsSuccess ? Ok(result) : NotFound(result);
    }

    [HttpPost]
    [Route("[action]")]
    public async Task<IActionResult> Create(TrainingProgramCreateDTO trainingProgramCreateDTO)
    {
        if (!ModelState.IsValid) { return BadRequest(ModelState); }
        var result = await _trainingProgramService.CreateAsync(trainingProgramCreateDTO);
        return result.IsSuccess ? Ok(result) : NotFound(result);
    }

    [HttpDelete]
    [Route("[action]")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var result = await _trainingProgramService.DeleteAsync(id);
        return result.IsSuccess ? Ok(result) : NotFound(result);
    }

    [HttpPut]
    [Route("[action]")]
    public async Task<IActionResult> Update(TrainingProgramUpdateDTO trainingProgramUpdateDTO)
    {
        if (!ModelState.IsValid) { return BadRequest(ModelState); }
        var result = await _trainingProgramService.UpdateAsync(trainingProgramUpdateDTO);
        return result.IsSuccess? Ok(result) : NotFound(result);
    }



}
