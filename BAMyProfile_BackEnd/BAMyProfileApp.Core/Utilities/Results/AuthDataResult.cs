using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAMyProfileApp.Core.Utilities.Results;


/// <summary>
/// Kimlik doğrulama işlemi sonucunda, belirtilen veri tipiyle birlikte veri döndüren sınıf.
/// </summary>
/// <typeparam name="TResult">Kimlik doğrulama işlemi sonucunda elde edilen veri tipi.</typeparam>
/// <typeparam name="T">Döndürülecek verinin tipi.</typeparam>
public class AuthDataResult<TResult, T> : AuthResult<TResult>, IDataResult<T>
{
    /// <summary>
    /// Döndürülecek veriyi temsil eder.
    /// </summary>
    public T? Data { get; }

    /// <summary>
    /// Belirtilen veri, kimlik doğrulama işlemi sonucunda elde edilen veri ve başarı durumu ile AuthDataResult<TResult, T> sınıfının yeni bir örneğini başlatır.
    /// </summary>
    /// <param name="result">Kimlik doğrulama işlemi sonucunda elde edilen veri.</param>
    /// <param name="data">Döndürülecek veri.</param>
    /// <param name="isSuccess">Kimlik doğrulama işleminin başarılı olup olmadığını belirten değer.</param>
    public AuthDataResult(TResult result, T? data, bool isSuccess) : base(result, isSuccess)
    {
        Data = data;
    }

    /// <summary>
    /// Belirtilen veri, kimlik doğrulama işlemi sonucunda elde edilen veri, başarı durumu ve mesaj ile AuthDataResult<TResult, T> sınıfının yeni bir örneğini başlatır.
    /// </summary>
    /// <param name="result">Kimlik doğrulama işlemi sonucunda elde edilen veri.</param>
    /// <param name="data">Döndürülecek veri.</param>
    /// <param name="isSuccess">Kimlik doğrulama işleminin başarılı olup olmadığını belirten değer.</param>
    /// <param name="message">Kimlik doğrulama işlemi sonucunda oluşan mesaj.</param>
    public AuthDataResult(TResult result, T? data, bool isSuccess, string message) : base(result, isSuccess, message)
    {
        Data = data;
    }
}

