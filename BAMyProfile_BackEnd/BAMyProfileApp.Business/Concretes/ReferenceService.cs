using AutoMapper;
using BAMyProfileApp.Business.Constants;
using BAMyProfileApp.Business.Interfaces;
using BAMyProfileApp.Core.Utilities.Results;
using BAMyProfileApp.DataAccess.Interfaces.Repositories;
using BAMyProfileApp.Dtos.References;
using BAMyProfileApp.Entities.DbSets;
using BAMyProfileApp.Business.Resources;
using Microsoft.Extensions.Localization;

namespace BAMyProfileApp.Business.Concretes;

public class ReferenceService : IReferenceService
{
    private readonly IReferenceRepository _referenceRepository;
    private readonly IMapper _mapper;
    private readonly IStringLocalizer<MessageResources> _localizer;


    public ReferenceService(IReferenceRepository referenceRepository, IMapper mapper, IStringLocalizer<MessageResources> localizer)
    {
        _referenceRepository = referenceRepository;
        _mapper = mapper;
        _localizer = localizer;

    }
    /// <summary>
    /// Yeni bir referans ekler.
    /// </summary>
    /// <param name="referenceCreateDTO">Eklenecek referansın verilerini içeren DTO.</param>
    /// <returns>İşlemin başarı durumunu ve gerekirse verileri içeren bir sonuç nesnesi döndürür.</returns>
    public async Task<IResult> CreateAsync(ReferenceCreateDTO referenceCreateDTO)
    {
        var hasReference = await _referenceRepository.AnyAsync(x => x.Name.ToLower() == referenceCreateDTO.Name.ToLower());
        if (hasReference) { return new ErrorResult(_localizer[Messages.ReferenceAlreadyExists]); }
        var newReference = _mapper.Map<Reference>(referenceCreateDTO);
        await _referenceRepository.AddAsync(newReference);
        await _referenceRepository.SaveChangesAsync();
        var referenceDto = _mapper.Map<ReferenceDTO>(newReference);
        return new SuccessDataResult<ReferenceDTO>(referenceDto, _localizer[Messages.ReferenceAddSuccess]);
    }
    /// <summary>
    /// Belirtilen referansı siler.
    /// </summary>
    /// <param name="id">Silinecek referansın kimliği.</param>
    /// <returns>İşlemin başarı durumunu ve gerekirse verileri içeren bir sonuç nesnesi döndürür.</returns>
    public async Task<IResult> DeleteAsync(Guid id)
    {
        var reference = await _referenceRepository.GetByIdAsync(id);
        if (reference == null) { return new ErrorResult(_localizer[Messages.ReferenceNotFound]); }
        await _referenceRepository.DeleteAsync(reference);
        await _referenceRepository.SaveChangesAsync();
        return new SuccessResult(_localizer[Messages.ReferenceDeletedSuccess]);
    }
    /// <summary>
    /// Tüm referansları listeler.
    /// </summary>
    /// <returns>İşlemin başarı durumunu ve gerekirse verileri içeren bir sonuç nesnesi döndürür.</returns>
    public async Task<IResult> GetAllAsync()
    {
        var references = await _referenceRepository.GetAllAsync();
        if (references.Count() <= 0) { return new ErrorResult(_localizer[Messages.ListHasNoReferences]); }
        var referenceListDto = _mapper.Map<List<ReferenceListDTO>>(references);
        return new SuccessDataResult<List<ReferenceListDTO>>(referenceListDto, _localizer[Messages.ReferenceListedSuccess]);
    }
    /// <summary>
    /// Belirtilen referansın detaylarını getirir.
    /// </summary>
    /// <param name="id">Detayları alınacak referansın kimliği.</param>
    /// <returns>İşlemin başarı durumunu ve gerekirse verileri içeren bir sonuç nesnesi döndürür.</returns>
    public async Task<IResult> GetByIdAsync(Guid id)
    {
        var reference = await _referenceRepository.GetByIdAsync(id);
        if (reference == null) { return new ErrorResult(_localizer[Messages.ReferenceNotFound]); }
        var referenceDto = _mapper.Map<ReferenceDTO>(reference);
        return new SuccessDataResult<ReferenceDTO>(referenceDto, _localizer[Messages.ReferenceFoundSuccess]);
    }
    /// <summary>
    /// Belirtilen referansı günceller.
    /// </summary>
    /// <param name="referenceUpdateDTO">Güncellenecek referansın verilerini içeren DTO.</param>
    /// <returns>İşlemin başarı durumunu ve gerekirse verileri içeren bir sonuç nesnesi döndürür.</returns>
    public async Task<IResult> UpdateAsync(ReferenceUpdateDTO referenceUpdateDTO)
    {
        var reference = await _referenceRepository.GetByIdAsync(referenceUpdateDTO.Id);
        if (reference == null) { return new ErrorResult(_localizer[Messages.ReferenceNotFound]); }
        var updatedReference = _mapper.Map(referenceUpdateDTO, reference);
        await _referenceRepository.UpdateAsync(updatedReference);
        await _referenceRepository.SaveChangesAsync();
        return new SuccessDataResult<ReferenceDTO>(_mapper.Map<ReferenceDTO>(updatedReference), _localizer[Messages.ReferenceUpdateSuccess]);
    }
}
