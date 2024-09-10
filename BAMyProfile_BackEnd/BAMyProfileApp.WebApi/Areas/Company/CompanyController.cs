using BAMyProfileApp.Business.Interfaces;
using BAMyProfileApp.Dtos.Company;
using BAMyProfileApp.WebApi.Validations.Company;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BAMyProfileApp.WebApi.Areas.Company
{
    [Route("api/[area]/[controller]")]
    [ApiController]
    [Area("Company")]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService _companyService;

        public CompanyController(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        [HttpGet]
        [Route("[action]")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _companyService.GetAllAsync();
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpGet]
        [Route("[action]")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _companyService.GetByIdAsync(id);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost]
        [Route("[action]")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create(CompanyCreateDTO companyCreateDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = await _companyService.CreateAsync(companyCreateDTO);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpDelete]
        [Route("[action]")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _companyService.DeleteAsync(id);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPut]
        [Route("[action]")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Update(CompanyUpdateDTO companyUpdateDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = await _companyService.UpdateAsync(companyUpdateDTO);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }
    }
}
