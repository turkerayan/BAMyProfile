using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAMyProfileApp.Core.Entities.Base;

public class BaseLanguages : AuditableEntity
{
    public string LanguageName { get; set; } = null!;

}
