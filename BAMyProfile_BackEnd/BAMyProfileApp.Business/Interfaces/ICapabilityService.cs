using BAMyProfileApp.Core.Utilities.Results;
using BAMyProfileApp.Dtos.Capability;
using BAMyProfileApp.Dtos.Example;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAMyProfileApp.Business.Interfaces;

public interface ICapabilityService
{
    // Bir 'Capability' nesnesini veritabanında oluşturmak için asenkron bir metot.
    // 'capabilityCreateDTO' parametresi, oluşturulacak 'Capability' nesnesinin verilerini taşır.
    // Metot, işlem sonucunu belirten 'IResult' tipinde bir değer döndürür.
    Task<IResult> CreateAsync(CapabilityCreateDTO capabilityCreateDTO);
    // Belirtilen ID'ye sahip bir 'Capability' nesnesini veritabanından silmek için asenkron bir metot.
    // 'id' parametresi, silinecek 'Capability' nesnesinin benzersiz tanımlayıcısıdır (GUID).
    // Metot, işlem sonucunu belirten 'IResult' tipinde bir değer döndürür.
    Task<IResult> DeleteAsync(Guid id);
    // Bir 'Capability' nesnesinin verilerini güncellemek için asenkron bir metot.
    // 'capabilityUpdateDTO' parametresi, güncellenecek 'Capability' nesnesinin yeni verilerini taşır.
    // Metot, işlem sonucunu belirten 'IResult' tipinde bir değer döndürür.
    Task<IResult> UpdateAsync(CapabilityUpdateDTO capabilityUpdateDTO);
    // Tüm 'Capability' nesnelerini veritabanından getirmek için asenkron bir metot.
    // Metot, 'Capability' nesnelerinin bir listesini içeren 'IResult' tipinde bir değer döndürür.
    Task<IResult> GetAllAsync();
    // Belirtilen ID'ye sahip bir 'Capability' nesnesini veritabanından getirmek için asenkron bir metot.
    // 'id' parametresi, getirilecek 'Capability' nesnesinin benzersiz tanımlayıcısıdır (GUID).
    // Metot, istenen 'Capability' nesnesini içeren 'IResult' tipinde bir değer döndürür.
    Task<IResult> GetByIdAsync(Guid id);
}
