using BAMyProfileApp.Core.DataAccess.EntityFramework;
using BAMyProfileApp.DataAccess.Contexts;
using BAMyProfileApp.DataAccess.Interfaces.Repositories;
using BAMyProfileApp.Entities.DbSets;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAMyProfileApp.DataAccess.EFCore.Repositories
{
	public class ApplicationInterviewerRepository : EFBaseRepository<ApplicationInterviewer>, IApplicationInterviewerRepository
	{
		public ApplicationInterviewerRepository(BAMyProfileAppDbContext context) : base(context)
		{

		}
	}
}
