using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAMyProfileApp.Dtos.Configuration;

/// <summary>
/// JWT token'larının özelliklerini ve ayarlarını içeren sınıf.
/// </summary>
public class JWTOption
{
    /// <summary>
    /// Token'ın geçerli olduğu hedef kitlelerin listesini temsil eder.
    /// </summary>
    public List<string> Audience { get; set; }

    /// <summary>
    /// Token'ın yayıncısını (issuer) temsil eder.
    /// </summary>
    public string Issuer { get; set; }

    /// <summary>
    /// Token'ın geçerlilik süresini dakika cinsinden temsil eder.
    /// </summary>
    public int JWTExpiration { get; set; }

    /// <summary>
    /// JWT token'ı için kullanılan güvenlik anahtarını temsil eder.
    /// </summary>
    public string SecurityKey { get; set; }
}
