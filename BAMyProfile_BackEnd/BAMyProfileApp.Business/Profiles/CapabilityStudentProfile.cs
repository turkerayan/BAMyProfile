using AutoMapper;
using BAMyProfileApp.Dtos.CapabilityStudent;
using BAMyProfileApp.Entities.DbSets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAMyProfileApp.Business.Profiles;

public class CapabilityStudentProfile : Profile
{
    public CapabilityStudentProfile()
    {
        CreateMap<CapabilityStudent, CapabilityStudentDTO>();
        CreateMap<CapabilityStudent, CapabilityStudentListDTO>();
        CreateMap<CapabilityStudentCreateDTO, CapabilityStudent>();
        CreateMap<CapabilityStudentUpdateDTO, CapabilityStudent>();
    }
}
