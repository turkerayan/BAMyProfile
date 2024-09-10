using AutoMapper;
using BAMyProfileApp.Dtos.StudentCertificate;
using BAMyProfileApp.Entities.DbSets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAMyProfileApp.Business.Profiles;

public class StudentCertificateProfile : Profile
{
    public StudentCertificateProfile()
    {
        CreateMap<StudentCertificate, StudentCertificateDTO>();
        CreateMap<StudentCertificate, StudentCertificateListDTO>();
        CreateMap<StudentCertificateCreateDTO, StudentCertificate>();
        CreateMap<StudentCertificateUpdateDTO, StudentCertificate>();
    }
}

