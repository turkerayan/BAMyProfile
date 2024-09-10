using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAMyProfileApp.Entities.Enums
{
	public enum InterviewStatus
	{
		[Display(Name = "Beklemede")]
		Waiting = 1,
		[Display(Name = "Tamamlandı")]
		Completed,
		
	}
}
