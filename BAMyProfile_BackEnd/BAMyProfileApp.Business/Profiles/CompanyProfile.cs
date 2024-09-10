using AutoMapper;
using BAMyProfileApp.Dtos.Company;
using BAMyProfileApp.Entities.DbSets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAMyProfileApp.Business.Profiles
{
    public class CompanyProfile : Profile
    {
        public CompanyProfile()
        {
            CreateMap<Company, CompanyDTO>();
            CreateMap<Company, CompanyListDTO>();
            CreateMap<CompanyCreateDTO, Company>();
            CreateMap<CompanyUpdateDTO, Company>();
        }
    }
}
