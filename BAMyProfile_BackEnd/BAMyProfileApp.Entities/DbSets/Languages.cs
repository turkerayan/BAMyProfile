using BAMyProfileApp.Core.Entities.Base;
using BAMyProfileApp.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAMyProfileApp.Entities.DbSets;

public class Languages : AuditableEntity
{
    public string LanguageName { get; set; } = null!; //Dil Adı
    public SkillLevel Level { get; set; }
    // Navigation Property
    public virtual IEnumerable<StudentLanguage>? LanguageStudents { get; set; }

}
