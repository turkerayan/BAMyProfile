using AutoMapper;
using BAMyProfileApp.Business.Constants;
using BAMyProfileApp.Business.Interfaces;
using BAMyProfileApp.Core.Utilities.Results;
using BAMyProfileApp.DataAccess.Interfaces.Repositories;
using BAMyProfileApp.Dtos.StudentTrainingProgram;
using BAMyProfileApp.Entities.DbSets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAMyProfileApp.Business.Concretes;

public class StudentTrainingProgramService : IStudentTrainingProgramService
{
    private readonly IStudentTrainingProgramRepository _studentTrainingProgramRepository;
    private readonly IMapper _mapper;

    public StudentTrainingProgramService(IStudentTrainingProgramRepository studentTrainingProgramRepository, IMapper mapper)
    {
        _studentTrainingProgramRepository = studentTrainingProgramRepository;
        _mapper = mapper;
    }

    public async Task<IResult> CreateAsync(StudentTrainingProgramCreateDTO studentTrainingProgramCreateDTO)
    {
        if (await _studentTrainingProgramRepository.AnyAsync(x =>
            x.TrainingProgramId == studentTrainingProgramCreateDTO.TrainingProgramId &&
            x.StudentId == studentTrainingProgramCreateDTO.StudentId))
            return new ErrorResult(Messages.StudentTrainingProgramAlreadyExists);

        var newStudentTrainingProgram = _mapper.Map<StudentTrainingProgram>(studentTrainingProgramCreateDTO);
        await _studentTrainingProgramRepository.AddAsync(newStudentTrainingProgram);
        await _studentTrainingProgramRepository.SaveChangesAsync();

        var studentTrainingProgramDto = _mapper.Map<StudentTrainingProgramDTO>(newStudentTrainingProgram);
        return new SuccessDataResult<StudentTrainingProgramDTO>(studentTrainingProgramDto, Messages.StudentTrainingProgramAddSuccess);
    }

    public async Task<IResult> DeleteAsync(Guid id)
    {
        var studentTrainingProgram = await _studentTrainingProgramRepository.GetByIdAsync(id);
        if (studentTrainingProgram == null) return new ErrorResult(Messages.StudentTrainingProgramNotFound);

        await _studentTrainingProgramRepository.DeleteAsync(studentTrainingProgram);
        await _studentTrainingProgramRepository.SaveChangesAsync();
        return new SuccessResult(Messages.StudentTrainingProgramDeletedSuccess);
    }

    public async Task<IResult> GetAllAsync()
    {
        var studentTrainingPrograms = await _studentTrainingProgramRepository.GetAllAsync();
        if (studentTrainingPrograms.Count() <= 0) return new ErrorResult(Messages.ListHasNoStudentTrainingPrograms);

        var studentTrainingProgramListDto = _mapper.Map<List<StudentTrainingProgramListDTO>>(studentTrainingPrograms);
        return new SuccessDataResult<List<StudentTrainingProgramListDTO>>(studentTrainingProgramListDto, Messages.StudentTrainingProgramListedSuccess);
    }

    public async Task<IResult> GetByIdAsync(Guid id)
    {
        var studentTrainingProgram = await _studentTrainingProgramRepository.GetByIdAsync(id);
        if (studentTrainingProgram == null) return new ErrorResult(Messages.StudentTrainingProgramNotFound);

        var studentTrainingProgramDto = _mapper.Map<StudentTrainingProgramDTO>(studentTrainingProgram);
        return new SuccessDataResult<StudentTrainingProgramDTO>(studentTrainingProgramDto, Messages.StudentTrainingProgramFoundSuccess);
    }

    public async Task<IResult> UpdateAsync(StudentTrainingProgramUpdateDTO studentTrainingProgramUpdateDTO)
    {
        if (await _studentTrainingProgramRepository.AnyAsync(x =>
            x.TrainingProgramId == studentTrainingProgramUpdateDTO.TrainingProgramId &&
            x.StudentId == studentTrainingProgramUpdateDTO.StudentId))
            return new ErrorResult(Messages.StudentTrainingProgramAlreadyExists);

        var studentTrainingProgram = await _studentTrainingProgramRepository.GetByIdAsync(studentTrainingProgramUpdateDTO.Id);
        if (studentTrainingProgram == null) return new ErrorResult(Messages.StudentTrainingProgramNotFound);

        var updatedStudentTrainingProgram = _mapper.Map(studentTrainingProgramUpdateDTO, studentTrainingProgram);
        await _studentTrainingProgramRepository.UpdateAsync(updatedStudentTrainingProgram);
        await _studentTrainingProgramRepository.SaveChangesAsync();

        return new SuccessDataResult<StudentTrainingProgramDTO>(_mapper.Map<StudentTrainingProgramDTO>(updatedStudentTrainingProgram), Messages.StudentTrainingProgramUpdateSuccess);
    }
}

