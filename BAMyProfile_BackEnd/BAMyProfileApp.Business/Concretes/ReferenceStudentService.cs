using AutoMapper;
using BAMyProfileApp.Business.Constants;
using BAMyProfileApp.Business.Interfaces;
using BAMyProfileApp.Core.Utilities.Results;
using BAMyProfileApp.DataAccess.Interfaces.Repositories;
using BAMyProfileApp.Dtos.ReferenceStudent;
using BAMyProfileApp.Entities.DbSets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAMyProfileApp.Business.Concretes;

public class ReferenceStudentService : IReferenceStudentService
{
    private readonly IReferenceStudentRepository _referenceStudentRepository;
    private readonly IMapper _mapper;

    public ReferenceStudentService(IReferenceStudentRepository referenceStudentRepository, IMapper mapper)
    {
        _referenceStudentRepository = referenceStudentRepository;
        _mapper = mapper;
    }

    public async Task<IResult> CreateAsync(ReferenceStudentCreateDTO referenceStudentCreateDTO)
    {
        if (await _referenceStudentRepository.AnyAsync(x =>
            x.ReferenceId == referenceStudentCreateDTO.ReferenceId &&
            x.StudentId == referenceStudentCreateDTO.StudentId))
            return new ErrorResult(Messages.ReferenceStudentAlreadyExists);

        var newReferenceStudent = _mapper.Map<ReferenceStudent>(referenceStudentCreateDTO);
        await _referenceStudentRepository.AddAsync(newReferenceStudent);
        await _referenceStudentRepository.SaveChangesAsync();

        var referenceStudentDto = _mapper.Map<ReferenceStudentDTO>(newReferenceStudent);
        return new SuccessDataResult<ReferenceStudentDTO>(referenceStudentDto, Messages.ReferenceStudentAddSuccess);
    }

    public async Task<IResult> DeleteAsync(Guid id)
    {
        var referenceStudent = await _referenceStudentRepository.GetByIdAsync(id);
        if (referenceStudent == null) return new ErrorResult(Messages.ReferenceStudentNotFound);

        await _referenceStudentRepository.DeleteAsync(referenceStudent);
        await _referenceStudentRepository.SaveChangesAsync();
        return new SuccessResult(Messages.ReferenceStudentDeletedSuccess);
    }

    public async Task<IResult> GetAllAsync()
    {
        var referenceStudents = await _referenceStudentRepository.GetAllAsync();
        if (referenceStudents.Count() <= 0) return new ErrorResult(Messages.ListHasNoReferenceStudents);

        var referenceStudentListDto = _mapper.Map<List<ReferenceStudentListDTO>>(referenceStudents);
        return new SuccessDataResult<List<ReferenceStudentListDTO>>(referenceStudentListDto, Messages.ReferenceStudentListedSuccess);
    }

    public async Task<IResult> GetByIdAsync(Guid id)
    {
        var referenceStudent = await _referenceStudentRepository.GetByIdAsync(id);
        if (referenceStudent == null) return new ErrorResult(Messages.ReferenceStudentNotFound);

        var referenceStudentDto = _mapper.Map<ReferenceStudentDTO>(referenceStudent);
        return new SuccessDataResult<ReferenceStudentDTO>(referenceStudentDto, Messages.ReferenceStudentFoundSuccess);
    }

    public async Task<IResult> UpdateAsync(ReferenceStudentUpdateDTO referenceStudentUpdateDTO)
    {
        if (await _referenceStudentRepository.AnyAsync(x =>
            x.ReferenceId == referenceStudentUpdateDTO.ReferenceId &&
            x.StudentId == referenceStudentUpdateDTO.StudentId))
            return new ErrorResult(Messages.ReferenceStudentAlreadyExists);

        var referenceStudent = await _referenceStudentRepository.GetByIdAsync(referenceStudentUpdateDTO.Id);
        if (referenceStudent == null) return new ErrorResult(Messages.ReferenceStudentNotFound);

        var updatedReferenceStudent = _mapper.Map(referenceStudentUpdateDTO, referenceStudent);
        await _referenceStudentRepository.UpdateAsync(updatedReferenceStudent);
        await _referenceStudentRepository.SaveChangesAsync();

        return new SuccessDataResult<ReferenceStudentDTO>(_mapper.Map<ReferenceStudentDTO>(updatedReferenceStudent), Messages.ReferenceStudentUpdateSuccess);
    }
}

