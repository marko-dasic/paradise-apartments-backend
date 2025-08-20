using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apartment.Application.Mail
{
    public class MailDto
    {
        public string To { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
    }
}
