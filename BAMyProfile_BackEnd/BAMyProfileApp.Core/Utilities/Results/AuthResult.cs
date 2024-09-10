using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAMyProfileApp.Core.Utilities.Results;


/// <summary>
/// Kimlik doğrulama sonuçlarını temsil eden genel sınıf.
/// </summary>
/// <typeparam name="TResult">Kimlik doğrulama işlemi sonucunda elde edilen veri tipi.</typeparam>
public class AuthResult<TResult> : Result
{
    /// <summary>
    /// Kimlik doğrulama işlemi sonucunda elde edilen veriyi temsil eder.
    /// </summary>
    public TResult Result { get; set; }

    /// <summary>
    /// Belirtilen veri, başarı durumu ve mesaj ile AuthResult<TResult> sınıfının yeni bir örneğini başlatır.
    /// </summary>
    /// <param name="result">Kimlik doğrulama işlemi sonucunda elde edilen veri.</param>
    /// <param name="isSuccess">Kimlik doğrulama işleminin başarılı olup olmadığını belirten değer.</param>
    /// <param name="message">Kimlik doğrulama işlemi sonucunda oluşan mesaj.</param>
    public AuthResult(TResult result, bool isSuccess, string message) : base(isSuccess, message)
    {
        Result = result;
    }

    /// <summary>
    /// Belirtilen veri ve başarı durumu ile AuthResult<TResult> sınıfının yeni bir örneğini başlatır.
    /// </summary>
    /// <param name="result">Kimlik doğrulama işlemi sonucunda elde edilen veri.</param>
    /// <param name="isSuccess">Kimlik doğrulama işleminin başarılı olup olmadığını belirten değer.</param>
    public AuthResult(TResult result, bool isSuccess) : base(isSuccess)
    {
        Result = result;
    }
}
