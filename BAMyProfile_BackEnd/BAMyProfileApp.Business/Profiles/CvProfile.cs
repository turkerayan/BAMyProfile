using AutoMapper;
using BAMyProfileApp.Dtos.Cv;
using BAMyProfileApp.Entities.DbSets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAMyProfileApp.Business.Profiles;

public class CvProfile : Profile
{
    public CvProfile()
    {
        CreateMap<Cv, CvDTO>()
            .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.Student.FirstName + " " + src.Student.LastName))
            .ForMember(dest => dest.StudentCertificateNames, opt => opt.MapFrom(src => src.Student.StudentCertificates.Select(sc => sc.Certificate.Id).ToList()))
            .ForMember(dest => dest.EventStudentNames, opt => opt.MapFrom(src => src.Student.StudentEvents.Select(sc => sc.Event.Title).ToList()))
            .ForMember(dest => dest.ReferenceStudentNamesss, opt => opt.MapFrom(src => src.Student.ReferenceStudents.Select(sc => sc.Reference.Name).ToList()))
            .ForMember(dest => dest.StudentTrainingProgramNames, opt => opt.MapFrom(src => src.Student.StudentTrainingPrograms.Select(sc => sc.TrainingProgram.Name).ToList()))
            .ForMember(dest => dest.StudentLanguageNames, opt => opt.MapFrom(src => src.Student.StudentLanguages.Select(sc => sc.Language.LanguageName).ToList()))
            .ForMember(dest => dest.CapabilityStudentNames, opt => opt.MapFrom(src => src.Student.StudentCapabilities.Select(sc => sc.Capability.CapabilityName).ToList()))            
            .ForMember(dest => dest.ExperienceNames, opt => opt.MapFrom(src => src.Student.Experience.Select(sc => sc.CompanyName).ToList()));


        CreateMap<Cv, CvListDTO>()
            .ForMember(dest => dest.StudentCertificateNames, opt => opt.MapFrom(src => src.Student.StudentCertificates.Select(sc => sc.Certificate.Name).ToList()))
            .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.Student.FirstName + " " + src.Student.LastName))
            .ForMember(dest => dest.EventStudentNames, opt => opt.MapFrom(src => src.Student.StudentEvents.Select(sc => sc.Event.Title).ToList()))
        .ForMember(dest => dest.ReferenceStudentNames, opt => opt.MapFrom(src => src.Student.ReferenceStudents.Select(sc => sc.Reference.Name).ToList()))
        .ForMember(dest => dest.StudentTrainingProgramNames, opt => opt.MapFrom(src => src.Student.StudentTrainingPrograms.Select(sc => sc.TrainingProgram.Name).ToList()))
        .ForMember(dest => dest.StudentLanguageNames, opt => opt.MapFrom(src => src.Student.StudentLanguages.Select(sc => sc.Language.LanguageName).ToList()))
        .ForMember(dest => dest.CapabilityStudentNames, opt => opt.MapFrom(src => src.Student.StudentCapabilities.Select(sc => sc.Capability.CapabilityName).ToList()))        
        .ForMember(dest => dest.ExperienceNames, opt => opt.MapFrom(src => src.Student.Experience.Select(sc => sc.CompanyName).ToList()));
        CreateMap<CvCreateDTO, Cv>();
        CreateMap<CvUpdateDTO, Cv>();

        




    }
}








