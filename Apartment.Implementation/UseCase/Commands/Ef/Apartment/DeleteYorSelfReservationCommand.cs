using Apartment.Application.Calendar;
using Apartment.Application.Exceptions;
using Apartment.Application.UseCase.Commands.Apartment;
using Apartment.DataAccess;
using Apartment.Domain;
using Apartment.Implementation.UseCase.Calendar;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Server.IIS.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apartment.Implementation.UseCase.Commands.Ef.Apartment
{
    public class DeleteYorSelfReservationCommand : EfBase, IDeleteYorSelfReservationCommand
    {
        private IUser user;
        private CalendarManager calendarManager;
        public DeleteYorSelfReservationCommand(ApartmentContext context,IUser user, IMapper mapper, ICalendarManager calendarManager) : base(context, mapper)
        {
            this.user = user;
            this.calendarManager = calendarManager as CalendarManager;
        }

        public int Id => 58;

        public string Name => "Delete reservation by owner reservation - EF";

        public string Description => "";

        public void Execute(int request)
        {
            var obj = Context.Reservations.Find(request);
            if(obj == null) throw new EntityNotFoundException("Reservation",request);
            if (obj.UserId == this.user.Id)
            {
                calendarManager.RemoveDates(obj.Apartment.LocalCalendar, obj.From, obj.To);
                Context.Reservations.Remove(obj);
                Context.SaveChanges();
            }
            else
            {
                throw new UnauthorizedAccessException();
            }
        }
    }
}
