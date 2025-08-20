using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apartment.Application.Exceptions
{
    public class WrongFileExtensionsException : Exception
    {
        public  WrongFileExtensionsException(string message) : base(message) { }
    }
}
