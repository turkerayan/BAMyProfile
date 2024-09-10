using AutoMapper;
using BAMyProfileApp.Dtos.Application;
using BAMyProfileApp.Dtos.ApplicationInterviewer;
using BAMyProfileApp.Entities.DbSets;
using BAMyProfileApp.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAMyProfileApp.Business.Profiles
{
    public class ApplicationProfile: Profile
    {
        public ApplicationProfile()
        {
            CreateMap<Application, ApplicationDTO>();
            CreateMap<Application, ApplicationListDTO>();
            CreateMap<Application, ApplicationListWithJobDTO>().ForMember(dest => dest.JobStatus, opt => opt.MapFrom(src => src.Job.JobStatus));
            CreateMap<ApplicationCreateDTO, Application>();
            CreateMap<ApplicationUpdateDTO, Application>();

        }
        
    }
}
