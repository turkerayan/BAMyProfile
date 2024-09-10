using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAMyProfileApp.Dtos.Experience;

public class ExperienceDTO
{
    public Guid Id { get; set; }

    public string CompanyName { get; set; } // Çalışılan Şirketin adı

    public DateTime DateOfStart { get; set; } // Şirkette işe giriş tarihi

    public DateTime? DateOfEnd { get; set; } // Şirketten ayrılış tarihi devam ediyor olabilir bu sebeple null alabilir --> ?

    public string Position { get; set; } // Şirketteki pozisyonu

    public string Description { get; set; } // Şirketteki pozisyonunun iş tanımı
    public Guid StudentId { get; set; }
}
