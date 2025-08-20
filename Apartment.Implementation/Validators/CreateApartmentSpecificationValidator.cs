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
    public class CreateApartmentSpecificationValidator : AbstractValidator<ApartmentSpecificationDto>
    {
        public CreateApartmentSpecificationValidator(ApartmentContext context)
        {

            RuleFor(x => x.SpecificationId)
                .Cascade(CascadeMode.Stop)
                .Must(x => context.Specifications.Any(y => y.Id == x)).WithMessage("Specifikacija {PropertyValue} ne postoji");
            

            RuleFor(x => x.ApartmentId)
                .Cascade(CascadeMode.Stop)
                .Must(x => context.Apartments.Any(y => y.Id == x)).WithMessage("Apartman {PropertyValue} ne postoji");


        }
    }
}
