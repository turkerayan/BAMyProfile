using BAMyProfileApp.Business.Concretes;
using BAMyProfileApp.Business.Interfaces;
using BAMyProfileApp.Dtos.Event;
using BAMyProfileApp.Dtos.Example;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BAMyProfileApp.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EventController : ControllerBase
{
	private readonly IEventService eventService;

	public EventController(IEventService eventService)
	{
		this.eventService = eventService;
	}
	[Route("[action]")]
    [Authorize(Roles = "Admin, Candidate")]
    [HttpGet]
	public async Task<IActionResult> GetAll()
	{
		var result = await eventService.GetAllAsync();
        
        return result.IsSuccess ? Ok(result) : BadRequest(result);
	}
	[Route("[action]")]
    [Authorize(Roles = "Admin, Candidate")]
    [HttpGet]
    public async Task<IActionResult> GetById(Guid id)
	{
		var result = await eventService.GetByIdAsync(id);
		return result.IsSuccess ? Ok(result) : BadRequest(result);
	}
	[HttpPost]
	[Route("[action]")]
    [Authorize(Roles = "Admin, Candidate")]
    public async Task<IActionResult> Create([FromForm] EventCreateDTO eventCreateDTO)
	{
        if (!ModelState.IsValid)
			return BadRequest(ModelState);
		var result = await eventService.CreateAsync(eventCreateDTO);
		return result.IsSuccess ? Ok(result) : BadRequest(result);
	}
	[HttpDelete]
	[Route("[action]")]
    [Authorize(Roles = "Admin, Candidate")]
    public async Task<IActionResult> Delete(Guid id)
	{
		var result = await eventService.DeleteAsync(id);
		return result.IsSuccess ? Ok(result) : BadRequest(result);
	}
	[HttpPut]
	[Route("[action]")]
    [Authorize(Roles = "Admin, Candidate")]
    public async Task<IActionResult> Update([FromForm] EventUpdateDTO eventUpdateDTO)
	{
		if (!ModelState.IsValid)
			return BadRequest(ModelState);
		var result = await eventService.UpdateAsync(eventUpdateDTO);
		return result.IsSuccess ? Ok(result) : BadRequest(result);
	}
}
