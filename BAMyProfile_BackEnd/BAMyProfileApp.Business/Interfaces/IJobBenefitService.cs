using BAMyProfileApp.Core.Utilities.Results;
using BAMyProfileApp.Dtos.JobBenefit;

namespace BAMyProfileApp.Business.Interfaces;

public interface IJobBenefitService
{
    /// <summary>
    /// Bir iş ilanına yeni bir iş avantajı (yan hak) ekler
    /// </summary>
    /// <param name="jobBenefitCreateDTO">Avantaj eklenecek ilanına ve iş avantajına ait bilgileri içerir </param>
    /// <returns>İşlemin başarı durumunu ve verileri döner</returns>
    Task<IResult> CreateAsync(JobBenefitCreateDTO jobBenefitCreateDTO);

    /// <summary>
    /// Bir iş ilanına eklenmiş bir iş avantajını siler
    /// </summary>
    /// <param name="id">İş ilanı için eklenmiş iş avantajına dair id</param>
    /// <returns>İşlemin başarı durumunu ve verileri döner</returns>
    Task<IResult> DeleteAsync(Guid id);

    /// <summary>
    /// Bir iş ilanına eklenmiş bir iş avantajını günceller
    /// </summary>
    /// <param name="jobBenefitUpdateDTO">İş ilanına eklenmiş iş avantajını güncellemek için gerekli bilgileri içerir</param>
    /// <returns>İşlemin başarı durumunu ve verileri döner</returns>
    Task<IResult> UpdateAsync(JobBenefitUpdateDTO jobBenefitUpdateDTO);

    /// <summary>
    /// Tüm iş ilanlarında yer alan tüm iş avantajlarını listeler.
    /// </summary>
    /// <returns>İşlemin başarı durumunu ve gerekirse verileri içeren bir sonuç nesnesi döndürür.</returns>
    Task<IResult> GetAllAsync();

    /// <summary>
    /// Id ye göre bir iş ilanına eklenmiş iş avantajına ait detayları getirir
    /// </summary>
    /// <param name="id">Detayları getirilecek iş ilanına eklenmiş iş avantajına ait id</param>
    /// <returns>İşlemin başarı durumunu ve veriyi döner</returns>
    Task<IResult> GetByIdAsync(Guid id);
}
