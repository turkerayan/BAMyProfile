using AutoMapper;
using BAMyProfileApp.Business.Constants;
using BAMyProfileApp.Business.Interfaces;
using BAMyProfileApp.Business.Resources;
using BAMyProfileApp.Core.Utilities.Results;
using BAMyProfileApp.DataAccess.Interfaces.Repositories;
using BAMyProfileApp.Dtos.Event;
using BAMyProfileApp.Dtos.EventStudent;
using BAMyProfileApp.Entities.DbSets;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAMyProfileApp.Business.Concretes;

public class EventStudentService : IEventStudentService
{
    private readonly IEventStudentRepository _eventStudentRepository;
    private readonly IMapper _mapper;
    private readonly IStringLocalizer<MessageResources> _localizer;

    public EventStudentService(IEventStudentRepository eventStudentRepository, IMapper mapper, IStringLocalizer<MessageResources> localizer)
    {
        _eventStudentRepository = eventStudentRepository;
        _mapper = mapper;
        _localizer = localizer;
    }

    public async Task<IResult> CreateAsync(EventStudentCreateDTO eventStudentCreateDTO)
    {
        if (await _eventStudentRepository.AnyAsync(x =>
            x.EventId == eventStudentCreateDTO.EventId &&
            x.StudentId == eventStudentCreateDTO.StudentId))
            return new ErrorResult(_localizer[Messages.EventStudentAlreadyExists]);

        var newEventStudent = _mapper.Map<EventStudent>(eventStudentCreateDTO);
        await _eventStudentRepository.AddAsync(newEventStudent);
        await _eventStudentRepository.SaveChangesAsync();

        var eventStudentDto = _mapper.Map<EventStudentDTO>(newEventStudent);
        return new SuccessDataResult<EventStudentDTO>(eventStudentDto, _localizer[Messages.EventStudentAddSuccess]);
    }

    public async Task<IResult> DeleteAsync(Guid id)
    {
        var eventStudent = await _eventStudentRepository.GetByIdAsync(id);
        if (eventStudent == null) return new ErrorResult(_localizer[Messages.EventStudentNotFound]);

        await _eventStudentRepository.DeleteAsync(eventStudent);
        await _eventStudentRepository.SaveChangesAsync();
        return new SuccessResult(_localizer[Messages.EventStudentDeletedSuccess]);
    }

    public async Task<IResult> GetAllAsync()
    {
        var eventStudents = await _eventStudentRepository.GetAllAsync();
        if (eventStudents.Count() <= 0) return new ErrorResult(_localizer[Messages.ListHasNoEventStudents]);

        var eventStudentListDto = _mapper.Map<List<EventStudentListDTO>>(eventStudents);
        return new SuccessDataResult<List<EventStudentListDTO>>(eventStudentListDto, _localizer[Messages.EventStudentListedSuccess]);
    }

    public async Task<IResult> GetByIdAsync(Guid id)
    {
        var eventStudent = await _eventStudentRepository.GetByIdAsync(id);
        if (eventStudent == null) return new ErrorResult(_localizer[Messages.EventStudentNotFound]);

        var eventStudentDto = _mapper.Map<EventStudentDTO>(eventStudent);
        return new SuccessDataResult<EventStudentDTO>(eventStudentDto, _localizer[Messages.EventStudentFoundSuccess]);
    }

    public async Task<IResult> UpdateAsync(EventStudentUpdateDTO eventStudentUpdateDTO)
    {
        if (await _eventStudentRepository.AnyAsync(x =>
            x.EventId == eventStudentUpdateDTO.EventId &&
            x.StudentId == eventStudentUpdateDTO.StudentId))
            return new ErrorResult(_localizer[Messages.EventStudentAlreadyExists]);

        var eventStudent = await _eventStudentRepository.GetByIdAsync(eventStudentUpdateDTO.Id);
        if (eventStudent == null) return new ErrorResult(_localizer[Messages.EventStudentNotFound]);

        var updatedEventStudent = _mapper.Map(eventStudentUpdateDTO, eventStudent);
        await _eventStudentRepository.UpdateAsync(updatedEventStudent);
        await _eventStudentRepository.SaveChangesAsync();

        return new SuccessDataResult<EventStudentDTO>(_mapper.Map<EventStudentDTO>(updatedEventStudent), _localizer[Messages.EventStudentUpdateSuccess]);
    }
}
