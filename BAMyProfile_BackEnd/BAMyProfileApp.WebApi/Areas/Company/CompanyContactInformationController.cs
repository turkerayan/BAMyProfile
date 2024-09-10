using BAMyProfileApp.Business.Interfaces;
using BAMyProfileApp.Core.Enums;
using BAMyProfileApp.Dtos.Company;
using BAMyProfileApp.Dtos.CompanyContactInformation;
using BAMyProfileApp.WebApi.Validations.Company;
using BAMyProfileApp.WebApi.Validations.CompanyContactInformation;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BAMyProfileApp.WebApi.Areas.Company
{
    [Route("api/[area]/[controller]")]
    [ApiController]
    [Area("Company")]
    public class CompanyContactInformationController : ControllerBase
    {
        private readonly ICompanyContactInformationService _companyContactInformationService;

        public CompanyContactInformationController(ICompanyContactInformationService companyContactInformationService)
        {
            _companyContactInformationService = companyContactInformationService;
        }

        [HttpGet]
        [Route("[action]")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _companyContactInformationService.GetAllAsync();
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpGet]
        [Route("[action]")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _companyContactInformationService.GetByIdAsync(id);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPost]
        [Route("[action]")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create(CompanyContactInformationCreateDTO companyContactInformationCreateDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = await _companyContactInformationService.CreateAsync(companyContactInformationCreateDTO);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpDelete]
        [Route("[action]")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _companyContactInformationService.DeleteAsync(id);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPut]
        [Route("[action]")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Update(CompanyContactInformationUpdateDTO companyContactInformationUpdateDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = await _companyContactInformationService.UpdateAsync(companyContactInformationUpdateDTO);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpGet]
        [Route("[action]")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAllByCompanyId(Guid id)
        {
            var result = await _companyContactInformationService.GetAllByCompanyId(id);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }
    }
}
