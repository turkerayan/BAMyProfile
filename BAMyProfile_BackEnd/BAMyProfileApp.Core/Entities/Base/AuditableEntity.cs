using BAMyProfileApp.Core.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAMyProfileApp.Core.Entities.Base
{
    public class AuditableEntity : BaseEntity, ISoftDeletableEntity
    {
        public string? DeletedBy { get; set; }
        public DateTime? DeletedDate { get; set; }
    }
}
