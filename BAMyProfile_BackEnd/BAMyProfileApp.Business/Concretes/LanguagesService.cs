using AutoMapper;
using BAMyProfileApp.Business.Constants;
using BAMyProfileApp.Business.Interfaces;
using BAMyProfileApp.Business.Resources;
using BAMyProfileApp.Core.Utilities.Results;
using BAMyProfileApp.DataAccess.Interfaces.Repositories;
using BAMyProfileApp.Dtos.Example;
using BAMyProfileApp.Dtos.Languages;
using BAMyProfileApp.Entities.DbSets;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAMyProfileApp.Business.Concretes;

public class LanguagesService : ILanguagesService
{
    private readonly ILanguagesRepository _languagesRepository;
    private readonly IMapper _mapper;
    private readonly IStringLocalizer<MessageResources> _localizer;

    public LanguagesService(ILanguagesRepository languagesRepository, IMapper mapper, IStringLocalizer<MessageResources> localizer)
    {
        _languagesRepository = languagesRepository;
        _mapper = mapper;
        _localizer=localizer;
    }
    /// <summary>
    /// Verilen LanguagesCreateDTO kullanılarak yeni bir dil oluşturur. Bu metod, sağlanan dil adının zaten var olup olmadığını kontrol eder ve varsa bir hata sonucu döndürür. Yeni dil, DTO'dan haritalanır, depoya eklenir ve değişiklikler kaydedilir. Oluşturulan LanguagesDTO ve başarı mesajını içeren bir sonuç nesnesi döndürür.
    /// </summary>
    /// <param name="languagesCreateDTO">Yeni bir dil oluşturmak için kullanılan veri aktarım nesnesi.</param>
    /// <returns>Oluşturulan LanguagesDTO ve başarı mesajını içeren bir SuccessDataResult döndürür.</returns>

    public async Task<IResult> CreateAsync(LanguagesCreateDTO languagesCreateDTO)
    {
        var hasLanguage = await _languagesRepository.AnyAsync(x => x.LanguageName.ToLower() == languagesCreateDTO.LanguageName.ToLower());
        if (hasLanguage) { return new ErrorResult(_localizer[Messages.LanguagesAlreadyExists]); }
        var newLanguage = _mapper.Map<Languages>(languagesCreateDTO);
        await _languagesRepository.AddAsync(newLanguage);
        await _languagesRepository.SaveChangesAsync();
        var languagesDto = _mapper.Map<LanguagesDTO>(newLanguage);
        return new SuccessDataResult<LanguagesDTO>(languagesDto, _localizer[Messages.LanguagesAddSuccess]);
    }
    /// <summary>
    /// Sağlanan ID ile tanımlanan mevcut bir dili siler. Dilin depoda olup olmadığını kontrol eder. Eğer varsa, dili siler ve değişiklikleri kaydeder. Silme işlemi başarılı olursa başarı sonucu, aksi takdirde hata sonucu döndürür.
    /// </summary>
    /// <param name="id">Silinecek dilin benzersiz tanımlayıcısı.</param>
    /// <returns>Silme işleminin başarılı olup olmadığını gösteren bir IResult döndürür.</returns>

    public async Task<IResult> DeleteAsync(Guid id)
    {
        var language = await _languagesRepository.GetByIdAsync(id);
        if (language == null) { return new ErrorResult(_localizer[Messages.LanguagesNotFound]); }
        await _languagesRepository.DeleteAsync(language);
        await _languagesRepository.SaveChangesAsync();
        return new SuccessResult(_localizer[Messages.LanguagesDeletedSuccess]);
    }
    /// <summary>
    /// Depodaki tüm dilleri alır. Eğer hiç dil bulunmazsa, bir hata sonucu döndürür. Aksi takdirde, dilleri LanguagesListDTO'ların bir listesine eşler ve başarı mesajı ile birlikte döndürür.
    /// </summary>
    /// <returns>Diller bulunursa, LanguagesListDTO listesi ve başarı mesajını içeren bir SuccessDataResult; aksi takdirde hata sonucu döndürür.</returns>

    public async Task<IResult> GetAllAsync()
    {
        var languages = await _languagesRepository.GetAllAsync();
        if (languages.Count() <= 0) { return new ErrorResult(_localizer[Messages.ListHasNoLanguages]);}
        var languageListDto = _mapper.Map<List<LanguagesListDTO>>(languages);
        return new SuccessDataResult<List<LanguagesListDTO>>(languageListDto, _localizer[Messages.LanguagesListedSuccess]);
    }
    /// <summary>
    /// ID'si ile belirli bir dili alır. Dilin depoda olup olmadığını kontrol eder. Bulunamazsa, bir hata sonucu döndürür. Aksi takdirde, dili LanguagesDTO'ya eşler ve başarı mesajı ile döndürür.
    /// </summary>
    /// <param name="id">Alınacak dilin benzersiz tanımlayıcısı.</param>
    /// <returns>Bulunursa, LanguagesDTO ve başarı mesajını içeren bir SuccessDataResult; aksi takdirde hata sonucu döndürür.</returns>

    public async Task<IResult> GetByIdAsync(Guid id)
    {
        var language = await _languagesRepository.GetByIdAsync(id);
        if (language == null) { return new ErrorResult(_localizer[Messages.LanguagesNotFound]); }
        var languageDto = _mapper.Map<LanguagesDTO>(language);
        return new SuccessDataResult<LanguagesDTO>(languageDto, _localizer[Messages.LanguagesFoundSuccess]);
    }
    /// <summary>
    /// LanguagesUpdateDTO'da sağlanan bilgilerle mevcut bir yeteneği günceller. Öncelikle ID ile mevcut yeteneği bulur. Bulunursa, yeteneği günceller ve değişiklikleri kaydeder. Güncellenen CapabilityDTO ve başarı mesajını içeren bir sonuç nesnesi döndürür.
    /// </summary>
    /// <param name="languagesUpdateDTO">Yeteneği güncellemek için kullanılan veri aktarım nesnesi.</param>
    /// <returns>Güncellenen LanguagesDTO ve başarı mesajını içeren bir SuccessDataResult döndürür.</returns>
    public async Task<IResult> UpdateAsync(LanguagesUpdateDTO languagesUpdateDTO)
    {
        var languageControl = await _languagesRepository.AnyAsync(x => x.LanguageName.ToLower() == languagesUpdateDTO.LanguageName.ToLower());
        if (languageControl) { return new ErrorResult(_localizer[Messages.LanguagesAlreadyExists]); }
        var language = await _languagesRepository.GetByIdAsync(languagesUpdateDTO.Id);
        if (language == null) { return new ErrorResult(_localizer[Messages.LanguagesNotFound]); }
        var updatedLanguage = _mapper.Map(languagesUpdateDTO, language);
        await _languagesRepository.UpdateAsync(updatedLanguage);
        await _languagesRepository.SaveChangesAsync();
        return new SuccessDataResult<LanguagesDTO>(_mapper.Map<LanguagesDTO>(updatedLanguage), _localizer[Messages.LanguagesUpdateSuccess]);
    }
}
