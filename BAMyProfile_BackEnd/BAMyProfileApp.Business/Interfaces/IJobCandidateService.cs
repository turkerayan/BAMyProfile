using BAMyProfileApp.Core.Utilities.Results;
using BAMyProfileApp.Dtos.JobBenefit;
using BAMyProfileApp.Dtos.JobCandidate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAMyProfileApp.Business.Interfaces
{
    public interface IJobCandidateService
    {
        /// <summary>
        /// Bir iş ilanına yeni bir aday ekler
        /// </summary>
        /// <param name="jobCandidateCreateDTO">Aday eklenecek ilanına ve adaya ait bilgileri içerir </param>
        /// <returns>İşlemin başarı durumunu ve verileri döner</returns>
        Task<IResult> CreateAsync(JobCandidateCreateDTO jobCandidateCreateDTO);

        /// <summary>
        /// Bir iş ilanına eklenmiş bir adayı siler
        /// </summary>
        /// <param name="id">İş ilanı için eklenmiş adayın id si</param>
        /// <returns>İşlemin başarı durumunu ve verileri döner</returns>
        Task<IResult> DeleteAsync(Guid id);

        /// <summary>
        /// Bir iş ilanına eklenmiş adayı günceller
        /// </summary>
        /// <param name="jobCandidateUpdateDTO">İş ilanına eklenmiş adayı güncellemek için gerekli bilgileri içerir</param>
        /// <returns>İşlemin başarı durumunu ve verileri döner</returns>
        Task<IResult> UpdateAsync(JobCandidateUpdateDTO jobCandidateUpdateDTO);

        /// <summary>
        /// Tüm iş ilanlarında yer alan tüm adayları listeler.
        /// </summary>
        /// <returns>İşlemin başarı durumunu ve gerekirse verileri içeren bir sonuç nesnesi döndürür.</returns>
        Task<IResult> GetAllAsync();

        /// <summary>
        /// Id ye göre bir iş ilanına eklenmiş adaya ait detayları getirir
        /// </summary>
        /// <param name="id">Detayları getirilecek iş ilanına eklenmiş adaya ait id</param>
        /// <returns>İşlemin başarı durumunu ve veriyi döner</returns>
        Task<IResult> GetByIdAsync(Guid id);
    }
}
