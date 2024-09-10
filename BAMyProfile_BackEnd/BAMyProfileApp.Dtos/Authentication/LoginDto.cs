using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAMyProfileApp.Dtos.Authentication;

/// <summary>
/// Kullanıcı girişi sırasında kullanılan veri transfer nesnesi.
/// </summary>
public class LoginDto
{
    /// <summary>
    /// Kullanıcının e-posta adresini temsil eder.
    /// </summary>
    public string Email { get; set; }

    /// <summary>
    /// Kullanıcının şifresini temsil eder.
    /// </summary>
    public string Password { get; set; }
}