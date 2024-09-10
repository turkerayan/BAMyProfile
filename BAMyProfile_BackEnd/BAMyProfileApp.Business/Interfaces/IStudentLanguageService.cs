using BAMyProfileApp.Core.Utilities.Results;
using BAMyProfileApp.Dtos.StudentLanguage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAMyProfileApp.Business.Interfaces;

public interface IStudentLanguageService
{
    Task<IResult> CreateAsync(StudentLanguageCreateDTO studentLanguageCreateDTO);
    Task<IResult> DeleteAsync(Guid id);
    Task<IResult> UpdateAsync(StudentLanguageUpdateDTO studentLanguageUpdateDTO);
    Task<IResult> GetAllAsync();
    Task<IResult> GetByIdAsync(Guid id);
}

