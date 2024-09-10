using BAMyProfileApp.Core.Utilities.Results;
using BAMyProfileApp.Dtos.Example;
using BAMyProfileApp.Dtos.Student;
using BAMyProfileApp.Entities.DbSets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAMyProfileApp.Business.Interfaces
{
    public interface IStudentService
    {

        /// <summary>
        /// Yeni bir öğrenci ekler.
        /// </summary>
        /// <param name="studentCreateDTO">Eklenecek öğrencinin verilerini içeren DTO.</param>
        /// <returns>İşlemin başarı durumunu ve gerekirse verileri içeren bir sonuç nesnesi döndürür.</returns>
        Task<IResult> CreateAsync(StudentCreateDTO studentCreateDTO);

        /// <summary>
        /// Belirtilen öğrenciyi siler.
        /// </summary>
        /// <param name="id">Silinecek öğrencinin kimliği.</param>
        /// <returns>İşlemin başarı durumunu ve gerekirse verileri içeren bir sonuç nesnesi döndürür.</returns>
        Task<IResult> DeleteAsync(Guid id);

        /// <summary>
        /// Belirtilen öğrenciyi günceller.
        /// </summary>
        /// <param name="studentUpdateDTO">Güncellenecek öğrencinin verilerini içeren DTO.</param>
        /// <returns>İşlemin başarı durumunu ve gerekirse verileri içeren bir sonuç nesnesi döndürür.</returns>
        Task<IResult> UpdateAsync(StudentUpdateDTO studentUpdateDTO);

        /// <summary>
        /// Tüm öğrencileri listeler.
        /// </summary>
        /// <returns>İşlemin başarı durumunu ve gerekirse verileri içeren bir sonuç nesnesi döndürür.</returns>
        Task<IResult> GetAllAsync();

        /// <summary>
        /// Belirtilen öğrencinin detaylarını getirir.
        /// </summary>
        /// <param name="id">Detayları alınacak öğrencinin kimliği.</param>
        /// <returns>İşlemin başarı durumunu ve gerekirse verileri içeren bir sonuç nesnesi döndürür.</returns>
        Task<IResult> GetByIdAsync(Guid id);
        
    }
}
