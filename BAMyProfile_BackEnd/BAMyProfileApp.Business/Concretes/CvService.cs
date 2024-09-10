using AutoMapper;
using BAMyProfileApp.Business.Constants;
using BAMyProfileApp.Business.Interfaces;
using BAMyProfileApp.Core.Utilities.Results;
using BAMyProfileApp.Core.DataAccess.EntityFramework;
using BAMyProfileApp.Dtos.Cv;
using BAMyProfileApp.Entities.DbSets;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BAMyProfileApp.DataAccess.Interfaces.Repositories;
using BAMyProfileApp.Business.Resources;
using Microsoft.Extensions.Localization;

namespace BAMyProfileApp.Business.Concretes;

public class CvService : ICvService
{
    private readonly ICvRepository _cvRepository;
    private readonly IMapper _mapper;
    private readonly IStringLocalizer<MessageResources> _localizer;

    public CvService(ICvRepository cvRepository, IMapper mapper, IStringLocalizer<MessageResources> localizer)
    {
        _cvRepository = cvRepository;
        _mapper = mapper;
        _localizer = localizer;
    }
    /// <summary>
    /// Yeni bir özgeçmiş oluşturur.
    /// </summary>
    /// <param name="cvCreateDTO">Oluşturulacak özgeçmişin veri transfer nesnesi.</param>
    /// <returns>Oluşturma işleminin sonucunu temsil eden IResult.</returns>
    public async Task<IResult> CreateAsync(CvCreateDTO cvCreateDTO)
    {
        var hasCv = await _cvRepository.AnyAsync(x => x.Title.ToLower() == cvCreateDTO.Title.ToLower());
        if (hasCv) { return new ErrorResult(_localizer[Messages.CvAlreadyExists]); }
        var newCv = _mapper.Map<Cv>(cvCreateDTO);
        await _cvRepository.AddAsync(newCv);
        await _cvRepository.SaveChangesAsync();
        var cvDto = _mapper.Map<CvDTO>(newCv);
        return new SuccessDataResult<CvDTO>(cvDto, _localizer[Messages.CvAddSuccess]);
    }
    /// <summary>
    /// Belirtilen özgeçmişi siler.
    /// </summary>
    /// <param name="id">Silinecek özgeçmişin kimliği.</param>
    /// <returns>Silme işleminin sonucunu temsil eden IResult.</returns>
    public async Task<IResult> DeleteAsync(Guid id)
    {
        var cv = await _cvRepository.GetByIdAsync(id);
        if (cv == null) { return new ErrorResult(_localizer[Messages.CvNotFound]); }
        await _cvRepository.DeleteAsync(cv);
        await _cvRepository.SaveChangesAsync();
        return new SuccessResult(_localizer[Messages.CvDeletedSuccess]);
    }
    /// <summary>
    /// Tüm özgeçmişleri getirir.
    /// </summary>
    /// <returns>Özgeçmiş listesinin sonucunu temsil eden IResult.</returns>
    public async Task<IResult> GetAllAsync()
    {
        var cvs = await _cvRepository.GetAllAsync();
        if (cvs.Count() <= 0) { return new ErrorResult(_localizer[Messages.ListHasNoCvs]); }
        var cvListDto = _mapper.Map<List<CvListDTO>>(cvs);
        return new SuccessDataResult<List<CvListDTO>>(cvListDto, _localizer[Messages.CvListedSuccess]);
    }
    /// <summary>
    /// Belirtilen kimliğe sahip özgeçmişi getirir.
    /// </summary>
    /// <param name="id">Getirilecek özgeçmişin kimliği.</param>
    /// <returns>Getirilen özgeçmişin sonucunu temsil eden IResult.</returns>
    public async Task<IResult> GetByIdAsync(Guid id)
    {
        var cv = await _cvRepository.GetByIdAsync(id);
        if (cv == null) { return new ErrorResult(_localizer[Messages.CvNotFound]); }
        var cvDto = _mapper.Map<CvDTO>(cv);
        return new SuccessDataResult<CvDTO>(cvDto, _localizer[Messages.CvFoundSuccess]);
    }
    /// <summary>
    /// Özgeçmişi günceller.
    /// </summary>
    /// <param name="cvUpdateDTO">Güncellenecek özgeçmişin veri transfer nesnesi.</param>
    /// <returns>Güncelleme işleminin sonucunu temsil eden IResult.</returns>
    public async Task<IResult> UpdateAsync(CvUpdateDTO cvUpdateDTO)
    {
        var cv = await _cvRepository.GetByIdAsync(cvUpdateDTO.Id);
        if (cv == null) { return new ErrorResult(_localizer[Messages.CvNotFound]); }
        var updatedCv = _mapper.Map(cvUpdateDTO, cv);
        await _cvRepository.UpdateAsync(updatedCv);
        await _cvRepository.SaveChangesAsync();
        return new SuccessDataResult<CvDTO>(_mapper.Map<CvDTO>(updatedCv), _localizer[Messages.CvUpdateSuccess]);
    }

    /// <summary>
    /// Belirtilen e-posta adresine sahip kullanıcının özgeçmişlerini getirir.
    /// </summary>
    /// <param name="emailAddress">Getirilecek özgeçmişlerin sahip olduğu kullanıcının e-posta adresi</param>
    /// <returns>Operasyon sonucunu ve özgeçmiş listesini temsil eden IResult nesnesi</returns>
    public async Task<IResult> GetCvsByEmailAsync(string emailAddress)
    {
        var cvs = await _cvRepository.GetAllAsync(c => c.Student.Email == emailAddress);
        if (cvs == null || !cvs.Any())
        {
            return new ErrorResult(_localizer[Messages.CvNotFound]);
        }

        var cvListDto = _mapper.Map<List<CvDTO>>(cvs);
        return new SuccessDataResult<List<CvDTO>>(cvListDto, _localizer["CvFoundForEmail"]);
    }
}



