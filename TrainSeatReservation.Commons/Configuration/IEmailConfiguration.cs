using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainSeatReservation.Commons.Configuration
{
    public interface IEmailConfiguration
    {
        string SmtpServer { get; set; }
        int SmtpPort { get; set; }
        string SmtpUserName { get; set; }
        string SmtpPassword { get; set; }
        string SmtpName { get; set; }
        string TemplatePath { get; set; }
        string Subject { get; set; }
        string ChangeStatusSubject { get; set; }
        string ChangeStatusTitle { get; set; }
    }
}
