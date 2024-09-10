using BAMyProfileApp.Business.Interfaces;
using BAMyProfileApp.Dtos.JobCandidate;
using Microsoft.AspNetCore.Mvc;

namespace BAMyProfileApp.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobCandidateController : ControllerBase
    {
        private readonly IJobCandidateService _jobCandidateService;

        public JobCandidateController(IJobCandidateService jobCandidateService)
        {
            _jobCandidateService = jobCandidateService;
        }
      
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetAll()
        {
            var result=await _jobCandidateService.GetAllAsync();
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result=await _jobCandidateService.GetByIdAsync(id);
            return result.IsSuccess ? Ok(result) :BadRequest(result);
        }
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> Create(JobCandidateCreateDTO _jobCandidateCreateDTO)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);
            var result=await _jobCandidateService.CreateAsync(_jobCandidateCreateDTO);
            return result.IsSuccess ? Ok(result) :BadRequest(result) ;
        }

        [HttpDelete]
        [Route("[action]")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result=await _jobCandidateService.DeleteAsync(id);
            return result.IsSuccess? Ok(result) : BadRequest(result) ;
        }
        [HttpPut]
        [Route("[action]")]
        public async Task<IActionResult> Update(JobCandidateUpdateDTO _jobCandidateUpdateDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var result=await _jobCandidateService.UpdateAsync(_jobCandidateUpdateDTO);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }
    }
}
