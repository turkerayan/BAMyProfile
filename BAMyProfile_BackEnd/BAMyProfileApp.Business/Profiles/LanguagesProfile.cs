using BAMyProfileApp.Entities.DbSets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BAMyProfileApp.Dtos.Languages;

namespace BAMyProfileApp.Business.Profiles;

public class LanguagesProfile : Profile
{
    public LanguagesProfile()
    {
        CreateMap<Languages, LanguagesDTO>();
        CreateMap<Languages, LanguagesListDTO>();
        CreateMap<LanguagesCreateDTO, Languages>();
        CreateMap<LanguagesUpdateDTO, Languages>();
    }
}
