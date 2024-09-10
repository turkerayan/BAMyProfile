using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAMyProfileApp.Dtos.Experience
{
    public class ExperienceCreateDTO
    {
        public string CompanyName { get; set; } 

        public DateTime DateOfStart { get; set; } 

        public DateTime? DateOfEnd { get; set; } 

        public string Position { get; set; } 

        public string Description { get; set; }
        public Guid StudentId { get; set; }
    }
}
