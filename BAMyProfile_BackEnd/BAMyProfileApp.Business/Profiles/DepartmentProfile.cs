using AutoMapper;
using BAMyProfileApp.Dtos.Department;
using BAMyProfileApp.Entities.DbSets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAMyProfileApp.Business.Profiles;

public class DepartmentProfile : Profile
{
    public DepartmentProfile()
    {
        CreateMap<Department, DepartmentDTO>();
        CreateMap<Department, DepartmentListDTO>();
        CreateMap<DepartmentCreateDTO, Department>();
        CreateMap<DepartmentUpdateDTO, Department>();
    }
}
