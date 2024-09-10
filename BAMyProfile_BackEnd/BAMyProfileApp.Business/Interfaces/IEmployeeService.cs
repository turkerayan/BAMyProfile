using BAMyProfileApp.Core.Utilities.Results;
using BAMyProfileApp.Dtos.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAMyProfileApp.Business.Interfaces
{
    public interface IEmployeeService
    {
        /// <summary>
        /// Yeni bir çalışan ekler.
        /// </summary>
        /// <param name="employeeCreateDTO">Eklenecek öğrencinin verilerini içeren DTO.</param>
        /// <returns>İşlemin başarı durumunu ve gerekirse verileri içeren bir sonuç nesnesi döndürür.</returns>
        Task<IResult> CreateAsync(EmployeeCreateDTO employeeCreateDTO);

        /// <summary>
        /// Belirtilen çalışanı günceller.
        /// </summary>
        /// <param name="employeeUpdateDTO">Güncellenecek öğrencinin verilerini içeren DTO.</param>
        /// <returns>İşlemin başarı durumunu ve gerekirse verileri içeren bir sonuç nesnesi döndürür.</returns>
        Task<IResult> UpdateAsync(EmployeeUpdateDTO employeeUpdateDTO);

        /// <summary>
        /// Belirtilen çalışanı siler.
        /// </summary>
        /// <param name="id">Silinecek öğrencinin kimliği.</param>
        /// <returns>İşlemin başarı durumunu ve gerekirse verileri içeren bir sonuç nesnesi döndürür.</returns>
        Task<IResult> DeleteAsync(Guid id);

        /// <summary>
        /// Tüm çalışanları listeler.
        /// </summary>
        /// <returns>İşlemin başarı durumunu ve gerekirse verileri içeren bir sonuç nesnesi döndürür.</returns>
        Task<IResult> GetAllAsync();

        /// <summary>
        /// Belirtilen çalışanın detaylarını getirir.
        /// </summary>
        /// <param name="id">Detayları alınacak öğrencinin kimliği.</param>
        /// <returns>İşlemin başarı durumunu ve gerekirse verileri içeren bir sonuç nesnesi döndürür.</returns>
        Task<IResult> GetByIdAsync(Guid id);
    }
}
