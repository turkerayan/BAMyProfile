using AutoMapper;
using BAMyProfileApp.Dtos.Skill;
using BAMyProfileApp.Entities.DbSets;

namespace BAMyProfileApp.Business.Profiles;

public class SkillProfile : Profile
{
    public SkillProfile()
    {
        CreateMap<Skill, SkillDTO>();
        CreateMap<Skill, SkillListDTO>();
        CreateMap<SkillCreateDTO, Skill>();
        CreateMap<SkillUpdateDTO, Skill>();
    }
}
