using AutoMapper;
using BAMyProfileApp.Business.Constants;
using BAMyProfileApp.Business.Interfaces;
using BAMyProfileApp.Core.Utilities.Results;
using BAMyProfileApp.DataAccess.Interfaces.Repositories;
using BAMyProfileApp.Dtos.StudentLanguage;
using BAMyProfileApp.Entities.DbSets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAMyProfileApp.Business.Concretes;

public class StudentLanguageService : IStudentLanguageService
{
    private readonly IStudentLanguageRepository _studentLanguageRepository;
    private readonly IMapper _mapper;

    public StudentLanguageService(IStudentLanguageRepository studentLanguageRepository, IMapper mapper)
    {
        _studentLanguageRepository = studentLanguageRepository;
        _mapper = mapper;
    }

    public async Task<IResult> CreateAsync(StudentLanguageCreateDTO studentLanguageCreateDTO)
    {
        if (await _studentLanguageRepository.AnyAsync(x =>
            x.LanguageId == studentLanguageCreateDTO.LanguageId &&
            x.StudentId == studentLanguageCreateDTO.StudentId))
            return new ErrorResult(Messages.StudentLanguageAlreadyExists);

        var newStudentLanguage = _mapper.Map<StudentLanguage>(studentLanguageCreateDTO);
        await _studentLanguageRepository.AddAsync(newStudentLanguage);
        await _studentLanguageRepository.SaveChangesAsync();

        var studentLanguageDto = _mapper.Map<StudentLanguageDTO>(newStudentLanguage);
        return new SuccessDataResult<StudentLanguageDTO>(studentLanguageDto, Messages.StudentLanguageAddSuccess);
    }

    public async Task<IResult> DeleteAsync(Guid id)
    {
        var studentLanguage = await _studentLanguageRepository.GetByIdAsync(id);
        if (studentLanguage == null) return new ErrorResult(Messages.StudentLanguageNotFound);

        await _studentLanguageRepository.DeleteAsync(studentLanguage);
        await _studentLanguageRepository.SaveChangesAsync();
        return new SuccessResult(Messages.StudentLanguageDeletedSuccess);
    }

    public async Task<IResult> GetAllAsync()
    {
        var studentLanguages = await _studentLanguageRepository.GetAllAsync();
        if (studentLanguages.Count() <= 0) return new ErrorResult(Messages.ListHasNoStudentLanguages);

        var studentLanguageListDto = _mapper.Map<List<StudentLanguageListDTO>>(studentLanguages);
        return new SuccessDataResult<List<StudentLanguageListDTO>>(studentLanguageListDto, Messages.StudentLanguageListedSuccess);
    }

    public async Task<IResult> GetByIdAsync(Guid id)
    {
        var studentLanguage = await _studentLanguageRepository.GetByIdAsync(id);
        if (studentLanguage == null) return new ErrorResult(Messages.StudentLanguageNotFound);

        var studentLanguageDto = _mapper.Map<StudentLanguageDTO>(studentLanguage);
        return new SuccessDataResult<StudentLanguageDTO>(studentLanguageDto, Messages.StudentLanguageFoundSuccess);
    }

    public async Task<IResult> UpdateAsync(StudentLanguageUpdateDTO studentLanguageUpdateDTO)
    {
        if (await _studentLanguageRepository.AnyAsync(x =>
            x.LanguageId == studentLanguageUpdateDTO.LanguageId &&
            x.StudentId == studentLanguageUpdateDTO.StudentId))
            return new ErrorResult(Messages.StudentLanguageAlreadyExists);

        var studentLanguage = await _studentLanguageRepository.GetByIdAsync(studentLanguageUpdateDTO.Id);
        if (studentLanguage == null) return new ErrorResult(Messages.StudentLanguageNotFound);

        var updatedStudentLanguage = _mapper.Map(studentLanguageUpdateDTO, studentLanguage);
        await _studentLanguageRepository.UpdateAsync(updatedStudentLanguage);
        await _studentLanguageRepository.SaveChangesAsync();

        return new SuccessDataResult<StudentLanguageDTO>(_mapper.Map<StudentLanguageDTO>(updatedStudentLanguage), Messages.StudentLanguageUpdateSuccess);
    }
}

