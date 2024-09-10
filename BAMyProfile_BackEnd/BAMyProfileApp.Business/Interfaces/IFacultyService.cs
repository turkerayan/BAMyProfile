using BAMyProfileApp.Core.Utilities.Results;
using BAMyProfileApp.Dtos.Faculty;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAMyProfileApp.Business.Interfaces;

/// <summary>
/// Fakülte işlemlerini gerçekleştirmek için tanımlanmış olan servis arayüzüdür.
/// </summary>
public interface IFacultyService
{
    /// <summary>
    /// Yeni bir fakülte oluşturma işlemini gerçekleştirir.
    /// </summary>
    /// <param name="facultyCreateDTO">Oluşturulacak fakülte bilgilerini taşıyan DTO.</param>
    /// <returns><see cref="IResult"/> tipinde işlem sonucunu döner.</returns>
    Task<IResult> CreateAsync(FacultyCreateDTO facultyCreateDTO);

    /// <summary>
    /// Belirtilen bir fakülteyi silme işlemini gerçekleştirir.
    /// </summary>
    /// <param name="id">Silinecek fakültenin kimlik bilgisi.</param>
    /// <returns><see cref="IResult"/> tipinde işlem sonucunu döner.</returns>
    Task<IResult> DeleteAsync(Guid id);

    /// <summary>
    /// Mevcut bir fakültenin bilgilerini güncelleme işlemini gerçekleştirir.
    /// </summary>
    /// <param name="facultyUpdateDTO">Güncellenecek fakülte bilgilerini taşıyan DTO.</param>
    /// <returns><see cref="IResult"/> tipinde işlem sonucunu döner.</returns>
    Task<IResult> UpdateAsync(FacultyUpdateDTO facultyUpdateDTO);

    /// <summary>
    /// Tüm fakülte kayıtlarını getirme işlemini gerçekleştirir.
    /// </summary>
    /// <returns><see cref="IResult"/> tipinde işlem sonucunu ve fakülte listesini döner.</returns>
    Task<IResult> GetAllAsync();

    /// <summary>
    /// Belirtilen bir fakültenin detaylı bilgilerini getirme işlemini gerçekleştirir.
    /// </summary>
    /// <param name="id">Getirilecek fakültenin kimlik bilgisi.</param>
    /// <returns><see cref="IResult"/> tipinde işlem sonucunu ve fakülte bilgilerini döner.</returns>
    Task<IResult> GetByIdAsync(Guid id);
}
