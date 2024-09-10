using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAMyProfileApp.Entities.Enums;


public enum SkillLevel : int
{
    [Display(Name = "Başlangıç")]
    Beginner = 1,
    [Display(Name = "Temel")]
    Elementary,
    [Display(Name = "Orta")]
    Intermediate,
    [Display(Name = "İleri")]
    Advanced,
    [Display(Name = "Yetkin")]
    Proficient

}
