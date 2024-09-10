using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAMyProfileApp.Dtos.User;

/// <summary>
/// Kullanıcı bilgilerini taşıyan veri transfer nesnesi.
/// </summary>
public class UserDTO
{
    /// <summary>
    /// Kullanıcının benzersiz kimliğini temsil eder.
    /// </summary>
    public string Id { get; set; }

    /// <summary>
    /// Kullanıcının e-posta adresini temsil eder.
    /// </summary>
    public string Email { get; set; }

    /// <summary>
    /// Kullanıcının kullanıcı adını temsil eder.
    /// </summary>
    public string UserName { get; set; }
}