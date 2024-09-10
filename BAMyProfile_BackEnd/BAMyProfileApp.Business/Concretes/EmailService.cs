using AutoMapper;
using BAMyProfileApp.Business.Constants;
using BAMyProfileApp.Business.Interfaces;
using BAMyProfileApp.Business.Resources;
using BAMyProfileApp.Core.Utilities.Results;
using BAMyProfileApp.DataAccess.Interfaces.Repositories;
using BAMyProfileApp.Dtos.EMailConfigs;
using BAMyProfileApp.Dtos.Employee;
using BAMyProfileApp.Dtos.User;
using BAMyProfileApp.Entities.DbSets;
using Hangfire;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Options;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace BAMyProfileApp.Business.Concretes
{
    public class EmailService : IEmailService
    {
        private readonly EmailOption _option;
        private readonly IStringLocalizer<MessageResources> _localizer;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IUrlHelperFactory _urlHelperFactory;
        private readonly IActionContextAccessor _actionContextAccessor;
        private readonly IMapper _mapper;
        private readonly IBackgroundJobClient _backGroundJobsClient;
        private readonly IJobRepository _jobRepo;
        private readonly ICandidateRepository _candidateRepo;



        public EmailService(IOptions<EmailOption> option, IMapper mapper, IStringLocalizer<MessageResources> localizer, IUrlHelperFactory urlHelperFactory, IActionContextAccessor actionContextAccessor, UserManager<IdentityUser> userManager, IBackgroundJobClient backgroundJob, IJobRepository jobRepo, ICandidateRepository candidateRepo)
        {
            _option = option.Value;
            _localizer = localizer;
            _urlHelperFactory = urlHelperFactory;
            _actionContextAccessor = actionContextAccessor;
            _userManager = userManager;
            _mapper = mapper;
            _backGroundJobsClient = backgroundJob;
    
            _jobRepo = jobRepo;
            _candidateRepo = candidateRepo;
        }

        /// <summary>
        /// SMTP ayarlarını yaparak, verilen parametrelerle e-posta mesajı oluşturma ve gönderme
        /// Diğer fonksiyonların kullandığı ana mail gönderme metodudur.
        /// </summary>
        /// <param name="emailDto">Mail gönderimi işleminde mail parametrelerini tutar </param>
        /// <returns>Sonuç konteksini çıktı olarak verir.</returns>
        public async Task<IResult> MainEmailSenderAsync(EmailDto emailDto)
        {
            Result result = new ErrorResult();
            try
            {
                var smtpClient = new SmtpClient();  // SmtpClient sınıfından yeni bir örnek oluşturulur.
                smtpClient.EnableSsl = true; //EnableSsl özelliği true olarak ayarlanır. Bu, SMTP istemcinin SSL/TLS bağlantısını etkinleştirdiği anlamına gelir ve iletişim şifrelenir.
                smtpClient.DeliveryMethod = smtpClient.DeliveryMethod;
                smtpClient.UseDefaultCredentials = false; // UseDefaultCredentials özelliği false olarak ayarlanır. Bu, istemcinin varsayılan kimlik bilgilerini kullanmamasını belirtir.
                smtpClient.Host = _option.ServiceEmailOption.Host; // Host önceki adımlarda yapılandırmada belirtilen SMTP sunucu adresi ayarlanır.
                smtpClient.Port = _option.ServiceEmailOption.Port; // Port önceki adımlarda yapılandırmada belirtilen SMTP port numarası ile ayarlanır.
                smtpClient.Credentials = new NetworkCredential(_option.ServiceEmailOption.Email, _option.ServiceEmailOption.Password); // Credentials özelliği, SMTP sunucusuna bağlanmak için kullanılacak kimlik bilgilerini belirtir. Bu bilgiler, önceki adımlarda yapılandırmada belirtilen e-posta adresi ve şifreyle oluşturulmuş bir NetworkCredential nesnesi olarak atanır.

                var mailMessage = new MailMessage(); // MailMessage sınıfından yeni bir örnek oluşturulur. Bu, gönderilecek e-posta mesajını temsil eder.
                mailMessage.From = new MailAddress(_option.ServiceEmailOption.Email); // From özelliği, e-postanın gönderici adresini belirtir. Bu, önceki adımlarda yapılandırmada belirtilen e-posta adresi olarak atanır.
                mailMessage.To.Add(emailDto.ReciverEmailAddress); // To özelliği, e-postanın alıcı adresini ekler.
                mailMessage.Subject = emailDto.Subject; // Subject özelliği, e-posta konusunu belirtir.
                mailMessage.Body = emailDto.MailBody; // Body özelliği, e-posta gövdesini belirtir.
                mailMessage.IsBodyHtml = true; // IsBodyHtml özelliği, e-posta gövdesinin HTML içerip içermediğini belirtir.


                smtpClient.Send(mailMessage); // SmtpClient üzerinden Send metodu çağrılarak e-posta gönderilir.
                result = new SuccessResult(_localizer[Messages.MailSendSuccess]);
            }
            catch (Exception ex)
            {
                result = new ErrorResult(_localizer[Messages.MailSendFail]);
            }
            finally
            {
                result = new SuccessResult(_localizer[Messages.MailSendCompleted]);
            }
            return result;
        }

        /// <summary>
        /// Kullanıcıya aktivasyon Maili Gönderme
        /// </summary>
        /// <param name="userDto">Mail gönderilecek kişinin bilgilerini tutan Dto </param>
        /// <returns>Sonuç konteksini çıktı olarak verir.</returns>
        public async Task<IResult> SendActivationEmailAsync(UserDTO userDto)
        {
            var registeredUser = await _userManager.FindByEmailAsync(userDto.Email);
            if (registeredUser == null)
            {
                return new ErrorResult(_localizer[Messages.MailSendFail]);
            }

            var token = await _userManager.GenerateEmailConfirmationTokenAsync(registeredUser);
            var registeredUserId = userDto.Id.ToString();
            var url = GenerateEmailConfirmLink(token, registeredUserId);
            var html = GenerateAccountActivationEmailBody(url);

            _backGroundJobsClient.Enqueue(() => MainEmailSenderAsync(new EmailDto { ReciverEmailAddress = userDto.Email, Subject = "Hesap Aktivite", MailBody = html }));
            return new SuccessResult(_localizer[Messages.MailSendSuccess]);
        }
        /// <summary>
        /// Email onay linki(Url'i) oluşturma
        /// </summary>
        /// <param name="token">Mail göndermek için gereken token </param>
        /// <param name="UserId">Mail gönderilecek kişinin Id  </param>
        /// <returns>Sonuç konteksini çıktı olarak verir.</returns>

        public string GenerateEmailConfirmLink(string token, string userId)
        {
            var urlHelper = _urlHelperFactory.GetUrlHelper(_actionContextAccessor.ActionContext);
            var url = urlHelper.Action("Login", "Authentication", new { token, userId }, "https");
            return url;
            // TO DO -- Action methodu daha sonra doğru action adı ve doğru controller adı ile yazılmalıdır. Denemek için elimizdeki
            //action ve controller ile yazılmıştır.
        }

        /// <summary>
        /// Kullanıcıya Hesabı Aktive Etmek İçin Gereken Mailin gövdesini oluşturma
        /// </summary>
        /// <param name="url">Mail bodysi içerisindeki link </param>
        /// <returns>Sonuç konteksini çıktı olarak verir.</returns>
        public string GenerateAccountActivationEmailBody(string url)
        {
            var html = $@"<html><head></head>
                        <body>
                        <h2>Hesap Aktivite</h2>
                        <a href = {url} > Hesap Aktivasyonu için  Bağlantıya Tıklayınız </a> 
                        </body>
                        </html>";
            return html;
        }
        /// <summary>
        /// Kullanıcıya şifresini yenilmesi için gereken bilgilerin Mailini Gönderme
        /// </summary>
        /// <param name="email">Şifre resetlemek için gerekli hesabın bulunması için alınan mail adresi </param>
        /// <returns>Sonuç konteksini çıktı olarak verir.</returns>
        public async Task<IResult> SendResetPasswordInformationEmailAsync(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
            {
                return new ErrorResult(_localizer[Messages.MailSendFail]);
            }
            var resetToken = await _userManager.GeneratePasswordResetTokenAsync(user);
            var link = GenerateResetPasswordLink(resetToken, user.Id.ToString());
            var url = GenerateResetPasswordEmailBody(link);
            _backGroundJobsClient.Enqueue(() => MainEmailSenderAsync(new EmailDto { ReciverEmailAddress = email, Subject = "Şifre Yenileme", MailBody = url }));
            return new SuccessResult(_localizer[Messages.MailSendSuccess]);
        }
        /// <summary>
        /// Şifre Sıfırlama İçin Url Bağlantısı Oluşturma
        /// </summary>
        /// <param name="token">Mail göndermek için gereken token </param>
        /// <param name="UserId">Mail gönderilecek kişinin Id  </param>
        /// <returns>Sonuç konteksini çıktı olarak verir.</returns>
        public string GenerateResetPasswordLink(string token, string UserId)
        {
            var urlHelper = _urlHelperFactory.GetUrlHelper(_actionContextAccessor.ActionContext);
            var url = urlHelper.Action("Login", "Authentication", new { token, UserId }, "https");
            return url;
            // Action methodu daha sonra doğru action adı ve doğru controller adı ile yazılmalıdır. Denemek için elimizdeki
            //action ve controller ile yazılmıştır.
        }
        /// <summary>
        /// Kullancıya Şifre Yenileme Link Bilgilerini Gönderen Mailin Gövdesini Oluşturma
        /// </summary>
        /// <param name="url">Mail bodysi içerisindeki link </param>
        /// <returns>Sonuç konteksini çıktı olarak verir.</returns>
        public string GenerateResetPasswordEmailBody(string url)
        {
            var html = $@"<html><head></head>
                        <body>
                        <h2>Şifre Yenileme</h2>
                        <a href = {url}> Şifre Yenilemek için Bağlantıya Tıklayınız. </a>
                        </body>
                        </html>";
            return html;
        }
        /// <summary>
        /// Kullanıcıya Bilgilerini İçeren Maili Gönderme
        /// </summary>
        /// <param name="userDto">Bilgilendirme Mail gönderilecek kişinin bilgilerini tutan Dto  </param>
        /// <returns>Sonuç konteksini çıktı olarak verir.</returns>
        public async Task<IResult> SendUserInformationEmailAsync(UserDTO userDto)
        {
            var registeredUser = await _userManager.FindByEmailAsync(userDto.Email);
            if (registeredUser == null)
            {
                return new ErrorResult(_localizer[Messages.MailSendFail]);
            }

            var token = _userManager.GenerateEmailConfirmationTokenAsync(registeredUser);
            var userId = registeredUser.Id;

            //var url = EmailInformationLinkGenerator(token.ToString(), userId.ToString());
            var html = GenerateUserInformationsEmailBody(userDto.Email, "Password1.");
            _backGroundJobsClient.Enqueue(() => MainEmailSenderAsync(new EmailDto { ReciverEmailAddress = userDto.Email, Subject = "Hoşgeldiniz", MailBody = html }));
            return new SuccessResult(_localizer[Messages.MailSendSuccess]);
        }

        /// <summary>
        /// Kullanıcının Bilgilerini İçeren Mail Gövdesini Oluşturma
        /// </summary>
        /// <param name="userEmail">Mail bodysi içerisindeki kullanıcı mail bilgisini tutan paramaetre </param>
        /// <param name="userPassword">Mail bodysi içerisindeki şifre bilgisinini tutan paramaetre </param>
        /// <returns>Sonuç konteksini çıktı olarak verir.</returns>
        public string GenerateUserInformationsEmailBody(string userEmail, string userPassword)
        {
            var html = $@"<html><head></head>
                        <body>
                        <h2>Hoşgeldiniz</2>
                        <p>Giriş Bilgileriniz:</p><br>
                        <p>Kullanıcı Adı: {userEmail}</p> <br>
                        <p>Şifre: {userPassword}</p><br>
                        </html>";
            return html;
        }
        /// <summary>
        /// Kullanıcıya Doğrulama Maili Gönderme
        /// </summary>
        /// <param name="token">Mail aktivite için gerekli token bilgisini tutan parametre </param>
        /// <param name="userId">Mail aktivite için gerekli userId bilgisini tutan parametre </param>
        /// <returns>Sonuç konteksini çıktı olarak verir.</returns>

        public async Task<bool> SendConfirmEmailActivationAsync(string token, string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null) return false;

            var result = await _userManager.ConfirmEmailAsync(user, token);
            if (!result.Succeeded)
            {
                var newToken = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                var link = GenerateEmailConfirmLink(newToken, userId);
                var html = GenerateAccountActivationEmailBody(link);
                _backGroundJobsClient.Enqueue(() => MainEmailSenderAsync(new EmailDto { ReciverEmailAddress = user.Email, Subject = "Hesap Aktivite", MailBody = html }));
                return false;
            }
            return true;
        }

        /// <summary>
        /// Adaya yönlendirilen iş ilanı linki oluşturma
        /// </summary>
        /// <param name="jobId"></param>
        /// <returns></returns>
        public async Task<string> GenerateEmailJobCandidateLink(string id)
        {
            var urlHelper = _urlHelperFactory.GetUrlHelper(_actionContextAccessor.ActionContext);
            var url = urlHelper.Action("GetById", "Job", new { id }, "https");
            return url;
            // TO DO -- Action methodu daha sonra doğru action adı ve doğru controller adı ile yazılmalıdır. Denemek için elimizdeki
            //action ve controller ile yazılmıştır.
        }


        /// <summary>
        /// Adaya gönderilen Mailin Bodysini olusturma 
        /// </summary>
        /// <param name="jobId"></param>
        /// <param name="candidateId"></param>
        /// <returns></returns>
        public async Task<string> GenerateJobLinkBody(string jobId, string candidateId)
        {
            var link = await GenerateEmailJobCandidateLink(jobId);

            Guid.TryParse(jobId, out var jobIdGuid);

            Guid.TryParse(candidateId, out var candidateGuid);

            var job = await _jobRepo.GetByIdAsync(jobIdGuid);

            var candidate = await _candidateRepo.GetByIdAsync(candidateGuid);

            if (candidate is null)
                return null;

            var htmlEmailBody = $"<html lang=\"tr\">\r\n" +
                $"<head>\r\n    " +
                $"<meta charset=\"UTF-8\">\r\n" +
                $"    <meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0\">\r\n    " +
                $"<title>İş Fırsatı Hakkında Bilgilendirme</title>\r\n" +
                $"</head>\r\n" +
                $"<body>\r\n" +
                $"    <p>Sayın {candidate.FirstName} {candidate.LastName},</p>\r\n\r\n" +
                $"    <p>{job.Company.Name} bünyesinde şu anda {job.Position} pozisyonu için personel alımı yapılmaktadır. İlgili pozisyon için sahip olduğunuz deneyim ve becerilerin oldukça uygun olduğunu düşünmekteyiz.</p>\r\n\r\n" +
                $"    <p>İlanın detaylarına ve başvuru sürecine ilişkin bilgilere aşağıdaki linkten ulaşabilirsiniz:<br>\r\n" +
                $"    <a href=\"{link}\">İlan Linki</a></p>\r\n\r\n" +
                $"    <p>Başvuru süreci veya pozisyonla ilgili herhangi bir sorunuz olursa, lütfen bizimle iletişime geçmekten çekinmeyiniz.</p>\r\n\r\n" +
                $"    <p>İlginiz ve iş birliğiniz için teşekkür ederiz.</p>\r\n\r\n" +
                $"    <p>Saygılarımızla,</p>\r\n\r\n" +
                $"</body>\r\n" +
                $"</html>";
          
            return htmlEmailBody;
        }

        /// <summary>
        /// Adaya yönlendirilmek istenilen işin maili gönderme
        /// </summary>
        /// <param name="jobId"></param>
        /// <param name="candidateId"></param>
        /// <returns></returns>
        public async Task<bool> SendEmailJobToCandidate (string jobId,string candidateId)
        {
            Guid.TryParse(candidateId, out var candidateGuid);

            var candidate = await _candidateRepo.GetByIdAsync(candidateGuid);
           
            if (candidate == null) return false;
            
            var link = await GenerateEmailJobCandidateLink(jobId);
               
            var html = (await GenerateJobLinkBody(jobId,candidateId)).ToString();
            
            _backGroundJobsClient.Enqueue(() => 
            MainEmailSenderAsync(new EmailDto { 
                                                ReciverEmailAddress = candidate.Email, 
                                                Subject = "İş Fırsatı Hakkında Bilgilendirme", 
                                                MailBody = html 
            }));
            
            return true;
            
        }
    }
}


