using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAMyProfileApp.Dtos.StudentLanguage;

public class StudentLanguageCreateDTO
{
    public Guid LanguageId { get; set; }
    public Guid StudentId { get; set; }
}
