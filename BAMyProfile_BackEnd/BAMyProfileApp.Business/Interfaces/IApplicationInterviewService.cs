using BAMyProfileApp.Core.Utilities.Results;
using BAMyProfileApp.Dtos.ApplicationInterview;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAMyProfileApp.Business.Interfaces
{
    public interface IApplicationInterviewService
    {
        /// <summary>
        /// Yeni bir mülakat ekler
        /// </summary>
        /// <param name="appInterviewCreateDTO">Yeni eklenecek mülakat bilgilerini içerir</param>
        /// <returns>İşlemin başarı durumunu ve verileri döner</returns>
        Task<IResult> CreateAsync(ApplicationInterviewCreateDTO appInterviewCreateDTO);

        /// <summary>
        /// Bir mülakatı siler
        /// </summary>
        /// <param name="id">Mülakat idsi</param>
        /// <returns>İşlemin başarı durumunu döner</returns>
        Task<IResult> DeleteAsync(Guid id);

        /// <summary>
        /// Mülakatı günceller
        /// </summary>
        /// <param name="appInterviewUpdateDTO">Güncellenecek mülakat bilgisini içerir</param>
        /// <returns>İşlemin başarı durumunu ve verileri döner</returns>
        Task<IResult> UpdateAsync(ApplicationInterviewUpdateDTO appInterviewUpdateDTO);

        /// <summary>
        /// Mülakatları listeler
        /// </summary>
        /// <returns>İşlemin başarı durumunu ve gerekirse verileri içeren bir sonuç nesnesi döndürür.</returns>
        Task<IResult> GetAllAsync();

        /// <summary>
        /// Id ye göre mülakat detaylarını getirir
        /// </summary>
        /// <param name="id">Mülakat idsi</param>
        /// <returns>İşlemin başarı durumunu ve veriyi döner</returns>
        Task<IResult> GetByIdAsync(Guid id);
        /// <summary>
        /// Şirket Idsine göre mülakatları getirir
        /// </summary>
        /// <param name="companyId">Şirket Idsi</param>
        /// <returns>İşlemin başarı durumunu ve gerekirse verileri içeren bir sonuç nesnesi döndürür.</returns>
        Task<IResult> GetInterviewsByCompanyIdAsync(Guid companyId);
        /// <summary>
        /// Aday Id sine göre mülakatları getirir
        /// </summary>
        /// <param name="candidateId">Aday Id si</param>
        /// <returns>İşlemin başarı durumunu ve gerekirse verileri içeren bir sonuç nesnesi döndürür.</returns>
        Task<IResult> GetInterviewsByCandidateIdAsync(Guid candidateId);
    }


}

