﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAMyProfileApp.Dtos.ApplicationInterviewer
{
	public class ApplicationInterviewerCreateDTO
	{
		public string FirstName { get; set; } = null!;
		public string LastName { get; set; } = null!;
		public string Email { get; set; } = null!;
		public string? PhoneNumber { get; set; }
		public bool Gender { get; set; }
		public DateTime DateOfBirth { get; set; }
		public string? Image { get; set; }
		public string? Address { get; set; }
		public Guid ApplicationInterviewId { get; set; }
	}
}
