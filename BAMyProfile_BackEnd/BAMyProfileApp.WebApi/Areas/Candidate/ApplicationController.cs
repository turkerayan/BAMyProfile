using BAMyProfileApp.Business.Concretes;
using BAMyProfileApp.Business.Interfaces;
using BAMyProfileApp.Dtos.Application;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BAMyProfileApp.WebApi.Areas.Candidate
{
    [Route("api/[area]/[controller]")]
    [Area("Candidate")]
    [ApiController]
    public class ApplicationController : ControllerBase
    {
        private readonly IApplicationService _applicationService;

        public ApplicationController(IApplicationService applicationService)
        {
            _applicationService = applicationService;
        }

        [Route("[action]")]
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _applicationService.GetAllAsync();
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }
        [HttpGet]
        [Authorize(Roles = "Admin")]
        [Route("[action]")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _applicationService.GetByIdAsync(id);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }
        [HttpPost]
        [Authorize(Roles = "Admin")]
        [Route("[action]")]
        public async Task<IActionResult> Create(ApplicationCreateDTO applicationCreateDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = await _applicationService.CreateAsync(applicationCreateDTO);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }
        [HttpDelete]
        [Authorize(Roles = "Admin")]
        [Route("[action]")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _applicationService.DeleteAsync(id);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }
        [HttpPut]
        [Authorize(Roles = "Admin")]
        [Route("[action]")]
        public async Task<IActionResult> Update(ApplicationUpdateDTO applicationUpdateDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = await _applicationService.UpdateAsync(applicationUpdateDTO);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }
        [HttpGet]
        [Authorize(Roles = "Admin")]
        [Route("[action]")]
        public async Task<IActionResult> GetApplicationsByCandidateId(Guid candidateId)
        {
            var result = await _applicationService.GetApplicationsByCandidateIdAsync(candidateId);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }
    }
}
