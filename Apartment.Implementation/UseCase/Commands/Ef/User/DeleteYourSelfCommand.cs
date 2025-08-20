using Apartment.Application.Exceptions;
using Apartment.Application.UseCase.Commands.User;
using Apartment.DataAccess;
using Apartment.Domain;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apartment.Implementation.UseCase.Commands.Ef.User
{
    public class DeleteYourSelfCommand : EfBase, IDeleteYourSelfCommand
    {
        IUser user;
        public DeleteYourSelfCommand(ApartmentContext context, IMapper mapper, IUser user) : base(context, mapper)
        {
            this.user = user;   
        }

        public int Id => 53;

        public string Name => "User delete his account - Ef";

        public string Description => "User can delete onlu his account!";

        public void Execute(object request = null)
        {
            var userToBeDelete = Context.Users.Find(user.Id);
            if(userToBeDelete == null) 
            {
                throw new EntityNotFoundException("User", user.Id);
            }
          

            Context.Users.Remove(userToBeDelete);
            Context.SaveChanges();

        
        }
    }
}
