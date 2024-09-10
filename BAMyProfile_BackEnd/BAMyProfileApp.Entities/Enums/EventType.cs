using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAMyProfileApp.Entities.Enums;

public enum EventType : int
{
    [Display(Name = "Seminer")]
    Seminar = 1,
    [Display(Name = "Kariyer Fuarı")]
    CareerFair,
    [Display(Name = "Bağlantı Kurma")]
    Networking
}
