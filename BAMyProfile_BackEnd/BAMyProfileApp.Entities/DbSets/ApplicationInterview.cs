using BAMyProfileApp.Core.Entities.Base;
using BAMyProfileApp.Entities.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAMyProfileApp.Entities.DbSets
{
	public class ApplicationInterview : AuditableEntity
	{
		public Guid CompanyId { get; set; } //Şirket Id
		public Guid ApplicationId { get; set; } // Başvuru Id
		public DateTime InterviewDate { get; set; }
        public string InterviewComment { get; set; } = null!; //Mülakat yorumu
        public virtual ICollection<ApplicationInterviewer> Interviewers { get; set; } //Mülakata katılanlar
		public  InterviewSuccessStatus? InterviewSuccessStatus { get; set; } //Mülakat başarısı
		public InterviewStatus InterviewStatus { get; set; } //Mülakat durumu
        public virtual Application Application { get; set; } 
        public virtual Company? Company { get; set; }
	}
}
