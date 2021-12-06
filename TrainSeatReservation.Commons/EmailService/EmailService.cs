using MailKit.Net.Smtp;
using MimeKit;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainSeatReservation.Commons.Configuration;
using TrainSeatReservation.Commons.Dto;
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
        public void SendEmailResignedTicket(string name, string surname, string email, int id)
        {
            var message = new MimeMessage();
            var subject = "Rezygnacja z biletu";
            var content = "Klient " + name + " " + surname + " zrezygnował z biletu o ID: " + id;
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
        public void SendEmailWithAttachment(byte[] attachment, TicketDto ticket, string subject, string content)
        {
            var message = new MimeMessage();

            message.From.Add(new MailboxAddress(_emailConfiguration.SmtpName, _emailConfiguration.SmtpUserName));

            message.To.Add(new MailboxAddress($"{ticket.Name} {ticket.Surname}", ticket.Email));

           

            var builder = new BodyBuilder();
           

            var footer = string.Format(this.templateManager.EmailFooter, _emailConfiguration.SmtpName, "", _emailConfiguration.SmtpUserName);

            message.Subject = subject;
            var body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = content + footer,


            };
            builder.HtmlBody = content + footer;
            //builder.TextBody = body.Content.ToString();

            builder.Attachments.Add("bilet.pdf", attachment, new ContentType("application", "pdf"));
            // var file = System.IO.File.WriteAllBytes("hello.pdf", fileContent);//new File(attachment, "application/pdf");
            var attachments = new List<MimeEntity>
{

    MimeEntity.Load(new ContentType("application", "pdf"), new MemoryStream(attachment))
};
            var multipart = new Multipart("mixed");
            multipart.Add(body);
            foreach (var item in attachments)
            {

                multipart.Add(item);
            }

            // now set the multipart/mixed as the message body
            // message.Body = multipart;
            message.Body = builder.ToMessageBody();
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
