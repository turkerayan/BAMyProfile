using AutoMapper;
using BAMyProfileApp.Dtos.StudentLanguage;
using BAMyProfileApp.Entities.DbSets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAMyProfileApp.Business.Profiles;

public class StudentLanguageProfile : Profile
{
    public StudentLanguageProfile()
    {
        CreateMap<StudentLanguage, StudentLanguageDTO>();
        CreateMap<StudentLanguage, StudentLanguageListDTO>();
        CreateMap<StudentLanguageCreateDTO, StudentLanguage>();
        CreateMap<StudentLanguageUpdateDTO, StudentLanguage>();
    }
}
