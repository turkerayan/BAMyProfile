using BAMyProfileApp.Core.Utilities.Results;
using BAMyProfileApp.Dtos.StudentTrainingProgram;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAMyProfileApp.Business.Interfaces;

public interface IStudentTrainingProgramService
{
    Task<IResult> CreateAsync(StudentTrainingProgramCreateDTO studentTrainingProgramCreateDTO);
    Task<IResult> DeleteAsync(Guid id);
    Task<IResult> UpdateAsync(StudentTrainingProgramUpdateDTO studentTrainingProgramUpdateDTO);
    Task<IResult> GetAllAsync();
    Task<IResult> GetByIdAsync(Guid id);
}
