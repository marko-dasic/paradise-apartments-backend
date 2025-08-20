using Apartment.Application.Exceptions;
using Apartment.Application.UseCase;
using Apartment.Application.UseCase.DTO;
using Apartment.Application.UseCase.Queries.User;
using Apartment.DataAccess;
using Apartment.Implementation.Mapper;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apartment.Implementation.UseCase.Queries.Queries.User
{
    public class GetOneUserQuery : EfBase,IGetOneUserQuery
    {
        
        public GetOneUserQuery(ApartmentContext context, IMapper mapper)
            :base(context, mapper)
        {
            
        }
        public virtual int Id => 3;

        public string Name => "Get specific user - EF";

        public string Description => "";

        public UserDto Execute(int request)
        {
            if (!Context.Users.Any(x => x.Id == request)) throw new BadRequestException();
            var user = Context.Users.FirstOrDefault(x => x.Id == request);
            Context.Entry(user).Collection(o => o.UseCases).Load();
            Context.Entry(user).Reference(o => o.City).Load();
            Context.Entry(user).Collection(o => o.Comments).Load();
            Context.Entry(user).Collection(o => o.Rates).Load();
            Context.Entry(user).Collection(o => o.Reports).Load();
            Context.Entry(user).Collection(o => o.Reservations).Load();

            if (user is null) throw new EntityNotFoundException(typeof(UserDto).Name,request);

            return  Mapper.Map<UserDto>(user);
        }
    }
}
