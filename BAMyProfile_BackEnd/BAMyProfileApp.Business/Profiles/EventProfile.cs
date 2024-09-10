using AutoMapper;
using BAMyProfileApp.Business.Concretes;
using BAMyProfileApp.Dtos.Event;
using BAMyProfileApp.Dtos.Example;
using BAMyProfileApp.Entities.DbSets;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAMyProfileApp.Business.Profiles;

public class EventProfile : Profile
{
    public EventProfile()
    {
        CreateMap<Event, EventDTO>()
            .ForMember(dest => dest.File, opt => opt.MapFrom(new ByteArrayToBase64ResolveService<Event>("File")));
        CreateMap<Event, EventListDTO>()
            .ForMember(dest => dest.File, opt => opt.MapFrom(new ByteArrayToBase64ResolveService<Event>("File")));
        CreateMap<EventCreateDTO, Event>()
            .ForMember(dest => dest.File, opt => opt.Ignore());
        CreateMap<EventUpdateDTO,Event>()
            .ForMember(dest => dest.File, opt => opt.Ignore());

    }
}
