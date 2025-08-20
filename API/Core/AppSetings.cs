using System.Web;

namespace API.Core
{
 

    public class AppSetings
    {
        public string ConnectionString { get; set; }
        public JwtSettings JwtSettings { get; set; }
        public MailOptions MailOptions { get; set; } 
    }

    public class MailOptions
    {
        public string FromEmail { get; set; }
        public string Password { get; set; }
        public int Port { get; set; }
        public string Host { get; set; }

    }

}


