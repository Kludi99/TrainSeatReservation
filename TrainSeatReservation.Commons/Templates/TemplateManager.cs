//Program powstał na Wydziale Informatyki Politechniki Białostockiej
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainSeatReservation.Commons.Configuration;

namespace TrainSeatReservation.Commons.Templates
{
    public class TemplateManager
    {
        private readonly IEmailConfiguration emailConfiguration;

        public string EmailFooter { get; set; }

        public TemplateManager(IEmailConfiguration emailConfiguration)
        {
            this.emailConfiguration = emailConfiguration;
            this.Initialize();
        }
        public void Initialize()
        {
            var templatePath = Path.Combine(this.emailConfiguration.TemplatePath, @"EmailFooter.html");
            this.EmailFooter = File.ReadAllText(templatePath);
        }
    }
}
