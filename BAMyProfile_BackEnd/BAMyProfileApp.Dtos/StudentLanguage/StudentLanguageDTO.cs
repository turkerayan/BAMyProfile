﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAMyProfileApp.Dtos.StudentLanguage;

public class StudentLanguageDTO
{
    public Guid Id { get; set; }
    public Guid LanguageId { get; set; }
    public Guid StudentId { get; set; }
}
