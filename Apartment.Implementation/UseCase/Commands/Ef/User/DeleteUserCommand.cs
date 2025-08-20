using Apartment.Application.Exceptions;
using Apartment.Application.UseCase.Commands.User;
using Apartment.DataAccess;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apartment.Implementation.UseCase.Commands.Ef.User
{
    public class DeleteUsetCommand : EfBase, IDeleteUserCommand
    {
        public DeleteUsetCommand(ApartmentContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public int Id => 27;

        public string Name => "Deleting User - Ef";

        public string Description => "";

        public void Execute(int request)
        {
            var userToBeDelete = Context.Users.Find(request);
            if (userToBeDelete == null) { throw new EntityNotFoundException("user", request); }
            Context.Users.Remove(userToBeDelete);
            Context.SaveChanges();
        }
    }
}
