using AutoMapper;
using BAMyProfileApp.Dtos.JobBenefit;
using BAMyProfileApp.Entities.DbSets;

namespace BAMyProfileApp.Business.Profiles;

public class JobBenefitProfile : Profile
{
    public JobBenefitProfile()
    {
        CreateMap<JobBenefit, JobBenefitDTO>();
        CreateMap<JobBenefit, JobBenefitListDTO>();
        CreateMap<JobBenefitCreateDTO, JobBenefit>();
        CreateMap<JobBenefitUpdateDTO, JobBenefit>();
    }

}
