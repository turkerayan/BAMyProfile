using BAMyProfileApp.Core.DataAccess.Interfaces;
using BAMyProfileApp.Entities.DbSets;

namespace BAMyProfileApp.DataAccess.Interfaces.Repositories;

public interface IBenefitRepository :
    IAsyncFindableRepository<Benefit>,
    IAsyncInsertableRepository<Benefit>,
    IAsyncUpdateableRepository<Benefit>,
    IAsyncDeleteableRepository<Benefit>
{
}
