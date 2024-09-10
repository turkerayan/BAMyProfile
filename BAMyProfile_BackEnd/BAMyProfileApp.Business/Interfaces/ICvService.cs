using BAMyProfileApp.Core.Utilities.Results;
using BAMyProfileApp.Dtos.Cv;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAMyProfileApp.Business.Interfaces;

public interface ICvService
{
    /// <summary>
    /// Yeni bir özgeçmiş oluşturur.
    /// </summary>
    /// <param name="cvCreateDTO">Oluşturulacak özgeçmişin bilgilerini içeren DTO</param>
    /// <returns>Operasyon sonucunu temsil eden IResult nesnesi</returns>
    Task<IResult> CreateAsync(CvCreateDTO cvCreateDTO);
    /// <summary>
    /// Belirtilen kimliğe sahip özgeçmişi siler.
    /// </summary>
    /// <param name="id">Silinecek özgeçmişin kimliği</param>
    /// <returns>Operasyon sonucunu temsil eden IResult nesnesi</returns>
    Task<IResult> DeleteAsync(Guid id);
    /// <summary>
    /// Özgeçmişi günceller.
    /// </summary>
    /// <param name="cvUpdateDTO">Güncellenecek özgeçmişin bilgilerini içeren DTO</param>
    /// <returns>Operasyon sonucunu temsil eden IResult nesnesi</returns>
    Task<IResult> UpdateAsync(CvUpdateDTO cvUpdateDTO);
    /// <summary>
    /// Tüm özgeçmişleri getirir.
    /// </summary>
    /// <returns>Operasyon sonucunu temsil eden IResult nesnesi</returns>
    Task<IResult> GetAllAsync();
    /// <summary>
    /// Belirtilen kimliğe sahip özgeçmişi getirir.
    /// </summary>
    /// <param name="id">Getirilecek özgeçmişin kimliği</param>
    /// <returns>Operasyon sonucunu temsil eden IResult nesnesi</returns>
    Task<IResult> GetByIdAsync(Guid id);
    /// <summary>
    /// Belirtilen e-posta adresine sahip kullanıcının özgeçmişlerini getirir.
    /// </summary>
    /// <param name="emailAddress">Getirilecek özgeçmişlerin sahip olduğu kullanıcının e-posta adresi</param>
    /// <returns>Operasyon sonucunu temsil eden IResult nesnesi</returns>
    Task<IResult> GetCvsByEmailAsync(string emailAddress); 
}
