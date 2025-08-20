using Apartment.DataAccess;
using Apartment.Domain;
using Apartment.Implementation.Validators;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apartment.Implementation.UseCase.Commands.Ef.User
{
    public class UpdateYourSelfCommand : UpdateUserCommand
    {
        public override int Id => 55;
        public UpdateYourSelfCommand(IUser user, UpdateUserValidator validator, ApartmentContext context, IMapper mapper) : base(user, validator, context, mapper)
        {
        }
    }
}
