using BAMyProfileApp.Core.DataAccess.EntityFramework;
using BAMyProfileApp.DataAccess.Interfaces.Repositories;
using BAMyProfileApp.Entities.DbSets;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BAMyProfileApp.DataAccess.Contexts;

namespace BAMyProfileApp.DataAccess.EFCore.Repositories;

public class EventRepository : EFBaseRepository<Event>, IEventRepository
{
	public EventRepository(BAMyProfileAppDbContext context) : base(context)
	{

	}
}
