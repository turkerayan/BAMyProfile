using BAMyProfileApp.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAMyProfileApp.Dtos.Languages;

public class LanguagesUpdateDTO
{
    public Guid Id { get; set; }
    public string LanguageName { get; set; } = null!; //Dil Adı
    public SkillLevel Level { get; set; }
} 
