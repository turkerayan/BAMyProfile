using AutoMapper;
using BAMyProfileApp.Dtos.JobCandidate;
using BAMyProfileApp.Entities.DbSets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAMyProfileApp.Business.Profiles
{
    public class JobCandidateProfile : Profile
    {
        public JobCandidateProfile()
        {
            CreateMap<JobCandidateCreateDTO, JobCandidate>();
            CreateMap<JobCandidate, JobCandidateDTO>();
            CreateMap<JobCandidate, JobCandidateListDTO>();
            CreateMap<JobCandidateUpdateDTO, JobCandidate>();
        }
    }
}
