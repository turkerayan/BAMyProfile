using BAMyProfileApp.Core.Utilities.Results;
using BAMyProfileApp.Dtos.StudentDepartment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAMyProfileApp.Business.Interfaces;

public interface IStudentDepartmentService
{
    Task<IResult> CreateAsync(StudentDepartmentCreateDTO studentDepartmentCreateDTO);
    Task<IResult> DeleteAsync(Guid id);
    Task<IResult> UpdateAsync(StudentDepartmentUpdateDTO studentDepartmentUpdateDTO);
    Task<IResult> GetAllAsync();
    Task<IResult> GetByIdAsync(Guid id);
}

