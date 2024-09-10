using BAMyProfileApp.DataAccess.EFCore.Repositories;
using BAMyProfileApp.DataAccess.Interfaces.Repositories;
using Microsoft.Extensions.DependencyInjection;
using BAMyProfileApp.Entities.DbSets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BAMyProfileApp.DataAccess.EFCore.Seeds;
using Castle.Core.Configuration;
using Microsoft.AspNetCore.Http;
using System.Reflection;
using BAMyProfileApp.Core.DataAccess.EntityFramework;

namespace BAMyProfileApp.DataAccess.EFCore.Extensions
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddEFCoreServices(this IServiceCollection services, Microsoft.Extensions.Configuration.IConfiguration configuration)
        {
            // Servisler arayüzünün bir örneğini, her HTTP isteği için ayrı ayrı oluşturmak üzere kaydeder.
            // Bu servisler, HTTP isteğinin ömrü boyunca canlı kalır ve her istek için yeniden oluşturulur.
            services.AddScoped<IExampleRepository, ExampleRepository>();
            services.AddScoped<ILanguagesRepository, LanguagesRepository>();
            services.AddScoped<ICapabilityRepository, CapabilityRepository>();

            services.AddScoped<IStudentRepository, StudentRepository>();
            services.AddScoped<IEventRepository, EventRepository>();
            services.AddScoped<ICertificateRepository, CertificateRepository>();
            services.AddScoped<IReferenceRepository, ReferenceRepository>();
            services.AddScoped<ITrainingProgramRepository, TrainingProgramRepository>();
            services.AddScoped<IStudentRepository, StudentRepository>();
            services.AddScoped<IUniversityRepository, UniversityRepository>();
            services.AddScoped<IFacultyRepository, FacultyRepository>();
            services.AddScoped<IDepartmentRepository, DepartmentRepository>();
            services.AddScoped<IExperienceRepository, ExperienceRepository>();
            services.AddScoped<ICvRepository, CvRepository>();
            services.AddScoped<ICapabilityStudentRepository, CapabilityStudentRepository>();
            services.AddScoped<IEventStudentRepository, EventStudentRepository>();
            services.AddScoped<IReferenceStudentRepository, ReferenceStudentRepository>();
            services.AddScoped<IStudentCertificateRepository, StudentCertificateRepository>();
            services.AddScoped<IStudentDepartmentRepository, StudentDepartmentRepository>();
            services.AddScoped<IStudentLanguageRepository, StudentLanguageRepository>();
            services.AddScoped<IStudentTrainingProgramRepository, StudentTrainingProgramRepository>();
            services.AddScoped<ICandidateRepository, CandidateRepository>();
            services.AddScoped<IJobRepository, JobRepository>();
            services.AddScoped<IBenefitRepository, BenefitRepository>();
            services.AddScoped<ISkillRepository, SkillRepository>();
            services.AddScoped<IJobBenefitRepository, JobBenefitRepository>();
            services.AddScoped<IJobSkillRepository, JobSkillRepository>();

            services.AddScoped<IApplicationInterviewRepository, ApplicationInterviewRepository>();
            services.AddScoped<IApplicationInterviewerRepository, ApplicationInterviewerRepository>();
            services.AddScoped<IContactPersonRepository, ContactPersonRepository>();
            services.AddScoped<ICompanyRepository, CompanyRepository>();
            services.AddScoped<ICompanyContactInformationRepository, CompanyContactInformationRepository>();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IApplicationRepository, ApplicationRepository>();
            services.AddScoped<IJobCandidateRepository, JobCandidateRepository>();

            AdminSeed.SeedAsync(configuration).GetAwaiter().GetResult();

            //services.AddRepositoryFromAssemblyContaing(Assembly.GetExecutingAssembly(), typeof(EFBaseRepository<>)); 

            return services;
        }

        //ToDo:Herhangi bir sınıftan türeyen Tüm diğer sınıfları Assembly ve Type olarak alıp Serviceslere eklememizi sağlayan Metot
        //private static IServiceCollection AddRepositoryFromAssemblyContaing(this IServiceCollection services, Assembly assembly, Type type)
        //{
        //    List<Type> types = assembly.GetTypes().Where(t => t.IsSubclassOf(type) && type != t).ToList();
        //    foreach (Type item in types)
        //        services.AddScoped(item);
        //    return services;
        //}
    }
}

