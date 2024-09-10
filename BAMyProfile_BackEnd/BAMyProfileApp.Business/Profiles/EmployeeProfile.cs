using AutoMapper;
using BAMyProfileApp.Dtos.Employee;
using BAMyProfileApp.Entities.DbSets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAMyProfileApp.Business.Profiles
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            CreateMap<Employee,EmployeeDTO>();
            CreateMap<EmployeeCreateDTO,Employee>();
            CreateMap<EmployeeUpdateDTO,Employee>();
            CreateMap<Employee,EmployeeListDTO>();
        }
    }
}
