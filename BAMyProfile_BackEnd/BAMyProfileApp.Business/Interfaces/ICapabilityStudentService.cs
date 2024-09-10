using BAMyProfileApp.Core.Utilities.Results;
using BAMyProfileApp.Dtos.CapabilityStudent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAMyProfileApp.Business.Interfaces;

public interface ICapabilityStudentService
{
    Task<IResult> CreateAsync(CapabilityStudentCreateDTO capabilityStudentCreateDTO);
    Task<IResult> DeleteAsync(Guid id);
    Task<IResult> UpdateAsync(CapabilityStudentUpdateDTO capabilityStudentUpdateDTO);
    Task<IResult> GetAllAsync();
    Task<IResult> GetByIdAsync(Guid id);
}

