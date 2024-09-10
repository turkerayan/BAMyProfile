using AutoMapper;
using BAMyProfileApp.Dtos.Example;
using BAMyProfileApp.Dtos.TrainingProgram;
using BAMyProfileApp.Entities.DbSets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAMyProfileApp.Business.Profiles;

public class TrainingProgramProfile : Profile
{
    public TrainingProgramProfile()
    {
        CreateMap<TrainingProgram, TrainingProgramDTO>(); 
        CreateMap<TrainingProgram, TrainingProgramListDTO>(); 
        CreateMap<TrainingProgramCreateDTO, TrainingProgram>(); 
        CreateMap<TrainingProgramUpdateDTO, TrainingProgram>(); 
    }
}
