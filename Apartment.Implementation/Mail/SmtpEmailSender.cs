using Castle.Core.Smtp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Apartment.Application.Mail;

namespace Apartment.Implementation.Mail
{
    public class SmtpEmailSender : Application.Mail.IEmailSend
    {
        private string _fromEmail;
        private string _password;
        private int _port;
        private string _host;

        public SmtpEmailSender(string fromEmail, string password, int port, string host)
        {
            _fromEmail = fromEmail;
            _password = password;
            _port = port;
            _host = host;
        }

        public void Send(MailDto dto)
        {
            var smtp = new SmtpClient
            {
                Host = _host,
                Port = _port,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                Credentials = new NetworkCredential(_fromEmail, _password),
                UseDefaultCredentials = false
            };
            var message = new MailMessage(_fromEmail, dto.To);
            message.Subject = dto.Title;
            message.Body = dto.Message;
            message.IsBodyHtml = true;
            smtp.Send(message);
        }

        public string CreatedReservation(string aparmtentName, string userFullName, string srcApartment, string price, string dates)
        {
            return ""; // izcitati html fajl i ubaciti u njega potrebne podatke;
        }
    }
}

