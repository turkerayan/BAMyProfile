using BAMyProfileApp.Core.DataAccess.EntityFramework;
using BAMyProfileApp.DataAccess.Contexts;
using BAMyProfileApp.DataAccess.Interfaces.Repositories;
using BAMyProfileApp.Entities.DbSets;

namespace BAMyProfileApp.DataAccess.EFCore.Repositories;

public class JobBenefitRepository : EFBaseRepository<JobBenefit>, IJobBenefitRepository
{
    public JobBenefitRepository(BAMyProfileAppDbContext context) : base(context)
    {
    }
}