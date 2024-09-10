using AutoMapper;
using BAMyProfileApp.Dtos.ReferenceStudent;
using BAMyProfileApp.Entities.DbSets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAMyProfileApp.Business.Profiles;

public class ReferenceStudentProfile : Profile
{
    public ReferenceStudentProfile()
    {
        CreateMap<ReferenceStudent, ReferenceStudentDTO>();
        CreateMap<ReferenceStudent, ReferenceStudentListDTO>();
        CreateMap<ReferenceStudentCreateDTO, ReferenceStudent>();
        CreateMap<ReferenceStudentUpdateDTO, ReferenceStudent>();
    }
}

