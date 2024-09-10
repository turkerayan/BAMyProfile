using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAMyProfileApp.Dtos.EMailConfigs
{
    public class EmailDto
    {
        public string ReciverEmailAddress { get; set; }
        public string Subject { get; set; }
        public string MailBody { get; set; }
    }
}
