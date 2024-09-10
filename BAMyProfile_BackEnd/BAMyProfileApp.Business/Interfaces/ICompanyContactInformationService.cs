using BAMyProfileApp.Core.Utilities.Results;
using BAMyProfileApp.Dtos.Company;
using BAMyProfileApp.Dtos.CompanyContactInformation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAMyProfileApp.Business.Interfaces
{
    public interface ICompanyContactInformationService
    {
        /// <summary>
        /// Şirket iletişim bilgisi ekler.
        /// </summary>
        /// <param name="companyContactInformationCreateDTO">Şirket iletişim bilgisi ekleme dto'su.</param>
        /// <returns>Sonuç konteksini çıktı olarak verir.</returns>
        Task<IResult> CreateAsync(CompanyContactInformationCreateDTO companyContactInformationCreateDTO);

        /// <summary>
        /// Şirket iletişim bilgisi siler.
        /// </summary>
        /// <param name="id">Şirket iletişim bilgisi tanımlayıcısı.</param>
        /// <returns>Sonuç konteksini çıktı olarak verir.</returns>
        Task<IResult> DeleteAsync(Guid id);

        /// <summary>
        /// Şirket iletişim bilgisi günceller.
        /// </summary>
        /// <param name="companyContactInformationUpdateDTO">Şirket iletişim bilgisi güncelleme dto'su.</param>
        /// <returns>Sonuç konteksini çıktı olarak verir.</returns>
        Task<IResult> UpdateAsync(CompanyContactInformationUpdateDTO companyContactInformationUpdateDTO);

        /// <summary>
        /// Şirket iletişim bilgilerini verir.
        /// </summary>
        /// <returns>Sonuç konteksini çıktı olarak verir.</returns>
        Task<IResult> GetAllAsync();

        /// <summary>
        /// Şirket iletişim bilgisi verir.
        /// </summary>
        /// <param name="id">Şirket iletişim bilgisi tanımlayıcısı.</param>
        /// <returns>Sonuç konteksini çıktı olarak verir.</returns>
        Task<IResult> GetByIdAsync(Guid id);

        /// <summary>
        /// Şirket iletişim bilgilerini şirket tanımlayıcısına göre verir.
        /// </summary>
        /// <param name="companyId">Şirket bilgisi tanımlayıcısı.</param>
        /// <returns>Sonuç konteksini çıktı olarak verir.</returns>
        Task<IResult> GetAllByCompanyId(Guid companyId);
    }
}
