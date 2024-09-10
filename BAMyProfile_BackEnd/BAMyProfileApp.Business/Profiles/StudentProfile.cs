using AutoMapper;
using BAMyProfileApp.Business.Concretes;
using BAMyProfileApp.Dtos.Student;
using BAMyProfileApp.Entities.DbSets;
using System.Linq;

namespace BAMyProfileApp.Business.Profiles
{
    public class StudentProfile : Profile
    {
        public StudentProfile()
        {
            // Student -> StudentDTO
            CreateMap<Student, StudentDTO>()
                .ForMember(dest => dest.StudentCertificateNames, opt => opt.MapFrom(src => src.StudentCertificates.Select(sc => sc.Certificate.Id).ToList()))
                .ForMember(dest => dest.EventStudentNames, opt => opt.MapFrom(src => src.StudentEvents.Select(sc => sc.Event.Title).ToList()))
                .ForMember(dest => dest.ReferenceStudentNames, opt => opt.MapFrom(src => src.ReferenceStudents.Select(sc => sc.Reference.Name).ToList()))
                .ForMember(dest => dest.StudentTrainingProgramNames, opt => opt.MapFrom(src => src.StudentTrainingPrograms.Select(sc => sc.TrainingProgram.Name).ToList()))
                .ForMember(dest => dest.StudentLanguageNames, opt => opt.MapFrom(src => src.StudentLanguages.Select(sc => sc.Language.LanguageName).ToList()))
                .ForMember(dest => dest.CapabilityStudentNames, opt => opt.MapFrom(src => src.StudentCapabilities.Select(sc => sc.Capability.CapabilityName).ToList()))
                .ForMember(dest => dest.ExperienceNames, opt => opt.MapFrom(src => src.Experience.Select(sc => sc.CompanyName).ToList()))
                .ForMember(dest => dest.Image, opt => opt.MapFrom(new ByteArrayToBase64ResolveService<Student>("Image"))); // Image'i base64 formatına çevir
                

            // Student -> StudentListDTO
            CreateMap<Student, StudentListDTO>()
                .ForMember(dest => dest.StudentCertificateNames, opt => opt.MapFrom(src => src.StudentCertificates.Select(sc => sc.Certificate.Id).ToList()))
                .ForMember(dest => dest.EventStudentNames, opt => opt.MapFrom(src => src.StudentEvents.Select(sc => sc.Event.Title).ToList()))
                .ForMember(dest => dest.ReferenceStudentNames, opt => opt.MapFrom(src => src.ReferenceStudents.Select(sc => sc.Reference.Name).ToList()))
                .ForMember(dest => dest.StudentTrainingProgramNames, opt => opt.MapFrom(src => src.StudentTrainingPrograms.Select(sc => sc.TrainingProgram.Name).ToList()))
                .ForMember(dest => dest.StudentLanguageNames, opt => opt.MapFrom(src => src.StudentLanguages.Select(sc => sc.Language.LanguageName).ToList()))
                .ForMember(dest => dest.CapabilityStudentNames, opt => opt.MapFrom(src => src.StudentCapabilities.Select(sc => sc.Capability.CapabilityName).ToList()))
                .ForMember(dest => dest.ExperienceNames, opt => opt.MapFrom(src => src.Experience.Select(sc => sc.CompanyName).ToList()))
                .ForMember(dest => dest.Image, opt => opt.MapFrom(new ByteArrayToBase64ResolveService<Student>("Image"))); // Image'i base64 formatına çevir

            // StudentCreateDTO -> Student
            CreateMap<StudentCreateDTO, Student>()
                .ForMember(dest => dest.Image, opt => opt.Ignore()); // Image, create işleminde doğrudan set edilmez

            // StudentUpdateDTO -> Student
            CreateMap<StudentUpdateDTO, Student>()
                .ForMember(dest => dest.Image, opt => opt.Ignore()); // Image, update işleminde doğrudan set edilmez
        }
    }
}
