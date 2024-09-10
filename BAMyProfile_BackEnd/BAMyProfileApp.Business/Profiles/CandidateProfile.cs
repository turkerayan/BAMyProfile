using AutoMapper;
using BAMyProfileApp.Dtos.Candidate;
using BAMyProfileApp.Dtos.Student;
using BAMyProfileApp.Entities.DbSets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAMyProfileApp.Business.Profiles
{
    public class CandidateProfile:Profile
    {
        public CandidateProfile()
        {
            CreateMap<Candidate, CandidateDTO>();
            CreateMap<Student, CandidateCreateDTO>()
            .ForMember(dest => dest.StudentId, opt => opt.MapFrom(src => src.Id));
            CreateMap<CandidateCreateDTO, Candidate>();
            CreateMap<Candidate, CandidateListDTO>();
            CreateMap<CandidateUpdateDTO, Candidate>();
        }
       
    }
}
