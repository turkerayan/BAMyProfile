using BAMyProfileApp.Core.Entities.Interfaces;
using BAMyProfileApp.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAMyProfileApp.Core.Entities.Base
{
    public class BaseEntity : IEntity, ICreateableEntity, IUpdateableEntity
    {
        public Guid Id { get; set; }
        public Status Status { get; set; }
        public string CreatedBy { get; set; } = null!;
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; } = null!;
        public DateTime ModifiedDate { get; set; }
    }
}
