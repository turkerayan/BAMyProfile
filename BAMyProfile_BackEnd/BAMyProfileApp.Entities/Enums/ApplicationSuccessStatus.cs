using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAMyProfileApp.Entities.Enums
{
    public enum ApplicationSuccessStatus
    {
        [Display(Name = "Başarılı")]
        Successful = 1,
        [Display(Name = "Başarısız")]
        Unsuccessful
    }
}
