using AutoMapper;
using BAMyProfileApp.Business.Constants;
using BAMyProfileApp.Business.Interfaces;
using BAMyProfileApp.Business.Resources;
using BAMyProfileApp.Core.Utilities.Results;
using BAMyProfileApp.DataAccess.EFCore.Repositories;
using BAMyProfileApp.DataAccess.Interfaces.Repositories;
using BAMyProfileApp.Dtos.Event;
using BAMyProfileApp.Dtos.Example;
using BAMyProfileApp.Entities.DbSets;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAMyProfileApp.Business.Concretes;

public class EventService : IEventService
{
    private readonly IEventRepository _eventRepository;
    private readonly IMapper _mapper;
    private readonly IStringLocalizer<MessageResources> _localizer;

    public EventService(IEventRepository eventRepository, IStringLocalizer<MessageResources> localizer, IMapper mapper = null)
    {
        _eventRepository = eventRepository;
        _mapper = mapper;
        _localizer = localizer;
    }
	/// <summary>
	/// Adds a new Event.
	/// </summary>
	/// <param name="eventCreateDTO">DTO containing data for the event to be added.</param>
	/// <returns>The success status of the operation and the object added if successful.</returns>
	public async Task<IResult> CreateAsync(EventCreateDTO eventCreateDTO)
    {
        var hasEvent = await _eventRepository.AnyAsync(x => x.Title.ToLower() == eventCreateDTO.Title.ToLower());
        if (hasEvent) { return new ErrorResult(_localizer[Messages.EventAlreadyExists]); }
        var newEvent = _mapper.Map<Event>(eventCreateDTO);
        
        if(eventCreateDTO.File != null && eventCreateDTO.File.Length > 0)
        {
            byte[] fileBytes;
            using (var memoryStream = new MemoryStream())
            {
                await eventCreateDTO.File.CopyToAsync(memoryStream);
                fileBytes = memoryStream.ToArray();
            }
            newEvent.File = fileBytes;
        }
        await _eventRepository.AddAsync(newEvent);
        await _eventRepository.SaveChangesAsync();
        var eventDTO = _mapper.Map<EventDTO>(newEvent);
        return new SuccessDataResult<EventDTO>(eventDTO, _localizer[Messages.EventAddSuccess]);
    }
	/// <summary>
	/// Deletes the submitted Event.
	/// </summary>
	/// <param name="id">The ID of the event to be deleted.</param>
	/// <returns>The success status of the operation.</returns>
	public async Task<IResult> DeleteAsync(Guid id)
    {
        var hasEvent = await _eventRepository.GetByIdAsync(id);
        if (hasEvent == null) { return new ErrorResult(_localizer[Messages.EventNotFound]); }
        await _eventRepository.DeleteAsync(hasEvent);
        await _eventRepository.SaveChangesAsync();
        return new SuccessResult(_localizer[Messages.EventDeletedSuccess]);
    }
	/// <summary>
	/// Lists all existing Events.
	/// </summary>
	/// <returns>The success status of the operation and events if successful.</returns>
	public async Task<IResult> GetAllAsync()
    {
        var events = await _eventRepository.GetAllAsync();
        if (events.Count() <= 0) { return new ErrorResult(_localizer[Messages.ListHasNoEvents]); }

        var eventListDTO = _mapper.Map<List<EventListDTO>>(events);
      
        return new SuccessDataResult<List<EventListDTO>>(eventListDTO, _localizer[Messages.EventListedSuccess]);
    }
	/// <summary>
	/// Returns the details of the desired event.
	/// </summary>
	/// <param name="id">The ID of the event whose details will be retrieved.</param>
	/// <returns>The success status of the operation and the event if successful.</returns>
	public async Task<IResult> GetByIdAsync(Guid id)
    {
        var hasEvent = await _eventRepository.GetByIdAsync(id);
        if (hasEvent == null) { return new ErrorResult(_localizer[Messages.EventNotFound]); }
        var eventDTO = _mapper.Map<EventDTO>(hasEvent);
        return new SuccessDataResult<EventDTO>(eventDTO, _localizer[Messages.EventFoundSuccess]);
    }
	/// <summary>
	/// Updates the submitted Event.
	/// </summary>
	/// <param name="eventUpdateDTO">DTO containing data for the event to be updated.</param>
	/// <returns>The success status of the operation and the event updated if successful.</returns>
	public async Task<IResult> UpdateAsync(EventUpdateDTO eventUpdateDTO)
    {
        var hasEvent = await _eventRepository.GetByIdAsync(eventUpdateDTO.Id);
        if (hasEvent == null) { return new ErrorResult(_localizer[Messages.EventNotFound]); }
        var updatedEvent = _mapper.Map(eventUpdateDTO, hasEvent);
        if (eventUpdateDTO.File != null && eventUpdateDTO.File.Length > 0)
        {
            byte[] fileBytes;
            using (var memoryStream = new MemoryStream())
            {
                await eventUpdateDTO.File.CopyToAsync(memoryStream);
                fileBytes = memoryStream.ToArray();
            }
            updatedEvent.File = fileBytes;
        }
        await _eventRepository.UpdateAsync(updatedEvent);
        await _eventRepository.SaveChangesAsync();
        return new SuccessDataResult<EventDTO>(_mapper.Map<EventDTO>(updatedEvent), _localizer[Messages.EventUpdateSuccess]);
    }
}
