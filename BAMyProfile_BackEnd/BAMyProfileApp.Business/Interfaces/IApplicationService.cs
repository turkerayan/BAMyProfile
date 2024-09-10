using BAMyProfileApp.Core.Utilities.Results;
using BAMyProfileApp.Dtos.Application;
using BAMyProfileApp.Dtos.Benefit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAMyProfileApp.Business.Interfaces
{
    public interface IApplicationService
    {
        /// <summary>
        /// Yeni bir başvuru ekler.
        /// </summary>
        /// <param name="applicationCreateDTO">Yeni başvuruya ait bilgileri içerir. </param>
        /// <returns>İşlemin başarı durumunu ve verileri döner</returns>
        Task<IResult> CreateAsync(ApplicationCreateDTO applicationCreateDTO);

        /// <summary>
        /// Bir başvuru siler
        /// </summary>
        /// <param name="id">Silinecek başvuruya ait id</param>
        /// <returns>İşlemin başarı durumunu ve verileri döner</returns>
        Task<IResult> DeleteAsync(Guid id);

        /// <summary>
        /// Bir başvuruyu günceller.
        /// </summary>
        /// <param name="applicationUpdateDTO">Güncellenecek başvuruya ait bilgileri içerir</param>
        /// <returns>İşlemin başarı durumunu ve verileri döner</returns>
        Task<IResult> UpdateAsync(ApplicationUpdateDTO applicationUpdateDTO);

        /// <summary>
        /// Tüm başvuruları listeler.
        /// </summary>
        /// <returns>İşlemin başarı durumunu ve gerekirse verileri içeren bir sonuç nesnesi döndürür.</returns>
        Task<IResult> GetAllAsync();

        /// <summary>
        /// Id ye göre başvuruya ait detayları getirir.
        /// </summary>
        /// <param name="id">Detayları getirilecek başvuruya ait id</param>
        /// <returns>İşlemin başarı durumunu ve veriyi döner</returns>
        Task<IResult> GetByIdAsync(Guid id);
        /// <summary>
        /// Aday Id sine göre mülakatları getirir
        /// </summary>
        /// <param name="candidateId">Aday Id si</param>
        /// <returns>İşlemin başarı durumunu ve gerekirse verileri içeren bir sonuç nesnesi döndürür.</returns>
        Task<IResult> GetApplicationsByCandidateIdAsync(Guid candidateId);
    }
}
