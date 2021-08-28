using MailKit.Net.Smtp;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainSeatReservation.Commons.Configuration;
using TrainSeatReservation.Commons.Templates;

namespace TrainSeatReservation.Commons.EmailService
{
    public class EmailService : IEmailService
    {
        private readonly IEmailConfiguration _emailConfiguration;
        private readonly TemplateManager templateManager;

        public EmailService(IEmailConfiguration emailConfiguration, TemplateManager templateManager)
        {
            _emailConfiguration = emailConfiguration;
            this.templateManager = templateManager;
        }

        public void SendEmail(string name, string surname, string email, string subject, string content)
        {
            var message = new MimeMessage();

            message.From.Add(new MailboxAddress($"{name} {surname}", email));

            message.To.Add(new MailboxAddress(_emailConfiguration.SmtpName, _emailConfiguration.SmtpUserName));


            var footer = string.Format(this.templateManager.EmailFooter, name, surname, email);

            message.Subject = subject;
            message.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = content + footer,


            };


            using (var client = new SmtpClient())
            {
                client.Connect(_emailConfiguration.SmtpServer, _emailConfiguration.SmtpPort, false);

                client.AuthenticationMechanisms.Remove("XOAUTH2");
                client.Authenticate(_emailConfiguration.SmtpUserName, _emailConfiguration.SmtpPassword);

                client.Send(message);
                client.Disconnect(true);
            }
        }

        public void SendVerificationEmail(string name, string surname, string email, string subject, string content)
        {
            var message = new MimeMessage();


            message.From.Add(new MailboxAddress(_emailConfiguration.SmtpName, _emailConfiguration.SmtpUserName));

            message.To.Add(new MailboxAddress($"{name} {surname}", email));

            var footer = string.Format(this.templateManager.EmailFooter, _emailConfiguration.SmtpName, "", _emailConfiguration.SmtpUserName);

            message.Subject = subject;
            message.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = content + footer,


            };


            using (var client = new SmtpClient())
            {
                client.Connect(_emailConfiguration.SmtpServer, _emailConfiguration.SmtpPort, false);

                client.AuthenticationMechanisms.Remove("XOAUTH2");
                client.Authenticate(_emailConfiguration.SmtpUserName, _emailConfiguration.SmtpPassword);

                client.Send(message);
                client.Disconnect(true);
            }
        }

    }
}
