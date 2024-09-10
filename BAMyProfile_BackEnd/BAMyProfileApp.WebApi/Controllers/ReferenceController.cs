using BAMyProfileApp.Dtos.References;
using BAMyProfileApp.Entities.DbSets;
using Microsoft.AspNetCore.Mvc;
using BAMyProfileApp.Business.Interfaces;
using BAMyProfileApp.Business.Concretes;
using BAMyProfileApp.Dtos;
using BAMyProfileApp.WebApi.Extensions;
using BAMyProfileApp.WebApi.Validations.Reference;
using BAMyProfileApp.Dtos.Student;
using Microsoft.AspNetCore.Authorization;

namespace BAMyProfileApp.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReferenceController : ControllerBase
    {
        private readonly IReferenceService _referenceService;
        public ReferenceController(IReferenceService referenceService)
        {
            _referenceService = referenceService;
        }
        
        [Route("[action]")]
        [HttpGet]
        [Authorize(Roles = "Admin, Candidate")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _referenceService.GetAllAsync();
            return result.IsSuccess? Ok(result) : BadRequest(result);
        }
        
        [Route("[action]")]
        [HttpGet]
        [Authorize(Roles = "Admin, Candidate")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _referenceService.GetByIdAsync(id);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }
       
        [Route("[action]")]
        [HttpPost]
        [Authorize(Roles = "Admin, Candidate")]
        public async Task<IActionResult> Create(ReferenceCreateDTO referenceCreateDTO)
        {

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = await _referenceService.CreateAsync(referenceCreateDTO);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }
       
        [Route("[action]")]
        [HttpPut]
        [Authorize(Roles = "Admin, Candidate")]
        public async Task<IActionResult> Update(ReferenceUpdateDTO referenceUpdateDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = await _referenceService.UpdateAsync(referenceUpdateDTO);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }
       
        [Route("[action]")]
        [HttpDelete]
        [Authorize(Roles = "Admin, Candidate")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _referenceService.DeleteAsync(id);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }
    }
}


