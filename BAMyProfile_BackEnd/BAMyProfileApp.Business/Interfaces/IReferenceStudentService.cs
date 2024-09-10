using BAMyProfileApp.Core.Utilities.Results;
using BAMyProfileApp.Dtos.ReferenceStudent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAMyProfileApp.Business.Interfaces;

public interface IReferenceStudentService
{
    Task<IResult> CreateAsync(ReferenceStudentCreateDTO referenceStudentCreateDTO);
    Task<IResult> DeleteAsync(Guid id);
    Task<IResult> UpdateAsync(ReferenceStudentUpdateDTO referenceStudentUpdateDTO);
    Task<IResult> GetAllAsync();
    Task<IResult> GetByIdAsync(Guid id);
}
