using AutoMapper;
using BAMyProfileApp.Dtos.ApplicationInterview;
using BAMyProfileApp.Dtos.ApplicationInterviewer;
using BAMyProfileApp.Entities.DbSets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAMyProfileApp.Business.Profiles
{
	public class ApplicationInterviewerProfile : Profile
	{
		public ApplicationInterviewerProfile()
		{
			CreateMap<ApplicationInterviewer, ApplicationInterviewerDTO>();
			CreateMap<ApplicationInterviewer, ApplicationInterviewerListDTO>();
			CreateMap<ApplicationInterviewerCreateDTO, ApplicationInterviewer>();
			CreateMap<ApplicationInterviewerUpdateDTO, ApplicationInterviewer>();
		}
	}
}
