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
    public class AddPriceForApartmentValidator : AbstractValidator<PriceDto>
    {
        public AddPriceForApartmentValidator(ApartmentContext context)
        {

            RuleFor(x => x.ApartmentId)
                .Cascade(CascadeMode.Stop)
                .Must(x => x== 0  || context.Apartments.Any(y => y.Id == x)).WithMessage("Apartman sa Id: {PropertyValue} ne postoji");


            RuleFor(x => x.PricePerNight)
                .Cascade(CascadeMode.Stop)
                .Must(x => x > 0).WithMessage("Cena mora biti veca od 0");


            RuleFor(x => x.PriceOnHoliday)
               .Cascade(CascadeMode.Stop)
               .Must(x => x > 0).WithMessage("Vrednost cene za noc praznikom nije ispravna. Vrednost mora biti veca od 0");



        }
    }
    
}
