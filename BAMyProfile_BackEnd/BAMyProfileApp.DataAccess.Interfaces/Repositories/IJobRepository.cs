using BAMyProfileApp.Core.DataAccess.Interfaces;
using BAMyProfileApp.Entities.DbSets;

namespace BAMyProfileApp.DataAccess.Interfaces.Repositories;

public interface IJobRepository :
    IAsyncFindableRepository<Job>,
    IAsyncInsertableRepository<Job>,
    IAsyncUpdateableRepository<Job>,
    IAsyncDeleteableRepository<Job>

{
}
