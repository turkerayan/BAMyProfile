using BAMyProfileApp.Business.Interfaces;
using BAMyProfileApp.Business.Resources;
using BAMyProfileApp.Dtos.ApplicationInterviewer;
using BAMyProfileApp.WebApi.Validations.ApplicationInterviewer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;

namespace BAMyProfileApp.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
    [Authorize(Roles = "Admin")]
    public class ApplicationInterviewerController : ControllerBase
	{
		private readonly IApplicationInterviewerService _applicationInterviewerService;

		public ApplicationInterviewerController(IApplicationInterviewerService applicationInterviewerService)
		{
			_applicationInterviewerService = applicationInterviewerService;
		}

		[Route("[action]")]
		[HttpGet]
		public async Task<IActionResult> GetAll()
		{
			var result = await _applicationInterviewerService.GetAllAsync();
			return result.IsSuccess ? Ok(result) : BadRequest(result);
		}

		[Route("[action]")]
		[HttpGet]
		public async Task<IActionResult> GetById(Guid id)
		{
			var result = await _applicationInterviewerService.GetByIdAsync(id);
			return result.IsSuccess ? Ok(result) : BadRequest(result);
		}

		[Route("[action]")]
		[HttpPost]
		public async Task<IActionResult> Create(ApplicationInterviewerCreateDTO appInterviewerCreateDTO)
		{
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = await _applicationInterviewerService.CreateAsync(appInterviewerCreateDTO);
			return result.IsSuccess ? Ok(result) : BadRequest(result);
		}

		[Route("[action]")]
		[HttpPut]
		public async Task<IActionResult> Update(ApplicationInterviewerUpdateDTO appInterviewerUpdateDTO)
		{
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = await _applicationInterviewerService.UpdateAsync(appInterviewerUpdateDTO);
			return result.IsSuccess ? Ok(result) : BadRequest(result);
		}

		[Route("[action]")]
		[HttpDelete]
		public async Task<IActionResult> Delete(Guid id)
		{
			var result = await _applicationInterviewerService.DeleteAsync(id);
			return result.IsSuccess ? Ok(result) : BadRequest(result);
		}
	}
}
