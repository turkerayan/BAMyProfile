using BAMyProfileApp.Business.Concretes;
using BAMyProfileApp.Business.Interfaces;
using BAMyProfileApp.Dtos.Example;
using BAMyProfileApp.Dtos.Languages;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace BAMyProfileApp.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize(Roles = "Admin, Candidate")]
public class LanguageController : ControllerBase
{
    private readonly ILanguagesService _langugesService;

    public LanguageController(ILanguagesService languageService)
    {
        _langugesService = languageService;
    }

    [Route("[action]")]
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _langugesService.GetAllAsync();
        return result.IsSuccess ? Ok(result) : BadRequest(result);
    }
    [HttpGet]
    [Route("[action]")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var result = await _langugesService.GetByIdAsync(id);
        return result.IsSuccess ? Ok(result) : BadRequest(result);
    }
    [HttpPost]
    [Route("[action]")]
    public async Task<IActionResult> Create(LanguagesCreateDTO languageCreateDTO)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        var result = await _langugesService.CreateAsync(languageCreateDTO);
        return result.IsSuccess ? Ok(result) : BadRequest(result);
    }
    [HttpDelete]
    [Route("[action]")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var result = await _langugesService.DeleteAsync(id);
        return result.IsSuccess ? Ok(result) : BadRequest(result);
    }
    [HttpPut]
    [Route("[action]")]
    public async Task<IActionResult> Update(LanguagesUpdateDTO languageUpdateDTO)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        var result = await _langugesService.UpdateAsync(languageUpdateDTO);
        return result.IsSuccess ? Ok(result) : BadRequest(result);
    }
}
