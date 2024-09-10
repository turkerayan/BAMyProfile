using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAMyProfileApp.Business.Concretes;

/// <summary>
/// JWT token imzalama işlemlerini sağlayan yardımcı sınıf.
/// </summary>
public static class SignService
{
    /// <summary>
    /// Belirtilen anahtar bilgisine göre bir simetrik güvenlik anahtarı oluşturur.
    /// </summary>
    /// <param name="securityKey">Oluşturulacak güvenlik anahtarının değeri.</param>
    /// <returns>Oluşturulan simetrik güvenlik anahtarını temsil eden SecurityKey nesnesi.</returns>
    public static SecurityKey GetSymmetricSecurityKey(string securityKey)
    {
        if (string.IsNullOrEmpty(securityKey))
            throw new ArgumentException("Security key cannot be null or empty.", nameof(securityKey));
        return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKey));
    }
}

