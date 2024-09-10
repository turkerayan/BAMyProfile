using BAMyProfileApp.Core.Utilities.Results;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAMyProfileApp.Business.Interfaces;

public interface IAccountService
{
    /// <summary>
    /// Yeni bir hesap ekler ve belirtilen role kullanıcıyı atar.
    /// </summary>
    /// <param name="user">Yeni hesap bilgilerini içerir </param>
    /// <param name="roleName">Kullanıcıya atanacak rol adı.</param>
    /// <returns>İşlemin başarı durumunu ve verileri döner</returns>
    Task<IResult> CreateAsync(IdentityUser user, string roleName);

    /// <summary>
    /// Bir hesabı siler
    /// </summary>
    /// <param name="id">Silinecek hesaba ait id</param>
    /// <returns>İşlemin başarı durumunu ve verileri döner</returns>
    Task<IResult> DeleteAsync(string id);

    /// <summary>
    /// Bir hesabı günceller
    /// </summary>
    /// <param name="user">Güncellenecek hesaba ait bilgileri içerir</param>
    /// <returns>İşlemin başarı durumunu ve verileri döner</returns>
    Task<IResult> UpdateAsync(IdentityUser user);

    /// <summary>
    /// Tüm hesapları listeler.
    /// </summary>
    /// <returns>İşlemin başarı durumunu ve gerekirse verileri içeren bir sonuç nesnesi döndürür.</returns>
    Task<IResult> GetAllAsync();

    /// <summary>
    /// Id ye göre hesap detaylarını getirir
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<IResult> GetByIdAsync(string id);
}
