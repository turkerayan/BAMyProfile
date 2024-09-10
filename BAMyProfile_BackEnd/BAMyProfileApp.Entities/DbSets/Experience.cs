using BAMyProfileApp.Core.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BAMyProfileApp.Core.Entities.Interfaces;

namespace BAMyProfileApp.Entities.DbSets;

///<summary>
///Bir kişiye ait bilgileri içeren deneyim varlığını temsil eder
///<summary>

public class Experience : AuditableEntity
{
    public string CompanyName { get; set; }

    public DateTime DateOfStart { get; set; } 

    public DateTime? DateOfEnd { get; set; } 

    public string Position { get; set; }
    public string Description { get; set; }
    public Guid StudentId { get; set; }
    public virtual Student? Student { get; set; }
}
