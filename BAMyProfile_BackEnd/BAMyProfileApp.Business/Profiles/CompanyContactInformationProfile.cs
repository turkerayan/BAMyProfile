using AutoMapper;
using BAMyProfileApp.Dtos.CompanyContactInformation;
using BAMyProfileApp.Entities.DbSets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAMyProfileApp.Business.Profiles
{
    public class CompanyContactInformationProfile : Profile
    {
        public CompanyContactInformationProfile()
        {
            CreateMap<CompanyContactInformation, CompanyContactInformationDTO>();
            CreateMap<CompanyContactInformation, CompanyContactInformationListDTO>();
            CreateMap<CompanyContactInformation, CompanyContactInformationListByCompanyIdDTO>();
            CreateMap<CompanyContactInformationCreateDTO, CompanyContactInformation>();
            CreateMap<CompanyContactInformationUpdateDTO, CompanyContactInformation>();
            
        }
    }
}
