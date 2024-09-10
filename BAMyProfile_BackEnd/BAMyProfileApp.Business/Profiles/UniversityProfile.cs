using AutoMapper;
using BAMyProfileApp.Dtos.University;
using BAMyProfileApp.Entities.DbSets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAMyProfileApp.Business.Profiles;

public class UniversityProfile : Profile
{
    public UniversityProfile()
    {
        CreateMap<University, UniversityDTO>();
        CreateMap<University, UniversityListDTO>();
        CreateMap<UniversityCreateDTO, University>();
        CreateMap<UniversityUpdateDTO, University>();
    }
}
