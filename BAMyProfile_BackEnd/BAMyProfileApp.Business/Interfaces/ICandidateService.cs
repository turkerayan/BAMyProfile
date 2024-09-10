using BAMyProfileApp.Core.Utilities.Results;
using BAMyProfileApp.Dtos.Candidate;
using BAMyProfileApp.Dtos.Student;
using BAMyProfileApp.Entities.DbSets;
using BAMyProfileApp.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAMyProfileApp.Business.Interfaces
{
    public interface ICandidateService
    {
        /// <summary>
        /// Yeni bir aday ekler.
        /// </summary>
        /// <param name="studentId">Eklenecek adayın verilerini içeren Student varlığının kimliği.</param>
        /// <param name="workingStatus">Eklenecek adayın çalışma durumu.</param>
        /// <returns>İşlemin başarı durumunu ve gerekirse verileri içeren bir sonuç nesnesi döndürür.</returns>
        Task<IResult> CreateAsync(Guid studentId, int workingStatus);

        /// <summary>
        /// Belirtilen adayı siler.
        /// </summary>
        /// <param name="id">Silinecek adayın kimliği.</param>
        /// <returns>İşlemin başarı durumunu ve gerekirse verileri içeren bir sonuç nesnesi döndürür.</returns>
        Task<IResult> DeleteAsync(Guid id);


        /// <summary>
        /// Belirtilen adayı günceller.
        /// </summary>
        /// <param name="candidateUpdateDTO">Güncellenecek adayın verilerini içeren DTO.</param>
        /// <returns>İşlemin başarı durumunu ve gerekirse verileri içeren bir sonuç nesnesi döndürür.</returns>
        Task<IResult> UpdateAsync(CandidateUpdateDTO candidateUpdateDTO);

        /// <summary>
        /// Tüm adayları listeler.
        /// </summary>
        /// <returns>İşlemin başarı durumunu ve gerekirse verileri içeren bir sonuç nesnesi döndürür.</returns>
        Task<IResult> GetAllAsync();

        /// <summary>
        /// Belirtilen adayın detaylarını getirir.
        /// </summary>
        /// <param name="id">Detayları alınacak adayın kimliği.</param>
        /// <returns>İşlemin başarı durumunu ve gerekirse verileri içeren bir sonuç nesnesi döndürür.</returns>
        Task<IResult> GetByIdAsync(Guid id);

    }
}
