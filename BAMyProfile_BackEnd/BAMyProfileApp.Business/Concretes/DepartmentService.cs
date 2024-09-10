using AutoMapper;
using BAMyProfileApp.Business.Constants;
using BAMyProfileApp.Business.Interfaces;
using BAMyProfileApp.Business.Resources;
using BAMyProfileApp.Core.Utilities.Results;
using BAMyProfileApp.DataAccess.Interfaces.Repositories;
using BAMyProfileApp.Dtos.Department;
using BAMyProfileApp.Entities.DbSets;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAMyProfileApp.Business.Concretes;

public class DepartmentService : IDepartmentService
{
    private readonly IDepartmentRepository _departmentRepository;
    private readonly IMapper _mapper;
    private readonly IStringLocalizer<MessageResources> _localizer;
    public DepartmentService(IDepartmentRepository departmentRepository, IMapper mapper, IStringLocalizer<MessageResources> localizer)
    {
        _departmentRepository = departmentRepository;
        _mapper = mapper;
        _localizer = localizer;
    }
    /// <summary>
    /// Yeni bir bölüm oluşturma işlemini gerçekleştirir.
    /// </summary>
    /// <param name="departmentCreateDTO">Oluşturulacak bölüm bilgileri DTO'su.</param>
    /// <returns>İşlem sonucu ve mesajı.</returns>
    public async Task<IResult> CreateAsync(DepartmentCreateDTO departmentCreateDTO)
    {
        var hasDepartment = await _departmentRepository.AnyAsync(d => d.Name.ToLower() == departmentCreateDTO.Name.ToLower() && d.FacultyId == departmentCreateDTO.FacultyId);
        if (hasDepartment) { return new ErrorResult(_localizer[Messages.DepartmentAlreadyExists]); }

        var newDepartment = _mapper.Map<Department>(departmentCreateDTO);
        await _departmentRepository.AddAsync(newDepartment);
        await _departmentRepository.SaveChangesAsync();

        var departmentDto = _mapper.Map<DepartmentDTO>(newDepartment);
        return new SuccessDataResult<DepartmentDTO>(departmentDto, _localizer[Messages.DepartmentAddSuccess]);
    }
    /// <summary>
    /// Belirtilen ID'ye sahip bölümü siler.
    /// </summary>
    /// <param name="id">Silinecek bölümün ID değeri.</param>
    /// <returns>İşlem sonucu ve mesajı.</returns>
    public async Task<IResult> DeleteAsync(Guid id)
    {
        var department = await _departmentRepository.GetByIdAsync(id);
        if (department == null) { return new ErrorResult(_localizer[Messages.DepartmentNotFound]); }

        await _departmentRepository.DeleteAsync(department);
        await _departmentRepository.SaveChangesAsync();

        return new SuccessResult(_localizer[Messages.DepartmentDeletedSuccess]);
    }
    /// <summary>
    /// Tüm bölüm listesini getirir.
    /// </summary>
    /// <returns>Bölüm listesi ve işlem sonucu mesajı.</returns>
    public async Task<IResult> GetAllAsync()
    {
        var departments = await _departmentRepository.GetAllAsync();
        if (!departments.Any()) { return new ErrorResult(_localizer[Messages.ListHasNoDepartments]); }

        var departmentListDto = _mapper.Map<List<DepartmentListDTO>>(departments);
        return new SuccessDataResult<List<DepartmentListDTO>>(departmentListDto, _localizer[Messages.DepartmentListedSuccess]);
    }
    /// <summary>
    /// Belirtilen ID'ye sahip bölümün detaylarını getirir.
    /// </summary>
    /// <param name="id">Detayları getirilecek bölümün ID değeri.</param>
    /// <returns>Bölüm detayları ve işlem sonucu mesajı.</returns>
    public async Task<IResult> GetByIdAsync(Guid id)
    {
        var department = await _departmentRepository.GetByIdAsync(id);
        if (department == null) { return new ErrorResult(_localizer[Messages.DepartmentNotFound]); }

        var departmentDto = _mapper.Map<DepartmentDTO>(department);
        return new SuccessDataResult<DepartmentDTO>(departmentDto, _localizer[Messages.DepartmentFoundSuccess]);
    }
    /// <summary>
    /// Bölüm güncelleme işlemini gerçekleştirir.
    /// </summary>
    /// <param name="departmentUpdateDTO">Güncellenecek bölüm bilgileri DTO'su.</param>
    /// <returns>İşlem sonucu ve mesajı.</returns>
    public async Task<IResult> UpdateAsync(DepartmentUpdateDTO departmentUpdateDTO)
    {
        var department = await _departmentRepository.GetByIdAsync(departmentUpdateDTO.Id);
        if (department == null) { return new ErrorResult(_localizer[Messages.DepartmentNotFound]); }

        var updatedDepartment = _mapper.Map(departmentUpdateDTO, department);
        await _departmentRepository.UpdateAsync(updatedDepartment);
        await _departmentRepository.SaveChangesAsync();

        return new SuccessDataResult<DepartmentDTO>(_mapper.Map<DepartmentDTO>(updatedDepartment), _localizer[Messages.DepartmentUpdateSuccess]);
    }
}