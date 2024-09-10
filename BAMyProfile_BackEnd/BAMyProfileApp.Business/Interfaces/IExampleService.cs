using BAMyProfileApp.Core.Utilities.Results;
using BAMyProfileApp.Dtos.Example;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAMyProfileApp.Business.Interfaces
{
    public interface IExampleService
    {
        Task<IResult> CreateAsync(ExampleCreateDTO exampleCreateDTO);
        Task<IResult> DeleteAsync(Guid id);
        Task<IResult> UpdateAsync(ExampleUpdateDTO exampleUpdateDTO);
        Task<IResult> GetAllAsync();
        Task<IResult> GetByIdAsync(Guid id);
    }
}
