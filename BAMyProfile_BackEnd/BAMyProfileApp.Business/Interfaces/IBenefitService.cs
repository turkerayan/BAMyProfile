using BAMyProfileApp.Core.Utilities.Results;
using BAMyProfileApp.Dtos.Benefit;

namespace BAMyProfileApp.Business.Interfaces;

public interface IBenefitService
{
    /// <summary>
    /// Yeni bir iş avantajı (yan hak) ekler
    /// </summary>
    /// <param name="benefitCreateDTO">Yeni iş avantajına ait bilgileri içerir </param>
    /// <returns>İşlemin başarı durumunu ve verileri döner</returns>
    Task<IResult> CreateAsync(BenefitCreateDTO benefitCreateDTO);

    /// <summary>
    /// Bir iş avantajını siler
    /// </summary>
    /// <param name="id">Silinecek iş avantajına ait id</param>
    /// <returns>İşlemin başarı durumunu ve verileri döner</returns>
    Task<IResult> DeleteAsync(Guid id);

    /// <summary>
    /// Bir iş avantajını günceller
    /// </summary>
    /// <param name="benefitUpdateDTO">Güncellenecek iş avantajı ait bilgileri içerir</param>
    /// <returns>İşlemin başarı durumunu ve verileri döner</returns>
    Task<IResult> UpdateAsync(BenefitUpdateDTO benefitUpdateDTO);

    /// <summary>
    /// Tüm iş avantajlarını listeler.
    /// </summary>
    /// <returns>İşlemin başarı durumunu ve gerekirse verileri içeren bir sonuç nesnesi döndürür.</returns>
    Task<IResult> GetAllAsync();

    /// <summary>
    /// Id ye göre iş avantajına ait detayları getirir
    /// </summary>
    /// <param name="id">Detayları getirilecek iş avantajına ait id</param>
    /// <returns>İşlemin başarı durumunu ve veriyi döner</returns>
    Task<IResult> GetByIdAsync(Guid id);
}
