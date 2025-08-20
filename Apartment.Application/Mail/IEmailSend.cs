using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apartment.Application.Mail
{
    public interface IEmailSend 
    {
        void Send(MailDto message);
    }
}
