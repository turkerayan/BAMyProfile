using BAMyProfileApp.Core.Utilities.Results;
using BAMyProfileApp.Dtos.Event;
using BAMyProfileApp.Dtos.Example;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAMyProfileApp.Business.Interfaces;

public interface IEventService
{
    Task<IResult> CreateAsync(EventCreateDTO eventCreateDTO);
    Task<IResult> DeleteAsync(Guid id);
    Task<IResult> UpdateAsync(EventUpdateDTO eventUpdateDTO);
    Task<IResult> GetAllAsync();
    Task<IResult> GetByIdAsync(Guid id);
}
