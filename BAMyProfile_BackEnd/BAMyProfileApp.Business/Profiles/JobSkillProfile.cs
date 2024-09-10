using AutoMapper;
using BAMyProfileApp.Dtos.JobSkill;
using BAMyProfileApp.Entities.DbSets;

namespace BAMyProfileApp.Business.Profiles;

public class JobSkillProfile : Profile
{
    public JobSkillProfile()
    {
        CreateMap<JobSkill, JobSkillDTO>();
        CreateMap<JobSkill, JobSkillListDTO>();
        CreateMap<JobSkillCreateDTO, JobSkill>();
        CreateMap<JobSkillUpdateDTO, JobSkill>();
    }
}
