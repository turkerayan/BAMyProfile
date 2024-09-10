using AutoMapper;
using BAMyProfileApp.Business.Constants;
using BAMyProfileApp.Business.Interfaces;
using BAMyProfileApp.Business.Resources;
using BAMyProfileApp.Core.Utilities.Results;
using BAMyProfileApp.DataAccess.Interfaces.Repositories;
using BAMyProfileApp.Dtos.Example;
using BAMyProfileApp.Dtos.TrainingProgram;
using BAMyProfileApp.Entities.DbSets;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAMyProfileApp.Business.Concretes;

public class TrainingProgramService : ITrainingProgramService
{
    private readonly ITrainingProgramRepository _trainingProgramRepository;
    private readonly IMapper _mapper;
    private readonly IStringLocalizer<MessageResources> localizer;
    public TrainingProgramService(ITrainingProgramRepository trainingProgramrepository, IMapper mapper, IStringLocalizer<MessageResources> localizer)
    {
        _trainingProgramRepository = trainingProgramrepository;
        _mapper = mapper;
        this.localizer = localizer;
    }

    /// <summary>
    /// Yeni bir eğitim programı eklememizi sağlar.
    /// </summary>
    /// <param name="trainingProgramCreateDTO"></param>Eklenecek eğitim programının verilerini içerir.
    /// <returns>Eğer aynı isimde bir eğitim varsa hata mesajı verir, yoksa başarı durumunu ifade eden bir sonuç döner.</returns>
    public async Task<IResult> CreateAsync(TrainingProgramCreateDTO trainingProgramCreateDTO)
    {
        var createTrainingProgram = await _trainingProgramRepository.AnyAsync(x => x.Name.ToLower() == trainingProgramCreateDTO.Name.ToLower());
        if (createTrainingProgram) { return new ErrorResult(localizer[Messages.TrainingProgramAlreadyExists]); }
        var newTrainingProgram = _mapper.Map<TrainingProgram>(trainingProgramCreateDTO);
        await _trainingProgramRepository.AddAsync(newTrainingProgram);
        await _trainingProgramRepository.SaveChangesAsync();
        var trainingProgramDto = _mapper.Map<TrainingProgramDTO>(newTrainingProgram);
        return new SuccessDataResult<TrainingProgramDTO>(trainingProgramDto, localizer[Messages.TrainingProgramAddSuccess] );
    }

    /// <summary>
    /// Belirli bir id değerine sahip eğitim programını silmeyi amaçlar.
    /// </summary>
    /// <param name="id"></param> Database'den silinecek eğitimin kimliği
    /// <returns>Eğer id değeri bulunamazsa hata döner, id bulunursa silindiğini ifade eden sonuç döner.</returns>
    public async Task<IResult> DeleteAsync(Guid id)
    {
        var trainingPrograms = await _trainingProgramRepository.GetByIdAsync(id);
        if(trainingPrograms == null) { return new ErrorResult(localizer[Messages.TrainingProgramNotFound]); }
        await _trainingProgramRepository.DeleteAsync(trainingPrograms);
        await _trainingProgramRepository.SaveChangesAsync();
        return new SuccessResult(localizer[Messages.TrainingProgramDeletedSuccess]);
    }

    /// <summary>
    /// Tüm eğitim programlarını listeler.
    /// </summary>
    /// <returns>Eğitim programı bulunamazsa hata mesajı döner, eğer varsa bütün eğitim programlarını getirir.</returns>
    public async Task<IResult> GetAllAsync()
    {
        var trainingPrograms = await _trainingProgramRepository.GetAllAsync();
        if( trainingPrograms.Count() <= 0) { return new ErrorResult(localizer[Messages.ListHasNoTrainingProgram]); }
        var trainingProgramListDto = _mapper.Map<List<TrainingProgramListDTO>>(trainingPrograms);
        return new SuccessDataResult<List<TrainingProgramListDTO>>(trainingProgramListDto, localizer[Messages.TrainingProgramListedSuccess]);
    }

    /// <summary>
    /// Kimliği belli olan eğitim programını getirir.
    /// </summary>
    /// <param name="id"></param>İstenen eğitim programının kimliği
    /// <returns>Eğer belirtilen id değeri yoksa hata döner, varsa belirtilen id'nin sonucunu döndürür. </returns>
    public async Task<IResult> GetByIdAsync(Guid id)
    {
        var trainingProgram = await _trainingProgramRepository.GetByIdAsync(id);
        if (trainingProgram == null) { return new ErrorResult(localizer[Messages.TrainingProgramNotFound]); }
        var trainingProgramDto = _mapper.Map<TrainingProgramDTO>(trainingProgram);
        return new SuccessDataResult<TrainingProgramDTO>(trainingProgramDto, localizer[Messages.TrainingProgramFoundSuccess]);
    }

    /// <summary>
    /// Id'si çağrılan eğitimi günceller.
    /// </summary>
    /// <param name="trainingProgramUpdateDTO"></param> Güncellenecek eğitimin verilerini içerir
    /// <returns>Güncellenecek eğitim programı databasede bulunamazsa hata döner, bulunursa id'si verilen eğitim programını güncellemeyi amaçlar</returns>
    public async Task<IResult> UpdateAsync(TrainingProgramUpdateDTO trainingProgramUpdateDTO)
    {
        var trainingProgram = await _trainingProgramRepository.GetByIdAsync(trainingProgramUpdateDTO.Id);
        if (trainingProgram == null) { return new ErrorResult(localizer[Messages.TrainingProgramNotFound]); }
        var updatedTrainingProgram = _mapper.Map(trainingProgramUpdateDTO, trainingProgram);
        await _trainingProgramRepository.UpdateAsync(updatedTrainingProgram);
        await _trainingProgramRepository.SaveChangesAsync();
        return new SuccessDataResult<TrainingProgramDTO>(_mapper.Map<TrainingProgramDTO>(updatedTrainingProgram), localizer[Messages.TrainingProgramUpdateSuccess] );
    }
}
