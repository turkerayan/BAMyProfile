using AutoMapper;
using BAMyProfileApp.Business.Constants;
using BAMyProfileApp.Business.Interfaces;
using BAMyProfileApp.Business.Resources;
using BAMyProfileApp.Core.Utilities.Results;
using BAMyProfileApp.DataAccess.Interfaces.Repositories;
using BAMyProfileApp.Dtos.Capability;
using BAMyProfileApp.Dtos.Example;
using BAMyProfileApp.Entities.DbSets;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAMyProfileApp.Business.Concretes;

public class CapabilityService : ICapabilityService
{
    private readonly ICapabilityRepository _capabilityRepository;
    private readonly IMapper _mapper;
    private readonly IStringLocalizer<MessageResources> _localizer;

    public CapabilityService(ICapabilityRepository capabilityRepository, IMapper mapper, IStringLocalizer<MessageResources> localizer)
    {
        _capabilityRepository = capabilityRepository;
        _mapper = mapper;
        _localizer = localizer;
    }
    /// <summary>
    /// Verilen CapabilityCreateDTO kullanılarak yeni bir yetenek oluşturur. Bu metod, DTO'yu Capability nesnesine eşler, onu depoya ekler ve değişiklikleri kaydeder. Oluşturulan CapabilityDTO ve başarı mesajını içeren bir sonuç nesnesi döndürür.
    /// </summary>
    /// <param name="capabilityCreateDTO">Yeni bir yetenek oluşturmak için kullanılan veri aktarım nesnesi.</param>
    /// <returns>Oluşturulan CapabilityDTO ve başarı mesajını içeren bir SuccessDataResult döndürür.</returns>

    public async Task<IResult> CreateAsync(CapabilityCreateDTO capabilityCreateDTO)
    {
        var hasCapability = await _capabilityRepository.AnyAsync(x => x.CapabilityName.ToLower() == capabilityCreateDTO.CapabilityName.ToLower());
        if (hasCapability) { return new ErrorResult(_localizer[Messages.CapabilityAlreadyExists]); }
        var newCapability = _mapper.Map<Capability>(capabilityCreateDTO);
        await _capabilityRepository.AddAsync(newCapability);
        await _capabilityRepository.SaveChangesAsync();
        var capabilityDto = _mapper.Map<CapabilityDTO>(newCapability);
        return new SuccessDataResult<CapabilityDTO>(capabilityDto, _localizer[Messages.CapabilityAddSuccess]);
    }
    /// <summary>
    /// Sağlanan ID ile tanımlanan mevcut bir yeteneği siler. Yeteneğin depoda olup olmadığını kontrol eder. Eğer varsa, yeteneği siler ve değişiklikleri kaydeder. Silme işlemi başarılı olursa başarı sonucu, aksi takdirde hata sonucu döndürür.
    /// </summary>
    /// <param name="id">Silinecek yeteneğin benzersiz tanımlayıcısı.</param>
    /// <returns>Silme işleminin başarılı olup olmadığını gösteren bir IResult döndürür.</returns>

    public async Task<IResult> DeleteAsync(Guid id)
    {
        var capability = await _capabilityRepository.GetByIdAsync(id);
        if (capability == null) { return new ErrorResult(_localizer[Messages.CapabilityNotFound]); }
        await _capabilityRepository.DeleteAsync(capability);
        await _capabilityRepository.SaveChangesAsync();
        return new SuccessResult(_localizer[Messages.CapabilityDeletedSuccess]);
    }
    /// <summary>
    /// Depodaki tüm yetenekleri alır. Eğer hiç yetenek bulunmazsa, bir hata sonucu döndürür. Aksi takdirde, yetenekleri CapabilityListDTO'ların bir listesine eşler ve başarı mesajı ile birlikte döndürür.
    /// </summary>
    /// <returns>Yetenekler bulunursa, CapabilityListDTO listesi ve başarı mesajını içeren bir SuccessDataResult; aksi takdirde hata sonucu döndürür.</returns>

    public async Task<IResult> GetAllAsync()
    {
        var capabilities = await _capabilityRepository.GetAllAsync();
        if (capabilities.Count() <= 0) { return new ErrorResult(_localizer[Messages.ListHasNoCapability]); }
        var capabilitiesListDto = _mapper.Map<List<CapabilityListDTO>>(capabilities);
        return new SuccessDataResult<List<CapabilityListDTO>>(capabilitiesListDto, _localizer[Messages.CapabilityListedSuccess]);
    }
    /// <summary>
    /// ID'si ile belirli bir yeteneği alır. Yeteneğin depoda olup olmadığını kontrol eder. Bulunamazsa, bir hata sonucu döndürür. Aksi takdirde, yeteneği CapabilityDTO'ya eşler ve başarı mesajı ile döndürür.
    /// </summary>
    /// <param name="id">Alınacak yeteneğin benzersiz tanımlayıcısı.</param>
    /// <returns>Bulunursa, CapabilityDTO ve başarı mesajını içeren bir SuccessDataResult; aksi takdirde hata sonucu döndürür.</returns>

    public async Task<IResult> GetByIdAsync(Guid id)
    {
        var capability = await _capabilityRepository.GetByIdAsync(id);
        if (capability == null) { return new ErrorResult(_localizer[Messages.CapabilityNotFound]); }
        var capabilityDto = _mapper.Map<CapabilityDTO>(capability);
        return new SuccessDataResult<CapabilityDTO>(capabilityDto, _localizer[Messages.CapabilityFoundSuccess]);
    }
    /// <summary>
    /// CapabilityUpdateDTO'da sağlanan bilgilerle mevcut bir yeteneği günceller. Öncelikle ID ile mevcut yeteneği bulur. Bulunursa, yeteneği günceller ve değişiklikleri kaydeder. Güncellenen CapabilityDTO ve başarı mesajını içeren bir sonuç nesnesi döndürür.
    /// </summary>
    /// <param name="capabilityUpdateDTO">Yeteneği güncellemek için kullanılan veri aktarım nesnesi.</param>
    /// <returns>Güncellenen CapabilityDTO ve başarı mesajını içeren bir SuccessDataResult döndürür.</returns>

    public async Task<IResult> UpdateAsync(CapabilityUpdateDTO capabilityUpdateDTO)
    {
        var capabilityControl = await _capabilityRepository.AnyAsync(x => x.CapabilityName.ToLower() == capabilityUpdateDTO.CapabilityName.ToLower());
        if (capabilityControl) { return new ErrorResult(_localizer[Messages.CapabilityAlreadyExists]); }
        var capability = await _capabilityRepository.GetByIdAsync(capabilityUpdateDTO.Id);
        if (capability == null) { return new ErrorResult(_localizer[Messages.CapabilityNotFound]); }
        var updatedCapability = _mapper.Map(capabilityUpdateDTO, capability);
        await _capabilityRepository.UpdateAsync(updatedCapability);
        await _capabilityRepository.SaveChangesAsync();
        return new SuccessDataResult<CapabilityDTO>(_mapper.Map<CapabilityDTO>(updatedCapability), _localizer[Messages.CapabilityUpdateSuccess]);
    }
}
