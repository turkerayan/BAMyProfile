using AutoMapper;
using BAMyProfileApp.Business.Concretes;
using BAMyProfileApp.Dtos.Certificate;
using BAMyProfileApp.Entities.DbSets;

namespace BAMyProfileApp.Business.Profiles;

public class CertificateProfile : Profile
{
    public CertificateProfile()
    {
        CreateMap<Certificate, CertificateDTO>()
            .ForMember(dest => dest.File, opt => opt.MapFrom(new ByteArrayToBase64ResolveService<Certificate>("File")));
        CreateMap<Certificate, CertificateListDTO>()
            .ForMember(dest => dest.File, opt => opt.MapFrom(new ByteArrayToBase64ResolveService<Certificate>("File"))); ;
        CreateMap<CertificateCreateDTO, Certificate>()
            .ForMember(dest => dest.File, opt => opt.Ignore());
        CreateMap<CertificateUpdateDTO, Certificate>()
            .ForMember(dest => dest.File, opt => opt.Ignore()); ;
    }
}
