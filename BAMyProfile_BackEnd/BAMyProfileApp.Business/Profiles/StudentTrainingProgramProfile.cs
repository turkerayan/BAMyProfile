using AutoMapper;
using BAMyProfileApp.Dtos.StudentTrainingProgram;
using BAMyProfileApp.Entities.DbSets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAMyProfileApp.Business.Profiles;

public class StudentTrainingProgramProfile : Profile
{
    public StudentTrainingProgramProfile()
    {
        CreateMap<StudentTrainingProgram, StudentTrainingProgramDTO>();
        CreateMap<StudentTrainingProgram, StudentTrainingProgramListDTO>();
        CreateMap<StudentTrainingProgramCreateDTO, StudentTrainingProgram>();
        CreateMap<StudentTrainingProgramUpdateDTO, StudentTrainingProgram>();
    }
}

