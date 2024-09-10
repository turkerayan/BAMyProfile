using AutoMapper;
using BAMyProfileApp.Dtos.ContactPerson;
using BAMyProfileApp.Entities.DbSets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAMyProfileApp.Business.Profiles
{
    public class ContactPersonProfile : Profile
    {
        public ContactPersonProfile()
        {
            CreateMap<ContactPerson, ContactPersonDTO>();
            CreateMap<ContactPersonCreateDto, ContactPerson >();
            CreateMap<ContactPersonUpdateDto, ContactPerson >();
            CreateMap<ContactPerson, ContactPersonListDTO>();
        }
    }
}
