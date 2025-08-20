using Apartment.Application.Calendar;
using Apartment.Application.Exceptions;
using Apartment.Application.UseCase.Commands.Apartment;
using Apartment.DataAccess;
using Apartment.Implementation.UseCase.Calendar;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Apartment.Implementation.UseCase.Commands.Ef.Apartment
{
    public class DeleteReservationCommand : EfBase, IDeleteReservationCommand
    {
        private CalendarManager calendarManager;
        public DeleteReservationCommand(ApartmentContext context, IMapper mapper, ICalendarManager calendarManager) : base(context, mapper)
        {
            this.calendarManager = calendarManager as CalendarManager;
        }

        public virtual int Id => 28;

        public string Name => "Administrator delete reservation - Ef";

        public string Description => "";

        public void Execute(int request)
        {
            var reservationToBeDelete = Context.Reservations.Include(x=>x.Apartment).Where(x=>x.Id == request).FirstOrDefault();
            if (reservationToBeDelete == null) throw new EntityNotFoundException("Reservation",request);
            Context.Reservations.Remove(reservationToBeDelete);
            calendarManager.RemoveDates(reservationToBeDelete.Apartment.LocalCalendar, reservationToBeDelete.From, reservationToBeDelete.To);
            Context.SaveChanges();
        }
    }
}
