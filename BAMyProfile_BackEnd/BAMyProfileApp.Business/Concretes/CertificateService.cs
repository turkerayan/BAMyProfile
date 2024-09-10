using AutoMapper;
using BAMyProfileApp.Business.Constants;
using BAMyProfileApp.Business.Interfaces;
using BAMyProfileApp.Business.Resources;
using BAMyProfileApp.Core.Utilities.Results;
using BAMyProfileApp.DataAccess.Interfaces.Repositories;
using BAMyProfileApp.Dtos.Certificate;
using BAMyProfileApp.Dtos.Event;
using BAMyProfileApp.Entities.DbSets;
using Microsoft.Extensions.Localization;

namespace BAMyProfileApp.Business.Concretes;

public class CertificateService : ICertificateService
{
    private readonly ICertificateRepository _certificateRepository;
    private readonly IMapper _mapper;
    private readonly IStringLocalizer<MessageResources> _localizer;

    public CertificateService(ICertificateRepository certificateRepository, IMapper mapper, IStringLocalizer<MessageResources> localizer)
    {
        _certificateRepository = certificateRepository;
        _mapper = mapper;
        _localizer = localizer;
    }
    /// <summary>
    /// Yeni bir sertifika ekler.
    /// </summary>
    /// <param name="certificateCreateDTO">Eklenecek sertifikanın verilerini içeren DTO.</param>
    /// <returns>İşlemin başarı durumunu ve gerekirse verileri içeren bir sonuç nesnesi döndürür.</param>
    /// <returns></returns>
    public async Task<IResult> CreateAsync(CertificateCreateDTO certificateCreateDTO)
    {
        var hasCertificate = await _certificateRepository.AnyAsync(x => x.Name.ToLower() == certificateCreateDTO.Name.ToLower());
        if (hasCertificate) { return new ErrorResult(_localizer[Messages.CertificateAlreadyExists]); }
        var newCertificate = _mapper.Map<Certificate>(certificateCreateDTO);

        if (certificateCreateDTO.File != null && certificateCreateDTO.File.Length > 0)
        {
            byte[] fileBytes;
            using (var memoryStream = new MemoryStream())
            {
                await certificateCreateDTO.File.CopyToAsync(memoryStream);
                fileBytes = memoryStream.ToArray();
            }
            newCertificate.File = fileBytes;
        }

        await _certificateRepository.AddAsync(newCertificate);
        await _certificateRepository.SaveChangesAsync();
        var certificateDto = _mapper.Map<CertificateDTO>(newCertificate);
        return new SuccessDataResult<CertificateDTO>(certificateDto, _localizer[Messages.CertificateAddSuccess]);
    }

    /// <summary>
    /// Belirtilen sertifikayı siler.
    /// </summary>
    /// <param name="id">Silinecek sertifikanın kimliği.</param>
    /// <returns>İşlemin başarı durumunu ve gerekirse verileri içeren bir sonuç nesnesi döndürür.</returns>
    public async Task<IResult> DeleteAsync(Guid id)
    {
        var certificate = await _certificateRepository.GetByIdAsync(id);
        if (certificate == null) { return new ErrorResult(_localizer[Messages.CertificateNotFound]); }
        await _certificateRepository.DeleteAsync(certificate);
        await _certificateRepository.SaveChangesAsync();
        return new SuccessResult(_localizer[Messages.CertificateDeletedSuccess]);
    }

    /// <summary>
    /// Tüm sertifikaları listeler.
    /// </summary>
    /// <returns>İşlemin başarı durumunu ve gerekirse verileri içeren bir sonuç nesnesi döndürür.</returns>
    public async Task<IResult> GetAllAsync()
    {
        var certificates = await _certificateRepository.GetAllAsync();
        if (certificates.Count() <= 0) { return new ErrorResult(_localizer[Messages.ListHasNoCertificates]); }
        var certificateListDto = _mapper.Map<List<CertificateListDTO>>(certificates);
        return new SuccessDataResult<List<CertificateListDTO>>(certificateListDto, _localizer[Messages.CertificateListedSuccess]);
    }

    /// <summary>
    /// Belirtilen sertifikanın detaylarını getirir.
    /// </summary>
    /// <param name="id">Detayları alınacak sertifikanın kimliği.</param>
    /// <returns>İşlemin başarı durumunu ve gerekirse verileri içeren bir sonuç nesnesi döndürür.</returns>
    public async Task<IResult> GetByIdAsync(Guid id)
    {
        var certificate = await _certificateRepository.GetByIdAsync(id);
        if (certificate == null) { return new ErrorResult(_localizer[Messages.CertificateNotFound]); }
        var certificateDto = _mapper.Map<CertificateDTO>(certificate);
        return new SuccessDataResult<CertificateDTO>(certificateDto, _localizer[Messages.CertificateFoundSuccess]);
    }

    /// <summary>
    /// Belirtilen sertifikayı günceller.
    /// </summary>
    /// <param name="certificateUpdateDTO">Güncellenecek sertifikanın verilerini içeren DTO.</param>
    /// <returns>İşlemin başarı durumunu ve gerekirse verileri içeren bir sonuç nesnesi döndürür.</returns>
    public async Task<IResult> UpdateAsync(CertificateUpdateDTO certificateUpdateDTO)
    {
        var certificate = await _certificateRepository.GetByIdAsync(certificateUpdateDTO.Id);
        if (certificate == null) { return new ErrorResult(_localizer[Messages.CertificateNotFound]); }
        var updatedCertificate = _mapper.Map(certificateUpdateDTO, certificate);
        if (certificateUpdateDTO.File != null && certificateUpdateDTO.File.Length > 0)
        {
            byte[] fileBytes;
            using (var memoryStream = new MemoryStream())
            {
                await certificateUpdateDTO.File.CopyToAsync(memoryStream);
                fileBytes = memoryStream.ToArray();
            }
            updatedCertificate.File = fileBytes;
        }
        await _certificateRepository.UpdateAsync(updatedCertificate);
        await _certificateRepository.SaveChangesAsync();
        return new SuccessDataResult<CertificateDTO>(_mapper.Map<CertificateDTO>(updatedCertificate), _localizer[Messages.CertificateUpdateSuccess]);
    }
}
