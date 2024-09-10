using BAMyProfileApp.Core.Utilities.Results;
using BAMyProfileApp.Dtos.Certificate;
using BAMyProfileApp.Dtos.Company;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAMyProfileApp.Business.Interfaces
{
    public interface ICompanyService
    {
        /// <summary>
        /// Şirket ekler.
        /// </summary>
        /// <param name="companyCreateDTO">Şirket ekleme dto'su.</param>
        /// <returns>Sonuç konteksini çıktı olarak verir.</returns>
        Task<IResult> CreateAsync(CompanyCreateDTO companyCreateDTO);

        /// <summary>
        /// Şirket siler.
        /// </summary>
        /// <param name="id">Şirket tanımlayıcısı.</param>
        /// <returns>Sonuç konteksini çıktı olarak verir.</returns>
        Task<IResult> DeleteAsync(Guid id);

        /// <summary>
        /// Şirket günceller.
        /// </summary>
        /// <param name="companyUpdateDTO">Şirket güncelleme dto'su.</param>
        /// <returns>Sonuç konteksini çıktı olarak verir.</returns>
        Task<IResult> UpdateAsync(CompanyUpdateDTO companyUpdateDTO);

        /// <summary>
        /// Şirketleri verir.
        /// </summary>
        /// <returns>Sonuç konteksini çıktı olarak verir.</returns>
        Task<IResult> GetAllAsync();

        /// <summary>
        /// Şirket verir.
        /// </summary>
        /// <param name="id">Şirket tanımlayıcısı.</param>
        /// <returns>Sonuç konteksini çıktı olarak verir.</returns>
        Task<IResult> GetByIdAsync(Guid id);
    }
}
