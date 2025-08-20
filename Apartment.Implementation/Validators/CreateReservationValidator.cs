using Apartment.Application.UseCase.DTO;
using Apartment.DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Apartment.Implementation.Validators
{
    public class CreateReservationValidator : AbstractValidator<CreateReservationDto>
    {
        public CreateReservationValidator(ApartmentContext context)
        {
            RuleFor(x => x.ApartmentId)
                .Cascade(CascadeMode.Stop)
                .Must(x => context.Apartments.Any(y => y.Id == x)).WithMessage("Apartman ne postoji");

            RuleFor(x => new { x.From, x.To })
              .Cascade(CascadeMode.Stop)
              .Must(x => x.From < x.To && x.From >= DateTime.UtcNow).WithMessage("Datumi su neispravne vrednosti");

            RuleFor(x => new { x.UserId, x.Phone })
              .Cascade(CascadeMode.Stop)
              .Must(x => (x.UserId != null || x.UserId.Value > 0) ||  Regex.IsMatch(x.Phone, "/^(\\+\\d{1,4}\\s?)?(\\d{2,3}\\s?)?\\d{3}\\s?\\d{3,4}$/")
              ).WithMessage("Podaci nisu validni");

            RuleFor(x => new { x.UserId, x.FullName})
              .Cascade(CascadeMode.Stop)
              .Must(x => (x.UserId != null || x.UserId.Value > 0) || !string.IsNullOrEmpty(x.FullName)
              ).WithMessage("Podaci nisu validni");

            RuleFor(x => x.NumPerson)
              .Cascade(CascadeMode.Stop)
              .Must(x => x > 0)
              .WithMessage("Broj osoba mora biti pozitivan broj!");

            RuleFor(x => new { x.ApartmentId, x.From, x.To })
                .Cascade(CascadeMode.Stop)
                .Must(x => !context.Reservations.Any() || !context.Reservations.Any(y => y.ApartmentId == x.ApartmentId
                && x.From < y.To &&
            x.To > y.From))
                .WithMessage("Apartman je zauzet u trazenom terminu");


        }
    }
}
