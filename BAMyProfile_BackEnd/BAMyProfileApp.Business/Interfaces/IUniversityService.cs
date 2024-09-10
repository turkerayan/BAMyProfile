using BAMyProfileApp.Core.Utilities.Results;
using BAMyProfileApp.Dtos.University;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAMyProfileApp.Business.Interfaces;

/// <summary>
/// Üniversite işlemlerini gerçekleştirmek için tanımlanmış olan servis arayüzüdür.
/// </summary>
public interface IUniversityService
{
    /// <summary>
    /// Yeni bir üniversite oluşturma işlemini gerçekleştirir.
    /// </summary>
    /// <param name="universityCreateDTO">Oluşturulacak üniversite bilgilerini taşıyan DTO.</param>
    /// <returns><see cref="IResult"/> tipinde işlem sonucunu döner.</returns>
    Task<IResult> CreateAsync(UniversityCreateDTO universityCreateDTO);

    /// <summary>
    /// Belirtilen bir üniversiteyi silme işlemini gerçekleştirir.
    /// </summary>
    /// <param name="id">Silinecek üniversitenin kimlik bilgisi.</param>
    /// <returns><see cref="IResult"/> tipinde işlem sonucunu döner.</returns>
    Task<IResult> DeleteAsync(Guid id);

    /// <summary>
    /// Mevcut bir üniversitenin bilgilerini güncelleme işlemini gerçekleştirir.
    /// </summary>
    /// <param name="universityUpdateDTO">Güncellenecek üniversite bilgilerini taşıyan DTO.</param>
    /// <returns><see cref="IResult"/> tipinde işlem sonucunu döner.</returns>
    Task<IResult> UpdateAsync(UniversityUpdateDTO universityUpdateDTO);

    /// <summary>
    /// Tüm üniversite kayıtlarını getirme işlemini gerçekleştirir.
    /// </summary>
    /// <returns><see cref="IResult"/> tipinde işlem sonucunu ve üniversite listesini döner.</returns>
    Task<IResult> GetAllAsync();

    /// <summary>
    /// Belirtilen bir üniversitenin detaylı bilgilerini getirme işlemini gerçekleştirir.
    /// </summary>
    /// <param name="id">Getirilecek üniversitenin kimlik bilgisi.</param>
    /// <returns><see cref="IResult"/> tipinde işlem sonucunu ve üniversite bilgilerini döner.</returns>
    Task<IResult> GetByIdAsync(Guid id);
}

