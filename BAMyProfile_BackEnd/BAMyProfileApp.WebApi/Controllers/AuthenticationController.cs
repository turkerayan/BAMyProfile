using BAMyProfileApp.Business.Interfaces;
using BAMyProfileApp.Dtos.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BAMyProfileApp.WebApi.Controllers;

/// <summary>
/// Kimlik doğrulama ve token oluşturma işlemlerini gerçekleştiren API kontrolcüsü.
/// </summary>
[Route("api/[controller]/[action]")]
[ApiController]
public class AuthenticationController : ControllerBase
{

    private readonly IAuthenticationService authenticationService;

    /// <summary>
    /// AuthController sınıfının yeni bir örneğini başlatır.
    /// </summary>
    /// <param name="authenticationService">Kimlik doğrulama servisi.</param>
    public AuthenticationController(IAuthenticationService authenticationService)
    {
        this.authenticationService = authenticationService ?? throw new ArgumentNullException(nameof(authenticationService));
    }

    /// <summary>
    /// Belirtilen kullanıcı bilgileriyle JWT token oluşturan HTTP POST isteği.
    /// </summary>
    /// <param name="loginDto">Kullanıcı giriş bilgilerini içeren LoginDto nesnesi.</param>
    /// <returns>Token oluşturma işleminin sonucuna göre IActionResult.</returns>
    [HttpPost]
    public async Task<IActionResult> Login(LoginDto loginDto)
    {
        // Kullanıcıdan alınan giriş bilgileriyle JWT token oluşturulur.
        var result = await authenticationService.LoginAsync(loginDto);
        // Token oluşturma işlemi başarılı ise 200 OK, aksi halde 400 Bad Request döner.
        return result.IsSuccess ? Ok(result) : BadRequest(result);

    }
    /// <summary>
    /// Kullanıcıyı sistemden çıkış yapmaya yönlendirir.
    /// </summary>
    /// <returns>
    /// HTTP 200 (OK) durum kodu ile birlikte başarı mesajını döndürürse, başarılı çıkış işlemini temsil eder.
    /// Aksi takdirde, HTTP 400 (Bad Request) durum kodu ile birlikte hata mesajını döndürür.
    /// </returns>
    [HttpPost]
    public async Task<IActionResult> LogOut()
    {
        // Kullanıcı oturumunu sonlandırmak için authenticationService.LogoutAsync() metodu çağrılır.
        var result = await authenticationService.LogoutAsync();
      
        return result.IsSuccess ? Ok(result) : BadRequest(result);

    }
}

