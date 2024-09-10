using AutoMapper;
using BAMyProfileApp.Dtos.Example;
using BAMyProfileApp.Entities.DbSets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAMyProfileApp.Business.Profiles
{
    public class ExampleProfile : Profile
    {
        public ExampleProfile()
        {
            CreateMap<Example, ExampleDTO>();
            CreateMap<Example, ExampleListDTO>();
            CreateMap<ExampleCreateDTO, Example>();
            CreateMap<ExampleUpdateDTO, Example>();
        }
    }
}
