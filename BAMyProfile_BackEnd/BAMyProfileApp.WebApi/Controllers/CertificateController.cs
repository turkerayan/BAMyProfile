using BAMyProfileApp.Business.Interfaces;
using BAMyProfileApp.Dtos.Certificate;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BAMyProfileApp.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin, Candidate")]
    public class CertificateController : ControllerBase
    {
        private readonly ICertificateService _certificateService;

        public CertificateController(ICertificateService certificateService)
        {
            _certificateService = certificateService;
        }

        [Route("[action]")]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _certificateService.GetAllAsync();
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _certificateService.GetByIdAsync(id);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> Create([FromForm]CertificateCreateDTO certificateCreateDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = await _certificateService.CreateAsync(certificateCreateDTO);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }


        [HttpDelete]
        [Route("[action]")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _certificateService.DeleteAsync(id);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPut]
        [Route("[action]")]
        public async Task<IActionResult> Update([FromForm]CertificateUpdateDTO certificateUpdateDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = await _certificateService.UpdateAsync(certificateUpdateDTO);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }
    }
}
