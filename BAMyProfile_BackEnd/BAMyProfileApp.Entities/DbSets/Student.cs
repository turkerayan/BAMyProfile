using BAMyProfileApp.Core.Entities.Base;
using BAMyProfileApp.Core.Enums;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAMyProfileApp.Entities.DbSets
{
    public class Student : AuditableEntity
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string? PhoneNumber { get; set; }
        public bool Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        
        public byte[]? Image { get; set; }
        public string? Address { get; set; }
        public bool IsCandidate { get; set; }
        public Position CurrentPosition { get; set; }
        public virtual IEnumerable<EventStudent>? StudentEvents { get; set; }
        
        public virtual ICollection<Cv> Cvs { get; set; }
        public virtual ICollection<ReferenceStudent>? ReferenceStudents { get; set; }
    
        //public Position CurrentPosition { get; set; }

        public virtual IEnumerable<StudentTrainingProgram>? StudentTrainingPrograms { get; set; }

        // Navigation Property
        public virtual IEnumerable<StudentCertificate>? StudentCertificates{ get; set; }
        public virtual IEnumerable<StudentLanguage>? StudentLanguages { get; set; }
        public virtual IEnumerable<CapabilityStudent>? StudentCapabilities { get; set; }        
        public virtual IEnumerable<Experience>? Experience { get; set; }
        public virtual IEnumerable<StudentDepartment>? StudentDepartments { get; set; }

    }
}
