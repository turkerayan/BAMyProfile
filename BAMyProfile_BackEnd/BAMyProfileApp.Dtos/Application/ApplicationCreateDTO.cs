﻿using BAMyProfileApp.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAMyProfileApp.Dtos.Application
{
    public class ApplicationCreateDTO
    {
        public DateTime ApplicationDate { get; set; }
        public ApplicationStatus ApplicationStatus { get; set; }
        public ApplicationSuccessStatus? ApplicationSuccessStatus { get; set; }
        public string? Description { get; set; }
        public Guid CandidateId { get; set; }
        public Guid JobId { get; set; }
    }
}