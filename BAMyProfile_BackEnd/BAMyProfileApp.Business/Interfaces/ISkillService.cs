using BAMyProfileApp.Core.Utilities.Results;
using BAMyProfileApp.Dtos.Skill;

namespace BAMyProfileApp.Business.Interfaces;

public interface ISkillService
{
    /// <summary>
    /// Yeni bir iş becerisi ekler
    /// </summary>
    /// <param name="skillCreateDTO">Yeni iş becerisine ait bilgileri içerir </param>
    /// <returns>İşlemin başarı durumunu ve verileri döner</returns>
    Task<IResult> CreateAsync(SkillCreateDTO skillCreateDTO);

    /// <summary>
    /// Bir iş becerisini siler
    /// </summary>
    /// <param name="id">Silinecek iş becerisine ait id</param>
    /// <returns>İşlemin başarı durumunu ve verileri döner</returns>
    Task<IResult> DeleteAsync(Guid id);

    /// <summary>
    /// Bir iş becerisini günceller
    /// </summary>
    /// <param name="skillUpdateDTO">Güncellenecek iş becerisine ait bilgileri içerir</param>
    /// <returns>İşlemin başarı durumunu ve verileri döner</returns>
    Task<IResult> UpdateAsync(SkillUpdateDTO skillUpdateDTO);

    /// <summary>
    /// Tüm iş becerilerini listeler.
    /// </summary>
    /// <returns>İşlemin başarı durumunu ve gerekirse verileri içeren bir sonuç nesnesi döndürür.</returns>
    Task<IResult> GetAllAsync();

    /// <summary>
    /// Id ye göre iş becerisine ait detayları getirir
    /// </summary>
    /// <param name="id">Detayları getirilecek iş becerisine ait id</param>
    /// <returns>İşlemin başarı durumunu ve veriyi döner</returns>
    Task<IResult> GetByIdAsync(Guid id);
}
