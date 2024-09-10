using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BAMyProfileApp.Dtos.Capability;
using BAMyProfileApp.Entities.DbSets;

namespace BAMyProfileApp.Business.Profiles;
public class CapabilityProfile : Profile
{
    public CapabilityProfile()
    {
        CreateMap<Capability, CapabilityDTO>();
        CreateMap<Capability, CapabilityListDTO>();
        CreateMap<CapabilityCreateDTO, Capability>();
        CreateMap<CapabilityUpdateDTO, Capability>();

    }
}
