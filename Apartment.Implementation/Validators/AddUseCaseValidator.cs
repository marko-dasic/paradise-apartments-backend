using Apartment.Application.UseCase.DTO;
using Apartment.DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apartment.Implementation.Validators
{
    public class AddUseCaseValidator : AbstractValidator<AddUseCaseDto>
    {
        public AddUseCaseValidator(ApartmentContext context)
        {
            RuleFor(x => new { x.UserId, x.UseCaseIds })
                .Cascade(CascadeMode.Stop)
                .Must(x => context.Users.Any(u => u.Id == x.UserId)).WithMessage("Korisnik sa zadatim Id-em ne postoji .")
                .Must(x => !(context.UserUseCase.Any(y=>y.UserId == x.UserId && x.UseCaseIds.Contains(y.UseCaseId))))
                .WithMessage("Korisnik vec poseduje zadati UseCaseId.");


        }
    }
}
