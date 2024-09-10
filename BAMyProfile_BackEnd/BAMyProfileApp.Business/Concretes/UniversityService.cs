using AutoMapper;
using BAMyProfileApp.Business.Constants;
using BAMyProfileApp.Business.Interfaces;
using BAMyProfileApp.Business.Resources;
using BAMyProfileApp.Core.Utilities.Results;
using BAMyProfileApp.DataAccess.Interfaces.Repositories;
using BAMyProfileApp.Dtos.University;
using BAMyProfileApp.Entities.DbSets;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAMyProfileApp.Business.Concretes;

public class UniversityService : IUniversityService
{
    private readonly IUniversityRepository _universityRepository;
    private readonly IMapper _mapper;
    private readonly IStringLocalizer<MessageResources> _localizer;

    public UniversityService(IUniversityRepository universityRepository, IMapper mapper, IStringLocalizer<MessageResources> localizer)
    {
        _universityRepository = universityRepository;
        _mapper = mapper;
        _localizer = localizer;
    }
    /// <summary>
    /// Üniversite oluşturma işlemini gerçekleştirir.
    /// </summary>
    /// <param name="universityCreateDTO">Oluşturulacak üniversite bilgileri DTO'su.</param>
    /// <returns>İşlem sonucu ve mesajı.</returns>
    public async Task<IResult> CreateAsync(UniversityCreateDTO universityCreateDTO)
    {
        var hasUniversity = await _universityRepository.AnyAsync(u => u.Name.ToLower() == universityCreateDTO.Name.ToLower());
        if (hasUniversity) { return new ErrorResult(_localizer[Messages.UniversityAlreadyExists]); }

        var newUniversity = _mapper.Map<University>(universityCreateDTO);
        await _universityRepository.AddAsync(newUniversity);
        await _universityRepository.SaveChangesAsync();

        var universityDto = _mapper.Map<UniversityDTO>(newUniversity);
        return new SuccessDataResult<UniversityDTO>(universityDto, _localizer[Messages.UniversityAddSuccess]);
    }
    /// <summary>
    /// Belirtilen ID'ye sahip üniversiteyi siler.
    /// </summary>
    /// <param name="id">Silinecek üniversitenin ID değeri.</param>
    /// <returns>İşlem sonucu ve mesajı.</returns>
    public async Task<IResult> DeleteAsync(Guid id)
    {
        var university = await _universityRepository.GetByIdAsync(id);
        if (university == null) { return new ErrorResult(_localizer[Messages.UniversityNotFound]); }

        await _universityRepository.DeleteAsync(university);
        await _universityRepository.SaveChangesAsync();

        return new SuccessResult(_localizer[Messages.UniversityDeletedSuccess]);
    }
    /// <summary>
    /// Tüm üniversitelerin listesini getirir.
    /// </summary>
    /// <returns>Üniversite listesi ve işlem sonucu mesajı.</returns>
    public async Task<IResult> GetAllAsync()
    {
        var universities = await _universityRepository.GetAllAsync();
        if (!universities.Any()) { return new ErrorResult(_localizer[Messages.ListHasNoUniversities]); }

        var universityListDto = _mapper.Map<List<UniversityListDTO>>(universities);
        return new SuccessDataResult<List<UniversityListDTO>>(universityListDto, _localizer[Messages.UniversityListedSuccess]);
    }
    /// <summary>
    /// Belirtilen ID'ye sahip üniversitenin detaylarını getirir.
    /// </summary>
    /// <param name="id">Detayları getirilecek üniversitenin ID değeri.</param>
    /// <returns>Üniversite detayları ve işlem sonucu mesajı.</returns>
    public async Task<IResult> GetByIdAsync(Guid id)
    {
        var university = await _universityRepository.GetByIdAsync(id);
        if (university == null) { return new ErrorResult(_localizer[Messages.UniversityNotFound]); }

        var universityDto = _mapper.Map<UniversityDTO>(university);
        return new SuccessDataResult<UniversityDTO>(universityDto, _localizer[Messages.UniversityFoundSuccess] );
    }
    /// <summary>
    /// Üniversite güncelleme işlemini gerçekleştirir.
    /// </summary>
    /// <param name="universityUpdateDTO">Güncellenecek üniversite bilgileri DTO'su.</param>
    /// <returns>İşlem sonucu ve mesajı.</returns>
    public async Task<IResult> UpdateAsync(UniversityUpdateDTO universityUpdateDTO)
    {
        var university = await _universityRepository.GetByIdAsync(universityUpdateDTO.Id);
        if (university == null) { return new ErrorResult(_localizer[Messages.UniversityNotFound]); }

        var updatedUniversity = _mapper.Map(universityUpdateDTO, university);
        await _universityRepository.UpdateAsync(updatedUniversity);
        await _universityRepository.SaveChangesAsync();

        return new SuccessDataResult<UniversityDTO>(_mapper.Map<UniversityDTO>(updatedUniversity), _localizer[Messages.UniversityUpdateSuccess]);
    }
}
