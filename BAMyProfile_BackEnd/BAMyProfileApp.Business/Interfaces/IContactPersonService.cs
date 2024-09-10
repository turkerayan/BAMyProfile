using BAMyProfileApp.Core.Utilities.Results;
using BAMyProfileApp.Dtos.ContactPerson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAMyProfileApp.Business.Interfaces
{
    public interface IContactPersonService
    {
        /// <summary>
        /// Yeni bir sertifika ekler.
        /// </summary>
        /// <param name="contactPersonCreateDto">Eklenecek bağlantılı kişinin verilerini içeren DTO.</param>
        /// <returns>İşlemin başarı durumunu ve gerekirse verileri içeren bir sonuç nesnesi döndürür.</param>
        /// <returns></returns>

        Task<IResult> CreateAync(ContactPersonCreateDto contactPersonCreateDto);
        /// <summary>
        /// Belirtilen sertifikayı günceller.
        /// </summary>
        /// <param name="contactPersonUpdateDto">Güncellenecek bağlantılı kişinin verilerini içeren DTO.</param>
        /// <returns>İşlemin başarı durumunu ve gerekirse verileri içeren bir sonuç nesnesi döndürür.</returns>
        Task<IResult> UpdateAync(ContactPersonUpdateDto contactPersonUpdateDto);
        /// <summary>
        /// Belirtilen sertifikayı siler.
        /// </summary>
        /// <param name="id">Silinecek bağlantılı kişi kimliği.</param>
        /// <returns>İşlemin başarı durumunu ve gerekirse verileri içeren bir sonuç nesnesi döndürür.</returns>
        Task<IResult> DeleteAync(Guid id);
        /// <summary>
        /// Tüm bağlantılı kişilerin listeler.
        /// </summary>
        /// <returns>İşlemin başarı durumunu ve gerekirse verileri içeren bir sonuç nesnesi döndürür.</returns>
        Task<IResult> GetAllAync();
        /// <summary>
        /// Belirtilen sertifikanın detaylarını getirir.
        /// </summary>
        /// <param name="id">Detayları alınacak bağlantılı kişinin kimliği.</param>
        /// <returns>İşlemin başarı durumunu ve gerekirse verileri içeren bir sonuç nesnesi döndürür.</returns>
        Task<IResult> GetByIdAsync(Guid id);
    }
}
