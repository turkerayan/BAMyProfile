using BAMyProfileApp.Business.Interfaces;
using BAMyProfileApp.Dtos.StudentCertificate;
using Microsoft.AspNetCore.Mvc;

namespace BAMyProfileApp.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StudentCertificateController : ControllerBase
{
    private readonly IStudentCertificateService _studentCertificateService;

    public StudentCertificateController(IStudentCertificateService studentCertificateService)
    {
        _studentCertificateService = studentCertificateService;
    }

    [HttpGet]
    [Route("[action]")]
    public async Task<IActionResult> GetAll()
    {
        var result = await _studentCertificateService.GetAllAsync();
        return result.IsSuccess ? Ok(result) : BadRequest(result);
    }

    [HttpGet]
    [Route("[action]/{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var result = await _studentCertificateService.GetByIdAsync(id);
        return result.IsSuccess ? Ok(result) : BadRequest(result);
    }

    [HttpPost]
    [Route("[action]")]
    public async Task<IActionResult> Create(StudentCertificateCreateDTO studentCertificateCreateDTO)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var result = await _studentCertificateService.CreateAsync(studentCertificateCreateDTO);
        return result.IsSuccess ? Ok(result) : BadRequest(result);
    }

    [HttpDelete]
    [Route("[action]/{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var result = await _studentCertificateService.DeleteAsync(id);
        return result.IsSuccess ? Ok(result) : BadRequest(result);
    }

    [HttpPut]
    [Route("[action]")]
    public async Task<IActionResult> Update(StudentCertificateUpdateDTO studentCertificateUpdateDTO)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var result = await _studentCertificateService.UpdateAsync(studentCertificateUpdateDTO);
        return result.IsSuccess ? Ok(result) : BadRequest(result);
    }
}
