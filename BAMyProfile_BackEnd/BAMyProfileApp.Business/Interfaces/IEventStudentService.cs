using BAMyProfileApp.Core.Utilities.Results;
using BAMyProfileApp.Dtos.EventStudent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAMyProfileApp.Business.Interfaces;

public interface IEventStudentService
{
    Task<IResult> CreateAsync(EventStudentCreateDTO eventStudentCreateDTO);
    Task<IResult> DeleteAsync(Guid id);
    Task<IResult> UpdateAsync(EventStudentUpdateDTO eventStudentUpdateDTO);
    Task<IResult> GetAllAsync();
    Task<IResult> GetByIdAsync(Guid id);
}
