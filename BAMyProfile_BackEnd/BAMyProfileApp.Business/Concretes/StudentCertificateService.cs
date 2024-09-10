using AutoMapper;
using BAMyProfileApp.Business.Constants;
using BAMyProfileApp.Business.Interfaces;
using BAMyProfileApp.Core.Utilities.Results;
using BAMyProfileApp.DataAccess.Interfaces.Repositories;
using BAMyProfileApp.Dtos.StudentCertificate;
using BAMyProfileApp.Entities.DbSets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAMyProfileApp.Business.Concretes;

public class StudentCertificateService : IStudentCertificateService
{
    private readonly IStudentCertificateRepository _studentCertificateRepository;
    private readonly IMapper _mapper;

    public StudentCertificateService(IStudentCertificateRepository studentCertificateRepository, IMapper mapper)
    {
        _studentCertificateRepository = studentCertificateRepository;
        _mapper = mapper;
    }

    public async Task<IResult> CreateAsync(StudentCertificateCreateDTO studentCertificateCreateDTO)
    {
        if (await _studentCertificateRepository.AnyAsync(x =>
            x.StudentId == studentCertificateCreateDTO.StudentId &&
            x.CertificateId == studentCertificateCreateDTO.CertificateId))
            return new ErrorResult(Messages.StudentCertificateAlreadyExists);

        var newStudentCertificate = _mapper.Map<StudentCertificate>(studentCertificateCreateDTO);
        await _studentCertificateRepository.AddAsync(newStudentCertificate);
        await _studentCertificateRepository.SaveChangesAsync();

        var studentCertificateDto = _mapper.Map<StudentCertificateDTO>(newStudentCertificate);
        return new SuccessDataResult<StudentCertificateDTO>(studentCertificateDto, Messages.StudentCertificateAddSuccess);
    }

    public async Task<IResult> DeleteAsync(Guid id)
    {
        var studentCertificate = await _studentCertificateRepository.GetByIdAsync(id);
        if (studentCertificate == null) return new ErrorResult(Messages.StudentCertificateNotFound);

        await _studentCertificateRepository.DeleteAsync(studentCertificate);
        await _studentCertificateRepository.SaveChangesAsync();
        return new SuccessResult(Messages.StudentCertificateDeletedSuccess);
    }

    public async Task<IResult> GetAllAsync()
    {
        var studentCertificates = await _studentCertificateRepository.GetAllAsync();
        if (studentCertificates.Count() <= 0) return new ErrorResult(Messages.ListHasNoStudentCertificates);

        var studentCertificateListDto = _mapper.Map<List<StudentCertificateListDTO>>(studentCertificates);
        return new SuccessDataResult<List<StudentCertificateListDTO>>(studentCertificateListDto, Messages.StudentCertificateListedSuccess);
    }

    public async Task<IResult> GetByIdAsync(Guid id)
    {
        var studentCertificate = await _studentCertificateRepository.GetByIdAsync(id);
        if (studentCertificate == null) return new ErrorResult(Messages.StudentCertificateNotFound);

        var studentCertificateDto = _mapper.Map<StudentCertificateDTO>(studentCertificate);
        return new SuccessDataResult<StudentCertificateDTO>(studentCertificateDto, Messages.StudentCertificateFoundSuccess);
    }

    public async Task<IResult> UpdateAsync(StudentCertificateUpdateDTO studentCertificateUpdateDTO)
    {
        if (await _studentCertificateRepository.AnyAsync(x =>
            x.StudentId == studentCertificateUpdateDTO.StudentId &&
            x.CertificateId == studentCertificateUpdateDTO.CertificateId))
            return new ErrorResult(Messages.StudentCertificateAlreadyExists);

        var studentCertificate = await _studentCertificateRepository.GetByIdAsync(studentCertificateUpdateDTO.Id);
        if (studentCertificate == null) return new ErrorResult(Messages.StudentCertificateNotFound);

        var updatedStudentCertificate = _mapper.Map(studentCertificateUpdateDTO, studentCertificate);
        await _studentCertificateRepository.UpdateAsync(updatedStudentCertificate);
        await _studentCertificateRepository.SaveChangesAsync();

        return new SuccessDataResult<StudentCertificateDTO>(_mapper.Map<StudentCertificateDTO>(updatedStudentCertificate), Messages.StudentCertificateUpdateSuccess);
    }
}

