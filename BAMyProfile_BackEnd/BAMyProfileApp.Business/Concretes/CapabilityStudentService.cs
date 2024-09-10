using AutoMapper;
using BAMyProfileApp.Business.Constants;
using BAMyProfileApp.Business.Interfaces;
using BAMyProfileApp.Core.Utilities.Results;
using BAMyProfileApp.DataAccess.Interfaces.Repositories;
using BAMyProfileApp.Dtos.CapabilityStudent;
using BAMyProfileApp.Entities.DbSets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAMyProfileApp.Business.Concretes;

public class CapabilityStudentService : ICapabilityStudentService
{
    private readonly ICapabilityStudentRepository _capabilityStudentRepository;
    private readonly IMapper _mapper;

    public CapabilityStudentService(ICapabilityStudentRepository capabilityStudentRepository, IMapper mapper)
    {
        _capabilityStudentRepository = capabilityStudentRepository;
        _mapper = mapper;
    }

    public async Task<IResult> CreateAsync(CapabilityStudentCreateDTO capabilityStudentCreateDTO)
    {
        if (await _capabilityStudentRepository.AnyAsync(x =>
            x.CapabilityId == capabilityStudentCreateDTO.CapabilityId &&
            x.StudentId == capabilityStudentCreateDTO.StudentId))
            return new ErrorResult(Messages.CapabilityStudentAlreadyExists);

        var newCapabilityStudent = _mapper.Map<CapabilityStudent>(capabilityStudentCreateDTO);
        await _capabilityStudentRepository.AddAsync(newCapabilityStudent);
        await _capabilityStudentRepository.SaveChangesAsync();

        var capabilityStudentDto = _mapper.Map<CapabilityStudentDTO>(newCapabilityStudent);
        return new SuccessDataResult<CapabilityStudentDTO>(capabilityStudentDto, Messages.CapabilityStudentAddSuccess);
    }

    public async Task<IResult> DeleteAsync(Guid id)
    {
        var capabilityStudent = await _capabilityStudentRepository.GetByIdAsync(id);
        if (capabilityStudent == null) return new ErrorResult(Messages.CapabilityStudentNotFound);

        await _capabilityStudentRepository.DeleteAsync(capabilityStudent);
        await _capabilityStudentRepository.SaveChangesAsync();
        return new SuccessResult(Messages.CapabilityStudentDeletedSuccess);
    }

    public async Task<IResult> GetAllAsync()
    {
        var capabilityStudents = await _capabilityStudentRepository.GetAllAsync();
        if (capabilityStudents.Count() <= 0) return new ErrorResult(Messages.ListHasNoCapabilityStudents);

        var capabilityStudentListDto = _mapper.Map<List<CapabilityStudentListDTO>>(capabilityStudents);
        return new SuccessDataResult<List<CapabilityStudentListDTO>>(capabilityStudentListDto, Messages.CapabilityStudentListedSuccess);
    }

    public async Task<IResult> GetByIdAsync(Guid id)
    {
        var capabilityStudent = await _capabilityStudentRepository.GetByIdAsync(id);
        if (capabilityStudent == null) return new ErrorResult(Messages.CapabilityStudentNotFound);

        var capabilityStudentDto = _mapper.Map<CapabilityStudentDTO>(capabilityStudent);
        return new SuccessDataResult<CapabilityStudentDTO>(capabilityStudentDto, Messages.CapabilityStudentFoundSuccess);
    }

    public async Task<IResult> UpdateAsync(CapabilityStudentUpdateDTO capabilityStudentUpdateDTO)
    {
        if (await _capabilityStudentRepository.AnyAsync(x =>
            x.CapabilityId == capabilityStudentUpdateDTO.CapabilityId &&
            x.StudentId == capabilityStudentUpdateDTO.StudentId))
            return new ErrorResult(Messages.CapabilityStudentAlreadyExists);

        var capabilityStudent = await _capabilityStudentRepository.GetByIdAsync(capabilityStudentUpdateDTO.Id);
        if (capabilityStudent == null) return new ErrorResult(Messages.CapabilityStudentNotFound);

        var updatedCapabilityStudent = _mapper.Map(capabilityStudentUpdateDTO, capabilityStudent);
        await _capabilityStudentRepository.UpdateAsync(updatedCapabilityStudent);
        await _capabilityStudentRepository.SaveChangesAsync();

        return new SuccessDataResult<CapabilityStudentDTO>(_mapper.Map<CapabilityStudentDTO>(updatedCapabilityStudent), Messages.CapabilityStudentUpdateSuccess);
    }
}

