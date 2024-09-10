using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAMyProfileApp.Core.Entities.Interfaces
{
    public interface ICreateableEntity:IEntity
    {
        string CreatedBy { get; set; }
        DateTime CreatedDate { get; set; }
    }
}
