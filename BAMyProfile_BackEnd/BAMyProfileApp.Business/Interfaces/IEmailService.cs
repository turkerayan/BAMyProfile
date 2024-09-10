using BAMyProfileApp.Core.Utilities.Results;
using BAMyProfileApp.Dtos.EMailConfigs;
using BAMyProfileApp.Dtos.User;
using BAMyProfileApp.Entities.DbSets;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAMyProfileApp.Business.Interfaces
{
    public interface IEmailService
    {
        /// <summary>
        /// SMTP ayarlarını yaparak, verilen parametrelerle e-posta mesajı oluşturma ve gönderme
        /// Diğer fonksiyonların kullandığı ana mail gönderme metodudur.
        /// </summary>
        /// <param name="emailDto">Mail gönderimi işleminde mail parametrelerini tutar </param>
        /// <returns>Sonuç konteksini çıktı olarak verir.</returns>

        Task<IResult> MainEmailSenderAsync(EmailDto emailDto);

        /// <summary>
        /// Kullanıcıya aktivasyon Maili Gönderme
        /// </summary>
        /// <param name="userDto">Mail gönderilecek kişinin bilgilerini tutan Dto </param>
        /// <returns>Sonuç konteksini çıktı olarak verir.</returns>

        Task<IResult> SendActivationEmailAsync(UserDTO userDto);

        /// <summary>
        /// Kullanıcıya şifresini yenilmesi için gereken bilgilerin Mailini Gönderme
        /// </summary>
        /// <param name="email">Şifre resetlemek için gerekli hesabın bulunması için alınan mail adresi </param>
        /// <returns>Sonuç konteksini çıktı olarak verir.</returns>

        Task<IResult> SendResetPasswordInformationEmailAsync(string email);

        /// <summary>
        /// Kullanıcıya Bilgilerini İçeren Maili Gönderme
        /// </summary>
        /// <param name="userDto">Bilgilendirme Mail gönderilecek kişinin bilgilerini tutan Dto  </param>
        /// <returns>Sonuç konteksini çıktı olarak verir.</returns>

        Task<IResult> SendUserInformationEmailAsync(UserDTO userDto);

        /// <summary>
        /// Email onay linki(Url'i) oluşturma
        /// </summary>
        /// <param name="token">Mail göndermek için gereken token </param>
        /// <param name="userId">Mail gönderilecek kişinin Id  </param>
        /// <returns>Sonuç konteksini çıktı olarak verir.</returns>

        string GenerateEmailConfirmLink(string token, string userId);

        /// <summary>
        /// Kullanıcıya Hesabı Aktive Etmek İçin Gereken Mailin gövdesini oluşturma
        /// </summary>
        /// <param name="url">Mail bodysi içerisindeki link </param>
        /// <returns>Sonuç konteksini çıktı olarak verir.</returns>

        string GenerateAccountActivationEmailBody(string url);

        /// <summary>
        /// Şifre Sıfırlama İçin Url Bağlantısı Oluşturma
        /// </summary>
        /// <param name="token">Mail göndermek için gereken token </param>
        /// <param name="UserId">Mail gönderilecek kişinin Id  </param>
        /// <returns>Sonuç konteksini çıktı olarak verir.</returns>

        string GenerateResetPasswordLink(string token, string UserId);

        /// <summary>
        /// Kullancıya Şifre Yenileme Link Bilgilerini Gönderen Mailin Gövdesini Oluşturma
        /// </summary>
        /// <param name="url">Mail bodysi içerisindeki link </param>
        /// <returns>Sonuç konteksini çıktı olarak verir.</returns>

        string GenerateResetPasswordEmailBody(string url);


        /// <summary>
        /// Kullanıcının Bilgilerini İçeren Mail Gövdesini Oluşturma
        /// </summary>
        /// <param name="userEmail">Mail bodysi içerisindeki kullanıcı mail bilgisini tutan paramaetre </param>
        /// <param name="userPassword">Mail bodysi içerisindeki şifre bilgisinini tutan paramaetre </param>
        /// <returns>Sonuç konteksini çıktı olarak verir.</returns>
        string GenerateUserInformationsEmailBody(string userEmail, string userPassword);


        /// <summary>
        /// Kullanıcıya Doğrulama Maili Gönderme
        /// </summary>
        /// <param name="token">Mail aktivite için gerekli token bilgisini tutan parametre </param>
        /// <param name="userId">Mail aktivite için gerekli userId bilgisini tutan parametre </param>
        /// <returns>Sonuç konteksini çıktı olarak verir.</returns>
        Task<bool> SendConfirmEmailActivationAsync(string token, string userId);

        /// <summary>
        /// Adaya yönlendirilen iş ilanı linki oluşturma
        /// </summary>
        /// <param name="jobId"></param>
        /// <returns></returns>
        Task<string> GenerateEmailJobCandidateLink(string jobId);
        
        
        /// <summary>
        /// Adaya gönderilen Mailin Bodysini olusturma 
        /// </summary>
        /// <param name="jobId"></param>
        /// <param name="candidateId"></param>
        /// <returns></returns>
        Task<string> GenerateJobLinkBody(string jobId, string candidateId);


        /// <summary>
        /// Adaya yönlendirilmek istenilen işin maili gönderme
        /// </summary>
        /// <param name="jobId"></param>
        /// <param name="candidateId"></param>
        /// <returns></returns>
        Task<bool> SendEmailJobToCandidate(string jobId, string candidateId);
    }
}
