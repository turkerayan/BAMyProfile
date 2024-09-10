using BAMyProfileApp.Core.Entities.Base;
using BAMyProfileApp.Core.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAMyProfileApp.Core.DataAccess.Interfaces
{
    public interface IAsyncDeleteableRepository<TEntity> : IAsyncRepository where TEntity : BaseEntity
    {
        Task DeleteAsync(TEntity entity);
    }
}
