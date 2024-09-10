using BAMyProfileApp.Business.Concretes;
using BAMyProfileApp.Business.Interfaces;
using BAMyProfileApp.Entities.DbSets;
using BAMyProfileApp.Dtos;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Routing;

namespace BAMyProfileApp.Business.Extensions
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddBusinessServices(this IServiceCollection services)
        {
            // AutoMapper
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            //Her gelen request için oluşturulacak instance oluşturuyor

            // Servisler arayüzünün bir örneğini, her HTTP isteği için ayrı ayrı oluşturmak üzere kaydeder.
            // Bu servisler, HTTP isteğinin ömrü boyunca canlı kalır ve her istek için yeniden oluşturulur.
            services.AddScoped<IExampleService, ExampleService>();
            services.AddScoped<ICapabilityService, CapabilityService>();
            services.AddScoped<ILanguagesService, LanguagesService>();
            services.AddScoped<IReferenceService, ReferenceService>();
            services.AddScoped<ICertificateService, CertificateService>();
            services.AddScoped<IStudentService, StudentService>();
            services.AddScoped<IEventService, EventService>();            
            services.AddScoped<IApplicationInterviewService, ApplicationInterviewService>();
            services.AddScoped<IApplicationInterviewerService, ApplicationInterviewerService>();
            
            //Her gelen request için oluşturulacak instance oluşturuyor
            services.AddScoped<IAuthenticationService, AuthenticationService>();
            //Her gelen request için oluşturulacak instance oluşturuyor
            services.AddScoped<IJWTService, JWTService>();
            //Her gelen request için oluşturulacak instance oluşturuyor


            services.AddScoped<ITrainingProgramService, TrainingProgramService>();
            services.AddScoped<IUniversityService, UniversityService>();
            services.AddScoped<IFacultyService, FacultyService>();
            services.AddScoped<IDepartmentService, DepartmentService>();
            services.AddScoped<IExperienceService, ExperienceService>();
            services.AddScoped<ICvService,CvService>();

            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<ICapabilityStudentService,CapabilityStudentService>();
            services.AddScoped<IEventStudentService,EventStudentService>();
            services.AddScoped<IReferenceStudentService, ReferenceStudentService>();
            services.AddScoped<IStudentCertificateService, StudentCertificateService>();
            services.AddScoped<IStudentDepartmentService, StudentDepartmentService>();
            services.AddScoped<IStudentLanguageService, StudentLanguageService>();
            services.AddScoped<IStudentTrainingProgramService, StudentTrainingProgramService>();
            services.AddScoped<ICandidateService,CandidateService>();
            services.AddScoped<IJobService, JobService>();
            services.AddScoped<IBenefitService, BenefitService>();
            services.AddScoped<ISkillService, SkillService>();
            services.AddScoped<IJobBenefitService, JobBenefitService>();
            services.AddScoped<IJobSkillService, JobSkillService>();
            services.AddScoped<IContactPersonService, ContactPersonService>();
            services.AddScoped<ICompanyService, CompanyService>();
            services.AddScoped<ICompanyContactInformationService, CompanyContactInformationService>();
            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<IApplicationService, ApplicationService>();
            services.AddScoped<IEmailService, EmailService>();
            services.AddScoped<IJobCandidateService, JobCandidateService>();
           
            //maillink için gerekli olan kütüphaneler
            services.AddSingleton(typeof(IUrlHelperFactory), typeof(UrlHelperFactory));
            services.AddSingleton(typeof(IActionContextAccessor), typeof(ActionContextAccessor));



            return services;
        }






    }
}
