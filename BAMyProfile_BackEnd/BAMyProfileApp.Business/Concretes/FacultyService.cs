using AutoMapper;
using BAMyProfileApp.Business.Constants;
using BAMyProfileApp.Business.Interfaces;
using BAMyProfileApp.Business.Resources;
using BAMyProfileApp.Core.Utilities.Results;
using BAMyProfileApp.DataAccess.Interfaces.Repositories;
using BAMyProfileApp.Dtos.Faculty;
using BAMyProfileApp.Entities.DbSets;
using Microsoft.Extensions.Localization;

namespace BAMyProfileApp.Business.Concretes;

public class FacultyService : IFacultyService
{
    private readonly IFacultyRepository _facultyRepository;
    private readonly IMapper _mapper;
    private readonly IStringLocalizer<MessageResources> _localizer;

    public FacultyService(IFacultyRepository facultyRepository, IMapper mapper, IStringLocalizer<MessageResources> localizer)
    {
        _facultyRepository = facultyRepository;
        _mapper = mapper;
        _localizer = localizer;
    }
    /// <summary>
    /// Yeni bir fakülte oluşturma işlemini gerçekleştirir.
    /// </summary>
    /// <param name="facultyCreateDTO">Oluşturulacak fakülte bilgileri DTO'su.</param>
    /// <returns>İşlem sonucu ve mesajı.</returns>
    public async Task<IResult> CreateAsync(FacultyCreateDTO facultyCreateDTO)
    {
        var hasFaculty = await _facultyRepository.AnyAsync(f => f.Name.ToLower() == facultyCreateDTO.Name.ToLower() && f.UniversityId == facultyCreateDTO.UniversityId);
        if (hasFaculty) { return new ErrorResult(_localizer[Messages.FacultyAlreadyExists]); }

        var newFaculty = _mapper.Map<Faculty>(facultyCreateDTO);
        await _facultyRepository.AddAsync(newFaculty);
        await _facultyRepository.SaveChangesAsync();

        var facultyDto = _mapper.Map<FacultyDTO>(newFaculty);
        return new SuccessDataResult<FacultyDTO>(facultyDto, _localizer[Messages.FacultyAddSuccess]);
    }
    /// <summary>
    /// Belirtilen ID'ye sahip fakülteyi siler.
    /// </summary>
    /// <param name="id">Silinecek fakültenin ID değeri.</param>
    /// <returns>İşlem sonucu ve mesajı.</returns>
    public async Task<IResult> DeleteAsync(Guid id)
    {
        var faculty = await _facultyRepository.GetByIdAsync(id);
        if (faculty == null) { return new ErrorResult(_localizer[Messages.FacultyNotFound]); }

        await _facultyRepository.DeleteAsync(faculty);
        await _facultyRepository.SaveChangesAsync();

        return new SuccessResult(_localizer[Messages.FacultyDeletedSuccess]);
    }
    /// <summary>
    /// Tüm fakültelerin listesini getirir.
    /// </summary>
    /// <returns>Fakülte listesi ve işlem sonucu mesajı.</returns>
    public async Task<IResult> GetAllAsync()
    {
        var faculties = await _facultyRepository.GetAllAsync();
        if (!faculties.Any()) { return new ErrorResult(_localizer[Messages.ListHasNoFaculties]); }

        var facultyListDto = _mapper.Map<List<FacultyListDTO>>(faculties);
        return new SuccessDataResult<List<FacultyListDTO>>(facultyListDto, _localizer[Messages.FacultyListedSuccess]);
    }
    /// <summary>
    /// Belirtilen ID'ye sahip fakültenin detaylarını getirir.
    /// </summary>
    /// <param name="id">Detayları getirilecek fakültenin ID değeri.</param>
    /// <returns>Fakülte detayları ve işlem sonucu mesajı.</returns>
    public async Task<IResult> GetByIdAsync(Guid id)
    {
        var faculty = await _facultyRepository.GetByIdAsync(id);
        if (faculty == null) { return new ErrorResult(_localizer[Messages.FacultyNotFound]); }

        var facultyDto = _mapper.Map<FacultyDTO>(faculty);
        return new SuccessDataResult<FacultyDTO>(facultyDto, _localizer[Messages.FacultyFoundSuccess]);
    }
    /// <summary>
    /// Fakülte güncelleme işlemini gerçekleştirir.
    /// </summary>
    /// <param name="facultyUpdateDTO">Güncellenecek fakülte bilgileri DTO'su.</param>
    /// <returns>İşlem sonucu ve mesajı.</returns>
    public async Task<IResult> UpdateAsync(FacultyUpdateDTO facultyUpdateDTO)
    {
        var faculty = await _facultyRepository.GetByIdAsync(facultyUpdateDTO.Id);
        if (faculty == null) { return new ErrorResult(_localizer[Messages.FacultyNotFound]); }

        var updatedFaculty = _mapper.Map(facultyUpdateDTO, faculty);
        await _facultyRepository.UpdateAsync(updatedFaculty);
        await _facultyRepository.SaveChangesAsync();

        return new SuccessDataResult<FacultyDTO>(_mapper.Map<FacultyDTO>(updatedFaculty), _localizer[Messages.FacultyUpdateSuccess]);
    }
}

