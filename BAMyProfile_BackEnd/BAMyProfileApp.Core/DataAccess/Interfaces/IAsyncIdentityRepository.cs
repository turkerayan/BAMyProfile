using BAMyProfileApp.Core.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAMyProfileApp.Core.DataAccess.Interfaces
{
    public interface IAsyncIdentityRepository<TEntity> where TEntity : BaseEntity
    {
        Task<TEntity> GetByIdentityId(string identityId);
    }
}
