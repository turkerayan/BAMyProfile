using BAMyProfileApp.Core.Utilities.Results;
using BAMyProfileApp.Dtos.JobSkill;

namespace BAMyProfileApp.Business.Interfaces;

public interface IJobSkillService
{
    /// <summary>
    /// Bir iş ilanına yeni bir iş becerisi ekler
    /// </summary>
    /// <param name="jobSkillCreateDTO">Avantaj eklenecek ilanına ve iş becerisine ait bilgileri içerir </param>
    /// <returns>İşlemin başarı durumunu ve verileri döner</returns>
    Task<IResult> CreateAsync(JobSkillCreateDTO jobSkillCreateDTO);

    /// <summary>
    /// Bir iş ilanına eklenmiş bir iş becerisini siler
    /// </summary>
    /// <param name="id">İş ilanı için eklenmiş iş becerisine dair id</param>
    /// <returns>İşlemin başarı durumunu ve verileri döner</returns>
    Task<IResult> DeleteAsync(Guid id);

    /// <summary>
    /// Bir iş ilanına eklenmiş bir iş avantajını günceller
    /// </summary>
    /// <param name="jobSkillUpdateDTO">İş ilanına eklenmiş iş avantajını güncellemek için gerekli bilgileri içerir</param>
    /// <returns>İşlemin başarı durumunu ve verileri döner</returns>
    Task<IResult> UpdateAsync(JobSkillUpdateDTO jobSkillUpdateDTO);

    /// <summary>
    /// Tüm iş ilanlarında yer alan tüm iş becerilerini listeler.
    /// </summary>
    /// <returns>İşlemin başarı durumunu ve gerekirse verileri içeren bir sonuç nesnesi döndürür.</returns>
    Task<IResult> GetAllAsync();

    /// <summary>
    /// Id ye göre bir iş ilanına eklenmiş iş becerisine ait detayları getirir
    /// </summary>
    /// <param name="id">Detayları getirilecek iş ilanına eklenmiş iş becerisine ait id</param>
    /// <returns>İşlemin başarı durumunu ve veriyi döner</returns>
    Task<IResult> GetByIdAsync(Guid id);
}
