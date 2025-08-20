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
    public class CreateCtiyValidator : AbstractValidator<CityDto>
    {
        public CreateCtiyValidator(ApartmentContext context)
        {
            RuleFor(x => x.Name)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Naziv je obavezan podatak.")
                .MinimumLength(3).WithMessage("Minimalan broj slova je 3.")
                .Must(x => !context.Cities.Any(y => y.Name == x)).WithMessage("Vec posotji grad sa datim imenom");



        }
    }
}
