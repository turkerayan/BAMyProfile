using BAMyProfileApp.Core.Utilities.Results;
using BAMyProfileApp.Dtos.Job;

namespace BAMyProfileApp.Business.Interfaces;

public interface IJobService
{
    /// <summary>
    /// Yeni bir iş ilanı ekler
    /// </summary>
    /// <param name="jobCreateDTO">Yeni iş ilanına ait bilgileri içerir </param>
    /// <returns>İşlemin başarı durumunu ve verileri döner</returns>
    Task<IResult> CreateAsync(JobCreateDTO jobCreateDTO);

    /// <summary>
    /// Bir iş ilanını siler
    /// </summary>
    /// <param name="id">Silinecek iş ilanına ait id</param>
    /// <returns>İşlemin başarı durumunu ve verileri döner</returns>
    Task<IResult> DeleteAsync(Guid id);

    /// <summary>
    /// Bir iş ilanını günceller
    /// </summary>
    /// <param name="jobUpdateDTO">Güncellenecek iş ilanına ait bilgileri içerir</param>
    /// <returns>İşlemin başarı durumunu ve verileri döner</returns>
    Task<IResult> UpdateAsync(JobUpdateDTO jobUpdateDTO);

    /// <summary>
    /// Tüm iş ilanlarını listeler.
    /// </summary>
    /// <returns>İşlemin başarı durumunu ve gerekirse verileri içeren bir sonuç nesnesi döndürür.</returns>
    Task<IResult> GetAllAsync();

    /// <summary>
    /// Id ye göre iş ilanına ait detayları getirir
    /// </summary>
    /// <param name="id">Detayları getirilecek iş ilanına ait id</param>
    /// <returns>İşlemin başarı durumunu ve veriyi döner</returns>
    Task<IResult> GetByIdAsync(Guid id);
}