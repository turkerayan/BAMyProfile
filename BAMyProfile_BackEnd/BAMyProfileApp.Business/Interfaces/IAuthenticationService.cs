using BAMyProfileApp.Core.Utilities.Results;
using BAMyProfileApp.Dtos.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAMyProfileApp.Business.Interfaces;
/// <summary>
/// Kimlik doğrulama işlemlerini yöneten arayüz.
/// </summary>
public interface IAuthenticationService
{/// <summary>
 /// Belirtilen kullanıcı bilgileriyle bir kimlik doğrulama token'ı oluşturur.
 /// </summary>
 /// <param name="request">Kimlik doğrulama için kullanıcı bilgilerini içeren LoginDto nesnesi.</param>
 /// <returns>Kimlik doğrulama işlemi sonucunu temsil eden bir Task<IResult>.</returns>
    Task<IResult> LoginAsync(LoginDto request);
    /// <summary>
    /// Kullanıcının oturumunu sonlandırmak için gerekli işlemleri gerçekleştirir.
    /// </summary>
    /// <returns>Oturum sonlandırma işleminin sonucunu temsil eden bir Task.</returns>
    Task<IResult> LogoutAsync();


}