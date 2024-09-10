using AutoMapper;
using BAMyProfileApp.Business.Constants;
using BAMyProfileApp.Business.Interfaces;
using BAMyProfileApp.Core.Utilities.Results;
using BAMyProfileApp.Dtos.EMailConfigs;
using BAMyProfileApp.Dtos.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32;
using Newtonsoft.Json.Linq;

namespace BAMyProfileApp.Business.Concretes;

/// <summary>
/// Hesap işlemlerini yapan servis
/// </summary>
public class AccountService : IAccountService
{
    private readonly UserManager<IdentityUser> _userManager;
    private readonly IMapper _mapper;
    private readonly RoleManager<IdentityRole> roleManager;
    private readonly IEmailService _emailService;
    

    public AccountService(UserManager<IdentityUser> userManager, IMapper mapper, RoleManager<IdentityRole> roleManager, IEmailService emailService = null)
    {
        _userManager = userManager;
        _mapper = mapper;
        this.roleManager = roleManager;
        _emailService = emailService;
    }
    /// <summary>
    /// Yeni bir hesap oluşturur ve belirtilen role kullanıcıyı atar.
    /// </summary>
    /// <param name="user">Eklenecek hesabın özelliklerini taşıyan sınıf</param>
    /// <param name="roleName">Kullanıcıya atanacak rol adı.</param>
    /// <returns> işlemin başarı durumunu ve eklenen hesap verilerini döner</returns>
    public async Task<IResult> CreateAsync(IdentityUser user, string roleName)
    {
        if (user.Email != null)
        {
            var hasAccount = await _userManager.FindByEmailAsync(user.Email);
            if (hasAccount != null) return new ErrorResult(Messages.AccountAlreadyExists);
        }

        var result = await _userManager.CreateAsync(user, "Password1.");
        var role = await roleManager.FindByNameAsync(roleName);



        if (!result.Succeeded) return new ErrorResult(Messages.AccountAddFail);
        var roleResult = await _userManager.AddToRoleAsync(user, role.Name);
        if (!roleResult.Succeeded) return new ErrorResult("Rol atanamadı");


        // EmailService IdentityUser yerine UserDto beklediği için mapper kullanılarak userDto ya dönüştürülür.
        var userDto = _mapper.Map<UserDTO>(user);
        
        await _emailService.SendUserInformationEmailAsync(userDto);
        await _emailService.SendActivationEmailAsync(userDto);
        return new SuccessDataResult<IdentityUser>(user, Messages.AccountAddSuccess);
    }

    /// <summary>
    /// Id si verilen hesabı siler.
    /// </summary>
    /// <param name="id">Silinecek hesabın id sini temsil eder</param>
    /// <returns>Silme işleminin başarı durumunu döner</returns>
    public async Task<IResult> DeleteAsync(string id)
    {
        var account = await _userManager.FindByIdAsync(id);
        if (account != null)
        {
            await _userManager.DeleteAsync(account);
            return new SuccessResult(Messages.AccountDeletedSuccess);
        }
        return new ErrorResult(Messages.AccountNotFound);
    }
    /// <summary>
    /// Bütün hesapları listeler
    /// </summary>
    /// <returns>Hesapları içeren bir list ve durum mesajını döner</returns>
    public async Task<IResult> GetAllAsync()
    {
        var users = await _userManager.Users.ToListAsync();
        if (users.Count <= 0) return new ErrorResult(Messages.ListHasNoAccounts);
        return new SuccessDataResult<List<IdentityUser>>(users, Messages.AccountListedSuccess);
    }
    /// <summary>
    /// Id si verilen hesabı getirir
    /// </summary>
    /// <param name="id">İstenilen hesabın id sini temsil eder</param>
    /// <returns>Hesap ve sonuç mesajını döner</returns>
    public async Task<IResult> GetByIdAsync(string id)
    {
        var user = await _userManager.FindByIdAsync(id);
        if (user == null) return new ErrorResult(Messages.AccountNotFound);
        return new SuccessDataResult<IdentityUser>(user, Messages.AccountFoundSuccess);
    }
    /// <summary>
    /// Verilen hesabı günceller
    /// </summary>
    /// <param name="user">Güncellenecek hesabı temsil eder</param>
    /// <returns>Güncellenen hesapla birlikte durum mesajını döner</returns>
    public async Task<IResult> UpdateAsync(IdentityUser user)
    {
        var result = await _userManager.UpdateAsync(user);
        if (!result.Succeeded) return new ErrorResult(Messages.AccountUpdateFail);

        return new SuccessDataResult<IdentityUser>(user, Messages.AccountUpdateSuccess);
    }
}
