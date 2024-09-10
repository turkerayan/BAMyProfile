using BAMyProfileApp.Core.Enums;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAMyProfileApp.Dtos.Student
{
    public class StudentCreateDTO
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string? PhoneNumber { get; set; }
        public bool Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public IFormFile? Image { get; set; }
        public string? Address { get; set; }
        public Position CurrentPosition { get; set; }
        public bool IsCandidate { get; set; }
    }
}
