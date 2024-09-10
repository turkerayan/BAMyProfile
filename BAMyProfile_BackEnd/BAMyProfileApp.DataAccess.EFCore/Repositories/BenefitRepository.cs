using BAMyProfileApp.Core.DataAccess.EntityFramework;
using BAMyProfileApp.DataAccess.Contexts;
using BAMyProfileApp.DataAccess.Interfaces.Repositories;
using BAMyProfileApp.Entities.DbSets;

namespace BAMyProfileApp.DataAccess.EFCore.Repositories;

public class BenefitRepository : EFBaseRepository<Benefit>, IBenefitRepository
{
    public BenefitRepository(BAMyProfileAppDbContext context) : base(context)
    {
    }
}