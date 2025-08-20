using Apartment.Application.UseCase.DTO;
using Apartment.DataAccess;
using FluentValidation;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apartment.Implementation.Validators
{
    public class CreateCategoryValidator : AbstractValidator<CreateCategoryDto>
    {
        public CreateCategoryValidator(ApartmentContext context)
        {
            RuleFor(x => x.Name)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Naziv je obavezan podatak.")
                .Must(x=> !context.Categories.Any(y=>y.Name == x)).WithMessage("Vec posotji kategorija sa datim imenom")
                .MinimumLength(3).WithMessage("Minimalan broj slova je 3.");
                
            RuleFor(x => x.ParrentId)
            .Cascade(CascadeMode.Stop)
                .Must(x => x == null || x ==0 || context.Categories.Any(u => u.Id == x.Value)).WithMessage("rotideljska kategorija ne postoji.");

          
        }
    }
}
