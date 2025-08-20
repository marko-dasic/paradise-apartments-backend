using Apartment.Application.Exceptions;
using Apartment.Application.UseCase.Commands.Apartment;
using Apartment.DataAccess;
using Apartment.Domain.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apartment.Implementation.UseCase.Commands.Ef.Apartment
{
    public class MarkPaidReservationCommand : EfBase, IMarkPaidReservationCommand
    {
        public MarkPaidReservationCommand(ApartmentContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public int Id => 30;

        public string Name => "Mark Reservaion Paid or Inverse - EF";

        public string Description => "";

        public void Execute(int request)
        {
            var query = Context.Reservations.Where(x => x.Id == request).AsQueryable();
            query = AddUserValidationUseCase(query);
            var obj = query.FirstOrDefault();
            if (obj == null) throw new BadRequestException();
            obj.IsPaid = !obj.IsPaid;
            Context.SaveChanges();
        }

        protected virtual IQueryable<Reservation> AddUserValidationUseCase(IQueryable<Reservation> query)
        {
            return query;
        }
    }
}
