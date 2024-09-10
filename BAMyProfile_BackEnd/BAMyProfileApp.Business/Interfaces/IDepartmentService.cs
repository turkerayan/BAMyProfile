using BAMyProfileApp.Core.Utilities.Results;
using BAMyProfileApp.Dtos.Department;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAMyProfileApp.Business.Interfaces;

/// <summary>
/// Bölüm işlemlerini gerçekleştirmek için tanımlanmış olan servis arayüzüdür.
/// </summary>
public interface IDepartmentService
{
    /// <summary>
    /// Yeni bir bölüm oluşturma işlemini gerçekleştirir.
    /// </summary>
    /// <param name="departmentCreateDTO">Oluşturulacak bölüm bilgilerini taşıyan DTO.</param>
    /// <returns><see cref="IResult"/> tipinde işlem sonucunu döner.</returns>
    Task<IResult> CreateAsync(DepartmentCreateDTO departmentCreateDTO);

    /// <summary>
    /// Belirtilen bir bölümü silme işlemini gerçekleştirir.
    /// </summary>
    /// <param name="id">Silinecek bölümün kimlik bilgisi.</param>
    /// <returns><see cref="IResult"/> tipinde işlem sonucunu döner.</returns>
    Task<IResult> DeleteAsync(Guid id);

    /// <summary>
    /// Mevcut bir bölümün bilgilerini güncelleme işlemini gerçekleştirir.
    /// </summary>
    /// <param name="departmentUpdateDTO">Güncellenecek bölüm bilgilerini taşıyan DTO.</param>
    /// <returns><see cref="IResult"/> tipinde işlem sonucunu döner.</returns>
    Task<IResult> UpdateAsync(DepartmentUpdateDTO departmentUpdateDTO);

    /// <summary>
    /// Tüm bölüm kayıtlarını getirme işlemini gerçekleştirir.
    /// </summary>
    /// <returns><see cref="IResult"/> tipinde işlem sonucunu ve bölüm listesini döner.</returns>
    Task<IResult> GetAllAsync();

    /// <summary>
    /// Belirtilen bir bölümün detaylı bilgilerini getirme işlemini gerçekleştirir.
    /// </summary>
    /// <param name="id">Getirilecek bölümün kimlik bilgisi.</param>
    /// <returns><see cref="IResult"/> tipinde işlem sonucunu ve bölüm bilgilerini döner.</returns>
    Task<IResult> GetByIdAsync(Guid id);
}
