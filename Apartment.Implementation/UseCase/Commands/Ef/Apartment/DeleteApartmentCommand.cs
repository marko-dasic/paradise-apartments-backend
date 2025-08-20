using Apartment.Application.Calendar;
using Apartment.Application.Exceptions;
using Apartment.Application.UseCase.Commands.Apartment;
using Apartment.DataAccess;
using Apartment.Implementation.UseCase.Calendar;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apartment.Implementation.UseCase.Commands.Ef.Apartment
{
    public class DeleteApartmentCommand : EfBase, IDeleteApartmentCommand
    {
        public DeleteApartmentCommand(ApartmentContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public int Id => 25;

        public string Name => "Delete Apartment - Ef";

        public string Description => "";

        public void Execute(int request)
        {
            var apartmentToDelete =  Context.Apartments.Find(request);
            if(apartmentToDelete == null) { throw new EntityNotFoundException("apartment", request); }
            Context.Apartments.Remove(apartmentToDelete);
            Context.SaveChanges();
            
        }
    }
}
