using AutoMapper;
using BAMyProfileApp.Dtos.Benefit;
using BAMyProfileApp.Entities.DbSets;

namespace BAMyProfileApp.Business.Profiles;

public class BenefitProfile : Profile
{
    public BenefitProfile()
    {
        CreateMap<Benefit, BenefitDTO>();
        CreateMap<Benefit, BenefitListDTO>();
        CreateMap<BenefitCreateDTO, Benefit>();
        CreateMap<BenefitUpdateDTO, Benefit>();
    }
}
