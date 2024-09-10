using AutoMapper;
using BAMyProfileApp.Dtos.ApplicationInterview;
using BAMyProfileApp.Entities.DbSets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAMyProfileApp.Business.Profiles
{
	public class ApplicationInterviewProfile : Profile
	{
        public ApplicationInterviewProfile()
        {
			CreateMap<ApplicationInterview, ApplicationInterviewDTO>();
			CreateMap<ApplicationInterview, ApplicationInterviewListDTO>();
			CreateMap<ApplicationInterviewCreateDTO, ApplicationInterview>();
			CreateMap<ApplicationInterviewUpdateDTO, ApplicationInterview>();
		}
    }
}
