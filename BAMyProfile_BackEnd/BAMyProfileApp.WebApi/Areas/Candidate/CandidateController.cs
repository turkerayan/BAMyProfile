using BAMyProfileApp.Business.Interfaces;
using BAMyProfileApp.Business.Resources;
using BAMyProfileApp.Dtos.Candidate;
using BAMyProfileApp.Entities.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;

namespace BAMyProfileApp.WebApi.Areas.Candidate
{
    [Route("api/[area]/[controller]")]
    [ApiController]
    [Area("Candidate")]
    [Authorize(Roles = "Admin")]
    public class CandidateController : ControllerBase
    {
        private readonly ICandidateService _candidateService;
        private readonly IStringLocalizer<MessageResources> _localizer;

        public CandidateController(ICandidateService candidateService, IStringLocalizer<MessageResources> localizer)
        {
            _candidateService = candidateService;
            _localizer = localizer;
        }

        [Route("[action]")]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _candidateService.GetAllAsync();
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _candidateService.GetByIdAsync(id);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> Create(Guid studentId, int workingStatus)
        {
            
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _candidateService.CreateAsync(studentId, workingStatus);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpDelete]
        [Route("[action]")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _candidateService.DeleteAsync(id);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPut]
        [Route("[action]")]
        public async Task<IActionResult> Update(CandidateUpdateDTO candidateUpdateDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = await _candidateService.UpdateAsync(candidateUpdateDTO);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }
    }
}
