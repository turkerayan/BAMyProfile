using BAMyProfileApp.Business.Interfaces;
using BAMyProfileApp.Business.Resources;
using BAMyProfileApp.Dtos.ContactPerson;
using BAMyProfileApp.WebApi.Validations.ContactPerson;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;

namespace BAMyProfileApp.WebApi.Areas.Company
{
    [Route("api/[area]/[controller]")]
    [Area("Company")]
    [ApiController]
    public class ContactPersonController : ControllerBase
    {
        private readonly IContactPersonService _contactPersonService;

        public ContactPersonController(IContactPersonService contactPersonService)
        {
            _contactPersonService = contactPersonService;
        }

        [Route("[action]")]
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _contactPersonService.GetAllAync();
            return result.IsSuccess ? Ok(result) : BadRequest(result);

        }

        [Route("[action]")]
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _contactPersonService.GetByIdAsync(id);
            return result.IsSuccess ? Ok(result) : BadRequest(result);

        }

        [Route("[action]")]
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create(ContactPersonCreateDto contactPersonCreateDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = await _contactPersonService.CreateAync(contactPersonCreateDto);
            return result.IsSuccess ? Ok(result) : BadRequest(result);

        }

        [Route("[action]")]
        [HttpDelete]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _contactPersonService.DeleteAync(id);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [Route("[action]")]
        [HttpPut]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Update(ContactPersonUpdateDto contactPersonUpdateDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = await _contactPersonService.UpdateAync(contactPersonUpdateDto);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }
    }
}
