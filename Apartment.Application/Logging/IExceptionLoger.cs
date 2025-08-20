using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apartment.Application.Logging
{
    public interface IExceptionLoger
    {
        public Guid Id { get;  }
        void Log(Exception e);
    }
}
