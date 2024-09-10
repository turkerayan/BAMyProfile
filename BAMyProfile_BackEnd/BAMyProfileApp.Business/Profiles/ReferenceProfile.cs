using AutoMapper;
using BAMyProfileApp.Dtos.References;
using System;
using System.Collections.Generic;
using System.Linq;
using BAMyProfileApp.Entities.DbSets;
using System.Text;
using System.Threading.Tasks;

namespace BAMyProfileApp.Business.Profiles
{  
    public class  ReferenceProfile : Profile
    {
        public ReferenceProfile()
        {
            CreateMap<Reference, ReferenceDTO>();
            CreateMap<Reference, ReferenceListDTO>();
            CreateMap<ReferenceCreateDTO, Reference>();
            CreateMap<ReferenceUpdateDTO, Reference>();
        }
    }
}
