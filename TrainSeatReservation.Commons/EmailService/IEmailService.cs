﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainSeatReservation.Commons.Dto;

namespace TrainSeatReservation.Commons.EmailService
{
    public interface IEmailService
    {
        void SendEmail(string name, string surname, string email, string subject, string content);
        void SendVerificationEmail(string name, string surname, string email, string subject, string content);
        void SendEmailWithAttachment(byte[] attachment, TicketDto ticket, string subject, string content);
    }
}
