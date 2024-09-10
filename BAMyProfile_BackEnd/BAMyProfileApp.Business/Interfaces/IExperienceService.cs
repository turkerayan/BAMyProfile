using BAMyProfileApp.Core.Utilities.Results;
using BAMyProfileApp.Dtos.Experience;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAMyProfileApp.Business.Interfaces;

public interface IExperienceService
{
    Task<IResult> CreateAsync(ExperienceCreateDTO experienceCreateDTO);
    Task<IResult> DeleteAsync(Guid id);
    Task<IResult> UpdateAsync(ExperienceUpdateDTO experienceUpdateDTO);
    Task<IResult> GetAllAsync();
    Task<IResult> GetByIdAsync(Guid id);
}
