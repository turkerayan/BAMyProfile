using AutoMapper;
using BAMyProfileApp.Dtos.User;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAMyProfileApp.Business.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<IdentityUser,UserDTO>();
            CreateMap<UserDTO, IdentityUser>();
        }
    }
}
