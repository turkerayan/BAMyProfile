using BAMyProfileApp.Business.Interfaces;
using BAMyProfileApp.Dtos.Example;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BAMyProfileApp.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExampleController : ControllerBase
    {
        private readonly IExampleService _exampleService;

        public ExampleController(IExampleService exampleService)
        {
            _exampleService = exampleService;
        }

        [Route("[action]")]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _exampleService.GetAllAsync();
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _exampleService.GetByIdAsync(id);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> Create(ExampleCreateDTO exampleCreateDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = await _exampleService.CreateAsync(exampleCreateDTO);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }
        [HttpDelete]
        [Route("[action]")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _exampleService.DeleteAsync(id);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }
        [HttpPut]
        [Route("[action]")]
        public async Task<IActionResult> Update(ExampleUpdateDTO exampleUpdateDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = await _exampleService.UpdateAsync(exampleUpdateDTO);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }
    }
}
