using Apartment.Application.Mail;
using Apartment.Application.UseCase.Commands.Email;
using Apartment.Application.UseCase.DTO;
using Apartment.DataAccess;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apartment.Implementation.UseCase.Commands.Ef.Email
{
    public class SendEmailToAdminCommand : EfBase, ISendEmailToAdminCommand
    {
        IEmailSend emailSend;
        public SendEmailToAdminCommand(ApartmentContext context, IMapper mapper, IEmailSend emailSend) : base(context, mapper)
        {
            this.emailSend = emailSend;
        }

        public int Id => 20;

        public string Name => "Sending Email Message to All admins by anonimo or regular user - EF";

        public string Description => "";

        public void Execute(SendEmailDto request)
        {
            var adminsEmails = Context.Users.Where(x => x.UseCases.Any(y => y.UseCaseId == 1)).Select(x=>x.Email).ToList();

            foreach (var e in adminsEmails)
            {
                emailSend.Send(new MailDto
                {
                    To = e,
                    Title = "Poruka od korisnika aplikacije Lux Place.",
                    Message = "Ime i prezime: " + request.FullName + "\nEmail: " + request.Email + "\nBroji telfona: " + request.Phone + "\nPoruka: " + request.Message
                }); 
            }
        }
    }
}
