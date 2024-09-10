using BAMyProfileApp.Core.Enums;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAMyProfileApp.Dtos.Student
{
    public class StudentListDTO
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string? PhoneNumber { get; set; }
        public bool Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string? Image { get; set; }
        public string? Address { get; set; }
        public Position CurrentPosition { get; set; }
        public bool IsCandidate { get; set; }
        public List<string>? StudentCertificateNames { get; set; }
        public List<string>? EventStudentNames { get; set; }
        public List<string>? ReferenceStudentNames { get; set; }
        public List<string>? StudentTrainingProgramNames { get; set; }
        public List<string>? StudentLanguageNames { get; set; }
        public List<string>? CapabilityStudentNames { get; set; }
        public List<string>? InterviewNames { get; set; }
        public List<string>? ExperienceNames { get; set; }
    }
}
