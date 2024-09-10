using AutoMapper;
using BAMyProfileApp.Dtos.Job;
using BAMyProfileApp.Entities.DbSets;

namespace BAMyProfileApp.Business.Profiles;

public class JobProfile : Profile
{
    public JobProfile()
    {
        CreateMap<Job, JobDTO>()
            .ForMember(dest => dest.JobBenefitNames, opt => opt.MapFrom(src => src.JobBenefits.Select(jb => jb.Benefit.Name).ToList()))
            .ForMember(dest => dest.JobSkillNames, opt => opt.MapFrom(src => src.JobSkills.Select(js => js.Skill.Name).ToList()));

        CreateMap<Job, JobListDTO>()
            .ForMember(dest => dest.JobBenefitNames, opt => opt.MapFrom(src => src.JobBenefits.Select(jb => jb.Benefit.Name).ToList()))
            .ForMember(dest => dest.JobSkillNames, opt => opt.MapFrom(src => src.JobSkills.Select(js => js.Skill.Name).ToList()));

        CreateMap<JobCreateDTO, Job>();
        CreateMap<JobUpdateDTO, Job>();
    }
}
