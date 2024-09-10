using BAMyProfileApp.Core.DataAccess.EntityFramework;
using BAMyProfileApp.DataAccess.Contexts;
using BAMyProfileApp.DataAccess.Interfaces.Repositories;
using BAMyProfileApp.Entities.DbSets;

namespace BAMyProfileApp.DataAccess.EFCore.Repositories;

public class SkillRepository : EFBaseRepository<Skill>, ISkillRepository
{
    public SkillRepository(BAMyProfileAppDbContext context) : base(context)
    {
    }
}