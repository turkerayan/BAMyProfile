using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAMyProfileApp.Dtos.References
{
    /// <summary>
    /// Yeni bir referans oluşturmak için kullanılan veri transfer nesnesi (DTO).
    /// </summary>
    public class ReferenceCreateDTO
    {
        public string Name { get; set; }
        public string Company { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Title { get; set; }
    }
}
