using BAMyProfileApp.Business.Constants;
using BAMyProfileApp.Business.Interfaces;

using BAMyProfileApp.Core.Utilities.Results;
using BAMyProfileApp.Dtos.Authentication;

using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAMyProfileApp.Business.Concretes;
// <summary>
/// Kimlik doğrulama işlemlerini yöneten sınıf.
/// </summary>
public class AuthenticationService : IAuthenticationService
{
    private readonly IJWTService tokenService;
    private readonly UserManager<IdentityUser> userManager;// Kullanıcının varlığını kontrol etmek için kullanılır.
 


    public AuthenticationService(IJWTService tokenService, UserManager<IdentityUser> userManager)
    {
        this.tokenService = tokenService ?? throw new ArgumentNullException(nameof(tokenService));
        this.userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
       
     
    }
    /// <summary>
    /// Belirtilen kullanıcı kimlik bilgileriyle bir kimlik doğrulama token'ı oluşturur.
    /// </summary>
    /// <param name="request">Kimlik doğrulama için kullanıcı bilgilerini içeren LoginDto nesnesi.</param>
    /// <returns>Kimlik doğrulama işlemi sonucunu temsil eden bir Task<IResult>.</returns>
    public async Task<IResult> LoginAsync(LoginDto request)
    {
     
        if (request == null) throw new ArgumentNullException(nameof(request));
       
        IdentityUser? user = await userManager.FindByEmailAsync(request.Email);
        if (user == null) return new ErrorResult(Messages.UserNotFound);
        if (!await userManager.CheckPasswordAsync(user, request.Password))
            return new ErrorResult(Messages.CreateTokenFail);
        string token = tokenService.CreateToken(user).Result;

        return new SuccessDataResult<string>(token, GetRoleNames(user,userManager).Result);
    }

    /// <summary>
    /// Kullanıcının oturumunu sonlandırmak için gerekli işlemleri gerçekleştirir.
    /// </summary>
    /// <returns>Oturum sonlandırma işleminin sonucunu temsil eden bir Task.</returns>
    public async Task<IResult> LogoutAsync()
    {
        // Token'ı geçersiz kılmak için özel bir metodu çağırır.
        var token = await tokenService.RevokeTokenWithExpiretime();

        // Eğer token başarıyla geçersiz kılındıysa, başarılı sonuç döndürülür.
        if (token == null)
            return new ErrorResult(Messages.RevokeTokenFail); // Token geçersiz kılma işlemi başarısız olduğunda hata sonucu döndürülür.

        // Token başarıyla geçersiz kılındıysa, başarılı sonuç döndürülür ve geçersiz kılınan token verisiyle birlikte döndürülür.
        return new SuccessDataResult<string>(token, Messages.RevokeTokenSuccess);
    }
    /// <summary>
    /// Kullanıcının rollerini alarak bir hoşgeldin mesajı oluşturur.
    /// </summary>
    /// <param name="user">Rolleri alınacak olan kullanıcı.</param>
    /// <param name="userManager">Kullanıcı yöneticisi nesnesi.</param>
    /// <returns>Oluşturulan hoşgeldin mesajı.</returns>
    private async Task<string> GetRoleNames(IdentityUser user, UserManager<IdentityUser> userManager)
    {
        // Kullanıcının rollerini almak için kullanıcı yöneticisinden rolleri getirir.
        var userRoles = (List<string>)(await userManager.GetRolesAsync(user));
       
        // Roller için boş bir dize oluşturulur.
        string roleName = string.Empty;

        // Her bir rol için döngü yapılır ve roller roleName değişkenine eklenir.
        foreach (string role in userRoles)
        {
            roleName += role + " ";
        }

        //// Hoşgeldin mesajı oluşturulur ve roller ile birlikte döndürülür.
        //return Messages.LoginWelcome + " " + roleName + " " + Messages.CreateTokenSuccess;

        // Hoşgeldin mesajı oluşturulucak ve ekrana direk olarak verilecek. 
        return Messages.LoginWelcome;
    }


}
