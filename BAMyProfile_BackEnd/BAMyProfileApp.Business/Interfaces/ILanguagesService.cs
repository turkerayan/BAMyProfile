using BAMyProfileApp.Core.Utilities.Results;
using BAMyProfileApp.Dtos.Capability;
using BAMyProfileApp.Dtos.Languages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAMyProfileApp.Business.Interfaces;

public interface ILanguagesService
{
    // 'Languages' nesnesini veritabanında oluşturmak için asenkron bir metot.
    // 'languagesCreateDTO' parametresi, oluşturulacak 'Languages' nesnesinin verilerini taşır.
    // Metot, işlem sonucunu belirten 'IResult' tipinde bir değer döndürür.
    Task<IResult> CreateAsync(LanguagesCreateDTO languagesCreateDTO);

    // Belirtilen ID'ye sahip bir 'Languages' nesnesini veritabanından silmek için asenkron bir metot.
    // 'id' parametresi, silinecek 'Languages' nesnesinin benzersiz tanımlayıcısıdır (GUID).
    // Metot, işlem sonucunu belirten 'IResult' tipinde bir değer döndürür.
    Task<IResult> DeleteAsync(Guid id);

    // Bir 'Languages' nesnesinin verilerini güncellemek için asenkron bir metot.
    // 'languagesUpdateDTO' parametresi, güncellenecek 'Languages' nesnesinin yeni verilerini taşır.
    // Metot, işlem sonucunu belirten 'IResult' tipinde bir değer döndürür.
    Task<IResult> UpdateAsync(LanguagesUpdateDTO languagesUpdateDTO);

    // Tüm 'Languages' nesnelerini veritabanından getirmek için asenkron bir metot.
    // Metot, 'Languages' nesnelerinin bir listesini içeren 'IResult' tipinde bir değer döndürür.
    Task<IResult> GetAllAsync();

    // Belirtilen ID'ye sahip bir 'Languages' nesnesini veritabanından getirmek için asenkron bir metot.
    // 'id' parametresi, getirilecek 'Languages' nesnesinin benzersiz tanımlayıcısıdır (GUID).
    // Metot, istenen 'Languages' nesnesini içeren 'IResult' tipinde bir değer döndürür.
    Task<IResult> GetByIdAsync(Guid id);

}
