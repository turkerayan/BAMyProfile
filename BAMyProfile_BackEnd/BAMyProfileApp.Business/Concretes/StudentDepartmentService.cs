using AutoMapper;
using BAMyProfileApp.Business.Constants;
using BAMyProfileApp.Business.Interfaces;
using BAMyProfileApp.Core.Utilities.Results;
using BAMyProfileApp.DataAccess.Interfaces.Repositories;
using BAMyProfileApp.Dtos.StudentDepartment;
using BAMyProfileApp.Entities.DbSets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAMyProfileApp.Business.Concretes;

public class StudentDepartmentService : IStudentDepartmentService
{
    private readonly IStudentDepartmentRepository _studentDepartmentRepository;
    private readonly IMapper _mapper;

    public StudentDepartmentService(IStudentDepartmentRepository studentDepartmentRepository, IMapper mapper)
    {
        _studentDepartmentRepository = studentDepartmentRepository;
        _mapper = mapper;
    }

    public async Task<IResult> CreateAsync(StudentDepartmentCreateDTO studentDepartmentCreateDTO)
    {
        if (await _studentDepartmentRepository.AnyAsync(x =>
            x.DepartmentId == studentDepartmentCreateDTO.DepartmentId &&
            x.StudentId == studentDepartmentCreateDTO.StudentId))
            return new ErrorResult(Messages.StudentDepartmentAlreadyExists);

        var newStudentDepartment = _mapper.Map<StudentDepartment>(studentDepartmentCreateDTO);
        await _studentDepartmentRepository.AddAsync(newStudentDepartment);
        await _studentDepartmentRepository.SaveChangesAsync();

        var studentDepartmentDto = _mapper.Map<StudentDepartmentDTO>(newStudentDepartment);
        return new SuccessDataResult<StudentDepartmentDTO>(studentDepartmentDto, Messages.StudentDepartmentAddSuccess);
    }

    public async Task<IResult> DeleteAsync(Guid id)
    {
        var studentDepartment = await _studentDepartmentRepository.GetByIdAsync(id);
        if (studentDepartment == null) return new ErrorResult(Messages.StudentDepartmentNotFound);

        await _studentDepartmentRepository.DeleteAsync(studentDepartment);
        await _studentDepartmentRepository.SaveChangesAsync();
        return new SuccessResult(Messages.StudentDepartmentDeletedSuccess);
    }

    public async Task<IResult> GetAllAsync()
    {
        var studentDepartments = await _studentDepartmentRepository.GetAllAsync();
        if (studentDepartments.Count() <= 0) return new ErrorResult(Messages.ListHasNoStudentDepartments);

        var studentDepartmentListDto = _mapper.Map<List<StudentDepartmentListDTO>>(studentDepartments);
        return new SuccessDataResult<List<StudentDepartmentListDTO>>(studentDepartmentListDto, Messages.StudentDepartmentListedSuccess);
    }

    public async Task<IResult> GetByIdAsync(Guid id)
    {
        var studentDepartment = await _studentDepartmentRepository.GetByIdAsync(id);
        if (studentDepartment == null) return new ErrorResult(Messages.StudentDepartmentNotFound);

        var studentDepartmentDto = _mapper.Map<StudentDepartmentDTO>(studentDepartment);
        return new SuccessDataResult<StudentDepartmentDTO>(studentDepartmentDto, Messages.StudentDepartmentFoundSuccess);
    }

    public async Task<IResult> UpdateAsync(StudentDepartmentUpdateDTO studentDepartmentUpdateDTO)
    {
        if (await _studentDepartmentRepository.AnyAsync(x =>
            x.DepartmentId == studentDepartmentUpdateDTO.DepartmentId &&
            x.StudentId == studentDepartmentUpdateDTO.StudentId))
            return new ErrorResult(Messages.StudentDepartmentAlreadyExists);

        var studentDepartment = await _studentDepartmentRepository.GetByIdAsync(studentDepartmentUpdateDTO.Id);
        if (studentDepartment == null) return new ErrorResult(Messages.StudentDepartmentNotFound);

        var updatedStudentDepartment = _mapper.Map(studentDepartmentUpdateDTO, studentDepartment);
        await _studentDepartmentRepository.UpdateAsync(updatedStudentDepartment);
        await _studentDepartmentRepository.SaveChangesAsync();

        return new SuccessDataResult<StudentDepartmentDTO>(_mapper.Map<StudentDepartmentDTO>(updatedStudentDepartment), Messages.StudentDepartmentUpdateSuccess);
    }
}

