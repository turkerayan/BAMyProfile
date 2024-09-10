using BAMyProfileApp.Core.Utilities.Results;
using BAMyProfileApp.Dtos.Certificate;

namespace BAMyProfileApp.Business.Interfaces;

public interface ICertificateService
{
    /// <summary>
    /// Yeni bir sertifika ekler.
    /// </summary>
    /// <param name="certificateCreateDTO">Eklenecek sertifikanın verilerini içeren DTO.</param>
    /// <returns>İşlemin başarı durumunu ve gerekirse verileri içeren bir sonuç nesnesi döndürür.</param>
    /// <returns></returns>
    Task<IResult> CreateAsync(CertificateCreateDTO certificateCreateDTO);

    /// <summary>
    /// Belirtilen sertifikayı siler.
    /// </summary>
    /// <param name="id">Silinecek sertifikanın kimliği.</param>
    /// <returns>İşlemin başarı durumunu ve gerekirse verileri içeren bir sonuç nesnesi döndürür.</returns>
    Task<IResult> DeleteAsync(Guid id);

    /// <summary>
    /// Belirtilen sertifikayı günceller.
    /// </summary>
    /// <param name="certificateUpdateDTO">Güncellenecek sertifikanın verilerini içeren DTO.</param>
    /// <returns>İşlemin başarı durumunu ve gerekirse verileri içeren bir sonuç nesnesi döndürür.</returns>
    Task<IResult> UpdateAsync(CertificateUpdateDTO certificateUpdateDTO);

    /// <summary>
    /// Tüm sertifikaları listeler.
    /// </summary>
    /// <returns>İşlemin başarı durumunu ve gerekirse verileri içeren bir sonuç nesnesi döndürür.</returns>
    Task<IResult> GetAllAsync();

    /// <summary>
    /// Belirtilen sertifikanın detaylarını getirir.
    /// </summary>
    /// <param name="id">Detayları alınacak sertifikanın kimliği.</param>
    /// <returns>İşlemin başarı durumunu ve gerekirse verileri içeren bir sonuç nesnesi döndürür.</returns>
    Task<IResult> GetByIdAsync(Guid id);
}
