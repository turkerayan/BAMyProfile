using AutoMapper;
using BAMyProfileApp.Dtos.EventStudent;
using BAMyProfileApp.Entities.DbSets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAMyProfileApp.Business.Profiles;

public class EventStudentProfile : Profile
{
    public EventStudentProfile()
    {
        CreateMap<EventStudent, EventStudentDTO>();
        CreateMap<EventStudent, EventStudentListDTO>();
        CreateMap<EventStudentCreateDTO, EventStudent>();
        CreateMap<EventStudentUpdateDTO, EventStudent>();
    }
}