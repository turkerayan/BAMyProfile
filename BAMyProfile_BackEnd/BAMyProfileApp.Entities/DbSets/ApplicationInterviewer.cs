using BAMyProfileApp.Core.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAMyProfileApp.Entities.DbSets
{
	public class ApplicationInterviewer:BaseUser
	{
        public Guid ApplicationInterviewId { get; set; } //Mülakat Id
        public virtual ApplicationInterview? ApplicationInterview { get; set; }
    }
}
