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
    public class UpdateUserValidator : AbstractValidator<UpdateUserDto>
    {
        public UpdateUserValidator(ApartmentContext context)
        {
            RuleFor(x => x.Id)
               .Cascade(CascadeMode.Stop)
               .Must(x=> context.Users.Any(y=>y.Id == x)).WithMessage("Korisnik vise ne postoji");

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
                .EmailAddress().WithMessage("Email nije ispravnog formata.");



            RuleFor(x => x.Phone)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Broji telefona je obavezan podatak.")
                .Matches(@"^[0-9\s +]{6,15}$").WithMessage("Broji telefona nije ispravnog formata.");
               

            RuleFor(x => x.Password)
                .Cascade(CascadeMode.Stop)
                .Must(x =>  string.IsNullOrEmpty(x) || Regex.IsMatch(x, @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)[a-zA-Z\d]{8,}$", RegexOptions.None))
               .WithMessage("Lozinka mora da sadrži minimalno 8 karaktera, jedno veliko, jedno malo slovo, broj i ne sme sadrzati specijalni karakter.");

            RuleFor(x => x.CityId)
                .Cascade(CascadeMode.Stop)
                .Must(x => x == null || x == 0 || context.Cities.Any(y => y.Id == x)).WithMessage("Grad koji ste uneli ne posotji");

            RuleFor(x => new { x.Phone, x.Id })
                .Cascade(CascadeMode.Stop)
                .Must(x => context.Users.Where(y => y.Phone == x.Phone && y.Id != x.Id && y.DeletedAt == null).Count() == 0 ).WithMessage("Telefon  je vec u upotrebi od strane nekog drugog korisnika");

            RuleFor(x => new { x.Email, x.Id })
                .Cascade(CascadeMode.Stop)
                .Must(x => !context.Users.Any(y => y.Email == x.Email && y.Id != x.Id && y.DeletedAt == null)).WithMessage("Email  je vec u upotrebi od strane nekog drugog korisnika");




        }

    }
}
