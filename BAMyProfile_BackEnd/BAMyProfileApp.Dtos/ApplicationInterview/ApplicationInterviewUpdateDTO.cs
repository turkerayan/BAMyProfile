using BAMyProfileApp.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAMyProfileApp.Dtos.ApplicationInterview
{
	public class ApplicationInterviewUpdateDTO
	{
		public Guid Id { get; set; }
		public Guid CompanyId { get; set; }
        public Guid ApplicationId { get; set; }
        public DateTime InterviewDate { get; set; }
        public string InterviewComment { get; set; } = null!;
        public InterviewSuccessStatus? InterviewSuccessStatus { get; set; }
		public InterviewStatus InterviewStatus { get; set; }
	}
}
