using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAMyProfileApp.Core.Entities.Interfaces
{
    public interface ISoftDeletableEntity : ICreateableEntity, IEntity
    {
        string? DeletedBy { get; set; }
        DateTime? DeletedDate { get; set; }
    }
}
