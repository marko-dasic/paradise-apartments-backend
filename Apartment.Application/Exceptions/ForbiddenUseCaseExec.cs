using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apartment.Application.Exceptions
{
    public class ForbiddenUseCaseExec : Exception
    {
        public ForbiddenUseCaseExec(string useCase, string user) :
            base($"User {user} has tried to execute {useCase} without being authorized to do so.")
        {

        }
    }
}
