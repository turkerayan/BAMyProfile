using AutoMapper;
using BAMyProfileApp.Dtos.StudentDepartment;
using BAMyProfileApp.Entities.DbSets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAMyProfileApp.Business.Profiles;

public class StudentDepartmentProfile : Profile
{
    public StudentDepartmentProfile()
    {
        CreateMap<StudentDepartment, StudentDepartmentDTO>();
        CreateMap<StudentDepartment, StudentDepartmentListDTO>();
        CreateMap<StudentDepartmentCreateDTO, StudentDepartment>();
        CreateMap<StudentDepartmentUpdateDTO, StudentDepartment>();
    }
}

