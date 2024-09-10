using AutoMapper;
using BAMyProfileApp.Dtos.Faculty;
using BAMyProfileApp.Entities.DbSets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAMyProfileApp.Business.Profiles;

public class FacultyProfile : Profile
{
    public FacultyProfile()
    {
        CreateMap<Faculty, FacultyDTO>();
        CreateMap<Faculty, FacultyListDTO>();
        CreateMap<FacultyCreateDTO, Faculty>();
        CreateMap<FacultyUpdateDTO, Faculty>();
    }
}