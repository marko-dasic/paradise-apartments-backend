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
    public class CreateRateValidator : AbstractValidator<CreateRateDto>
    {
        public CreateRateValidator(ApartmentContext context)
        {
            RuleFor(x => x.UserId)
                .Cascade(CascadeMode.Stop)
                .Must(x => context.Users.Any(y => y.Id == x)).WithMessage("Nazalost nemate ovlascenje da biste ostavili ocenu");


            RuleFor(x => x.Value)
                .Cascade(CascadeMode.Stop)
                .Must(x=> x > 0 && x < 6 ).WithMessage("Neispravna vrednost ocene!");

            RuleFor(x => x.ApartmentId)
                .Cascade(CascadeMode.Stop)
                .Must(x => context.Apartments.Any(y => y.Id == x)).WithMessage("Apartman  koji zelite da ocenite vise ne postoji");


        }
    }
}