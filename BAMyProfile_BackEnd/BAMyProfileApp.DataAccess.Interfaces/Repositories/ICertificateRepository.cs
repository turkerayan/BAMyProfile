using BAMyProfileApp.Core.DataAccess.Interfaces;
using BAMyProfileApp.Entities.DbSets;

namespace BAMyProfileApp.DataAccess.Interfaces.Repositories
{
    public interface ICertificateRepository : IAsyncFindableRepository<Certificate>, IAsyncInsertableRepository<Certificate>, IAsyncRepository,IAsyncUpdateableRepository<Certificate>, IAsyncDeleteableRepository<Certificate>
    {
    }
}
