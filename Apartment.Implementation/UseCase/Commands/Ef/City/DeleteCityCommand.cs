using Apartment.Application.Exceptions;
using Apartment.Application.UseCase.Commands.City;
using Apartment.DataAccess;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apartment.Implementation.UseCase.Commands.Ef.City
{
    public class DeleteCityCommand : EfBase, IDeleteCityCommand
    {
        public DeleteCityCommand(ApartmentContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public int Id => 71;

        public string Name => "Delete City - EF" ;

        public string Description => "";

        public void Execute(int request)
        {
            var obj = Context.Cities.Find(request);
            if (obj == null) throw new EntityNotFoundException("City", request);
            Context.Cities.Remove(obj);
            Context.SaveChanges();
        }
    }
}
