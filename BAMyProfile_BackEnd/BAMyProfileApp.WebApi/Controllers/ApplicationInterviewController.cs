using BAMyProfileApp.Business.Concretes;
using BAMyProfileApp.Business.Interfaces;
using BAMyProfileApp.Business.Resources;
using BAMyProfileApp.Dtos.ApplicationInterview;
using BAMyProfileApp.WebApi.Validations.ApplicationInterview;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;

namespace BAMyProfileApp.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class ApplicationInterviewController : ControllerBase
    {
        private readonly IApplicationInterviewService _applicationInterviewService;

        public ApplicationInterviewController(IApplicationInterviewService applicationInterviewService)
        {
            _applicationInterviewService = applicationInterviewService;
        }

        [Route("[action]")]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _applicationInterviewService.GetAllAsync();
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [Route("[action]")]
        [HttpGet]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _applicationInterviewService.GetByIdAsync(id);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<IActionResult> Create(ApplicationInterviewCreateDTO appInterviewCreateDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = await _applicationInterviewService.CreateAsync(appInterviewCreateDTO);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [Route("[action]")]
        [HttpPut]
        public async Task<IActionResult> Update(ApplicationInterviewUpdateDTO appInterviewUpdateDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = await _applicationInterviewService.UpdateAsync(appInterviewUpdateDTO);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [Route("[action]")]
        [HttpDelete]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _applicationInterviewService.DeleteAsync(id);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }
        [Route("[action]")]
        [HttpGet]

        public async Task<IActionResult> GetInterviewsByCompanyId(Guid companyId)
        {
            var result = await _applicationInterviewService.GetInterviewsByCompanyIdAsync(companyId);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }
        [Route("[action]")]
        [HttpGet]
        public async Task<IActionResult> GetInterviewsByCandidateId(Guid candidateId)
        {
            var result = await _applicationInterviewService.GetInterviewsByCandidateIdAsync(candidateId);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }
    }


}

