﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAMyProfileApp.Dtos.Candidate
{
    public class CandidateCreateDTO
    {
            public Guid StudentId { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Email { get; set; }
            public string Address { get; set; }
            public bool Gender { get; set; }
            public string Image { get; set; }
            public string PhoneNumber { get; set; }
            public DateTime DateOfBirth { get; set; }

    }
}
