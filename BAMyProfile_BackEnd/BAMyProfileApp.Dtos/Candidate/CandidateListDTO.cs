using BAMyProfileApp.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAMyProfileApp.Dtos.Candidate
{
    public class CandidateListDTO
    {
        public Guid Id { get; set; }
        public Guid StudentId { get; set; }
        public WorkingStatus WorkingStatus { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string? PhoneNumber { get; set; }
        public bool Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string? Image { get; set; }
        public string? IdentityId { get; set; }
        public string? Address { get; set; }

    }
}
