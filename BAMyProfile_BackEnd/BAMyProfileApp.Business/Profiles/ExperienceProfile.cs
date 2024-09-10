using AutoMapper;
using BAMyProfileApp.Dtos.Experience;
using BAMyProfileApp.Entities.DbSets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAMyProfileApp.Business.Profiles;

public class ExperienceProfile : Profile
{
    public ExperienceProfile()
    {
        CreateMap<Experience, ExperienceDTO>();
        CreateMap<Experience, ExperienceListDTO>();
        CreateMap<ExperienceCreateDTO, Experience>();
        CreateMap<ExperienceUpdateDTO, Experience>();

    }
}
