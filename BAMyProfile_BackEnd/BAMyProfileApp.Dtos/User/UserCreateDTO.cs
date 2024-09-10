using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAMyProfileApp.Dtos.User;

// <summary>
/// Yeni bir kullanıcı oluşturulurken kullanılan veri transfer nesnesi.
/// </summary>
public class UserCreateDTO
{
    /// <summary>
    /// Kullanıcının kullanıcı adını temsil eder.
    /// </summary>
    public string UserName { get; set; }

    /// <summary>
    /// Kullanıcının e-posta adresini temsil eder.
    /// </summary>
    public string Email { get; set; }

    /// <summary>
    /// Kullanıcının şifresini temsil eder.
    /// </summary>
    public string Password { get; set; }
}