using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Apartment.Application;
using Apartment.Application.Logging;

namespace Apartment.Implementation.Logging
{
    public class ConsoleLogging : IExceptionLoger
    {
        public Guid Id { get; } =  Guid.NewGuid();

        public void Log(Exception e)
        {
            Console.WriteLine("Doslo je do greske. Vas Id greske je: " + Id.ToString());
            Console.WriteLine("Vreme:" + DateTime.UtcNow);
            Console.WriteLine("Text Greske je: " +e.Message);


        }
    }
}
