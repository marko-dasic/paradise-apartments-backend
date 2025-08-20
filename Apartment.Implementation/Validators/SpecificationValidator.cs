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
    public class SpecificationValidator : AbstractValidator<SpecificationDto>
    {
        public SpecificationValidator(ApartmentContext context)
        {
            RuleFor(x => x.Name)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Naziv je obavezan podatak.")
                .Must(x => !context.Specifications.Any(y=>y.Name == x)).WithMessage("Vec postoji specifikacija sa istim nazivom")
                .MinimumLength(3).WithMessage("Minimalan broj slova je 3.");




        }
    }
}
