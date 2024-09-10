using BAMyProfileApp.Business.Interfaces;
using BAMyProfileApp.Core.Utilities.Results;
using BAMyProfileApp.Dtos.Configuration;

using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BAMyProfileApp.Business.Concretes;

/// <summary>
/// Kimlik kullanıcıları için JWT token oluşturma işlemlerini yöneten servis sınıfı.
/// </summary>
public class JWTService : IJWTService
{

    private readonly UserManager<IdentityUser> userManager;
    private readonly JWTOption jwtOption;
    /// <summary>
    /// TokenService sınıfının yeni bir örneğini başlatır.
    /// </summary>
    /// <param name="userManager">Kullanıcı yönetimini sağlayan UserManager nesnesi.</param>
    /// <param name="options">Token ayarlarını içeren IOptions<CustomTokenOption> nesnesi.</param>
    public JWTService(UserManager<IdentityUser> userManager, IOptions<JWTOption> options)
    {
        this.userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
        this.jwtOption = options?.Value ?? throw new ArgumentNullException(nameof(options));
    }
    /// <summary>
    /// Belirtilen kullanıcı ve hedef kitle bilgilerine göre JWT token'ında kullanılacak talepleri oluşturan yardımcı metot.
    /// </summary>
    /// <param name="user">Token talepleri oluşturulacak kullanıcıyı temsil eden IdentityUser nesnesi.</param>
    /// <param name="audiences">Token'ın geçerli olduğu hedef kitlelerin listesi.</param>
    /// <returns>Oluşturulan talepleri temsil eden bir Task<IEnumerable<Claim>>.</returns>
    private async Task<IEnumerable<Claim>> GetClaims(IdentityUser user, List<string> audiences)
    {    //Userın rollerini de claim olarak eklemek için user managerla rolleri çekiyoruz.
        var userRoles = await userManager.GetRolesAsync(user);

        // Kullanıcıya ait temel claimleri oluşturur.
        var userList = new List<Claim>
        { // Kullanıcının benzersiz kimliği.
            new Claim(ClaimTypes.NameIdentifier,user.Id),
            // Kullanıcının e-posta adresi.
            new Claim(JwtRegisteredClaimNames.Email,user.Email),
            // Kullanıcının kullanıcı adı.
            new Claim(ClaimTypes.Name,user.UserName),
            // JWT token'ın benzersiz kimliği.
            new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString())

        };

        userList.AddRange(audiences.Select(x => new Claim(JwtRegisteredClaimNames.Aud, x)));//Burada hangi serverlara istek yapıp yapamayacağımızı kontrol ettiğimiz yerdeyiz.Her token oluştuğunda audience alanı açar ve içerisine tanımlı audienceleri yükler.
        userList.AddRange(userRoles.Select(x => new Claim(ClaimTypes.Role, x)));// userRolesde gelen veriler stirng değerler bunların hepsini select ile dönüp değerlerini bir claim tipi olarak ekliyoruz rolleri.


        return userList;
    }
    /// <summary>
    /// Belirtilen kullanıcı için bir JWT token oluşturur.
    /// </summary>
    /// <param name="user">Token oluşturulacak kullanıcıyı temsil eden IdentityUser nesnesi.</param>
    /// <returns>Oluşturulan JWT token'ını temsil eden TokenDTO nesnesi.</returns>

    public async Task<string> CreateToken(IdentityUser user)
    {
        DateTime notBefore = DateTime.UtcNow;
        DateTime jwtExpiration = notBefore.AddMinutes(45); // 2 dakika geçerli
        var securityKey = SignService.GetSymmetricSecurityKey(jwtOption.SecurityKey);
        SigningCredentials signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        JwtSecurityToken jwtSecurityToken = new JwtSecurityToken
        (
            issuer: jwtOption.Issuer,
            notBefore: notBefore,
            expires: jwtExpiration,
            claims: GetClaims(user, jwtOption.Audience).Result,
            signingCredentials: signingCredentials
        );

        return new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
    }


    /// <summary>
    /// Token'ı geçersiz kılmak için son kullanma zamanı belirterek bir işlem gerçekleştirir.
    /// </summary>
    /// <returns>Oluşturulan token'ın string temsili.</returns>
    public async Task<string> RevokeTokenWithExpiretime()
    {
        // SecurityKey'i elde etmek için belirli bir güvenlik anahtarı kullanılır, bu anahtar appsettings.json dosyasından alınır ve bir keye çevrilir.
        var securityKey = SignService.GetSymmetricSecurityKey(jwtOption.SecurityKey);

        // Güvenlik anahtarını ve algoritmayı kullanarak bir imza oluşturulur.
        SigningCredentials signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        // Token oluşturulur.
        JwtSecurityToken jwtSecurityToken = new JwtSecurityToken
        (
            issuer: jwtOption.Issuer, // tokenın yayıncısı
            expires: DateTime.UtcNow.AddMinutes(-1), // tokenın geçerlilik süresi (şu anki tarihten 1 dakika önce)
            signingCredentials: signingCredentials // tokenı imzalamak için kullanılacak bilgiler
        );

        // Oluşturulan JWT tokenı string formatına dönüştürülür ve geri döndürülür.
        return new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
    }



}