using BAMyProfileApp.Core.DataAccess.Interfaces;
using BAMyProfileApp.Entities.DbSets;

namespace BAMyProfileApp.DataAccess.Interfaces.Repositories;

public interface IJobBenefitRepository :
    IAsyncFindableRepository<JobBenefit>,
    IAsyncInsertableRepository<JobBenefit>,
    IAsyncUpdateableRepository<JobBenefit>,
    IAsyncDeleteableRepository<JobBenefit>

{
}
