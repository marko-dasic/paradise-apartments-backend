using Apartment.Application.UseCase.DTO;
using Apartment.DataAccess;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apartment.Implementation.Validators
{
    public class CreateUserValidator : AbstractValidator<CreateUserDto>
    {
        public CreateUserValidator(ApartmentContext context) 
        {
            RuleFor(x => x.FirstName)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Naziv je obavezan podatak.")
                .MinimumLength(3).WithMessage("Minimalan broj slova je 3.")
                .Matches(@"^[A-Z][a-z]{2,}(\s[A-Z][a-z]{2,})?$").WithMessage("Ime nije u ispravnom formatu");

            RuleFor(x => x.LastName)
               .Cascade(CascadeMode.Stop)
               .NotEmpty().WithMessage("Naziv je obavezan podatak.")
               .MinimumLength(3).WithMessage("Minimalan broj slova je 3.")
               .Matches(@"^[A-Z][a-z]{2,}(\s[A-Z][a-z]{2,})?$").WithMessage("Ime nije u ispravnom formatu");

            RuleFor(x => x.Email)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Email je obavezan podatak.")
                .EmailAddress().WithMessage("Email nije ispravnog formata.")
                .Must(x =>  !context.Users.Any(u => u.Email == x && u.DeletedAt == null)).WithMessage("Email adresa {PropertyValue} je već u upotrebi.");

            RuleFor(x => x.Phone)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Broji telefona je obavezan podatak.")
                .Matches(@"^[0-9 +]{6,15}$").WithMessage("Broji telefona nije ispravnog formata.")
                .Must(x => !context.Users.Any(u => u.Phone == x && u.DeletedAt != null)).WithMessage("Broji telefona {PropertyValue} je već u upotrebi.");

            RuleFor(x => x.Password).NotEmpty().WithMessage("Lozinka je obavezan podatak.")
               .Matches(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)[a-zA-Z\d]{8,}$")
               .WithMessage("Lozinka mora da sadrži minimalno 8 karaktera, jedno veliko, jedno malo slovo, broj i ne sme sadrzati specijalni karakter.");
        }
    }
}
