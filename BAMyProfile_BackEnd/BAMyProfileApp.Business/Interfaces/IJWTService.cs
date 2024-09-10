
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAMyProfileApp.Business.Interfaces;
/// <summary>
/// İzinli kullanıcıları için token oluşturma işlemlerini yöneten arayüz.
/// </summary>
public interface IJWTService
{
    /// <summary>
    /// Belirtilen kullanıcı için bir kimlik doğrulama token'ı oluşturur.
    /// </summary>
    /// <param name="user">Token oluşturulacak kullanıcıyı temsil eden IdentityUser nesnesi.</param>
    /// <returns>Oluşturulan kimlik doğrulama token'ını temsil eden TokenDTO nesnesi.</returns>
    Task<string> CreateToken(IdentityUser user);
    /// <summary>
    /// Token'ı geçersiz kılmak için son kullanma zamanını belirterek bir işlem gerçekleştirir.
    /// </summary>
    /// <returns>Oluşturulan token'ın string temsili.</returns>
    Task<string> RevokeTokenWithExpiretime();

}