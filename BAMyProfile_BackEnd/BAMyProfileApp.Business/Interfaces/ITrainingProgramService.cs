using BAMyProfileApp.Core.Utilities.Results;
using BAMyProfileApp.Dtos.TrainingProgram;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAMyProfileApp.Business.Interfaces;

public interface ITrainingProgramService
{/// <summary>
/// Eğitim programı oluşturmayı sağlar.
/// </summary>
/// <param name="trainingProgramCreateDTO"></param> Oluşturulan eğitim programının verilerini içerir.
/// <returns></returns>
    Task<IResult> CreateAsync(TrainingProgramCreateDTO trainingProgramCreateDTO);
    /// <summary>
    /// Id'si seçili olan eğitim programını siler.
    /// </summary>
    /// <param name="id"></param> Silinecek eğitim programının id'sini içerir.
    /// <returns></returns>
    Task<IResult> DeleteAsync(Guid id);
    /// <summary>
    /// Seçili olan eğitim programının içeriğini günceller.
    /// </summary>
    /// <param name="trainingProgramUpdateDTO"></param> Güncellenecek eğitim programının verilerini içerir.
    /// <returns></returns>
    Task<IResult> UpdateAsync(TrainingProgramUpdateDTO trainingProgramUpdateDTO);
    /// <summary>
    /// Bütün eğitim programlarını getirir.
    /// </summary>
    /// <returns></returns>
    Task<IResult> GetAllAsync();
    /// <summary>
    /// Id'si belirtilen eğitim programını getirir.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<IResult> GetByIdAsync(Guid id);
}
