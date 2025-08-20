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
    public class UpdateApartmentValidator : AbstractValidator<UpdateApartmentDto>
    {
        public UpdateApartmentValidator(ApartmentContext context)
        {
            RuleFor(x => x.Id)
                .Cascade(CascadeMode.Stop)
                .Must(x=> context.Apartments.Any(x=> x.Id == x.Id)).WithMessage("Apartman koji pokusavate da azurirate ne postoji");

            RuleFor(x => x.Title)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Naslov je obavezan podatak.")
                .MinimumLength(3).WithMessage("Minimalan broj slova je 3.");

            RuleFor(x => x.Description)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Opis je obavezan podatak.")
                .MinimumLength(3).WithMessage("Minimalan broj slova je 3.");

            RuleFor(x => x.CategoryId)
            .Cascade(CascadeMode.Stop)
                .Must(x => context.Categories.Any(c=>c.Id == x )).WithMessage("Kategorija {PropertyValue} ne postoji.");

            RuleFor(x => x.CityId)
            .Cascade(CascadeMode.Stop)
                .Must(x => context.Cities.Any(c => c.Id == x)).WithMessage("Uneti grad ne postoji.");

            RuleFor(x => x.FileId)
           .Cascade(CascadeMode.Stop)
               .Must(x => x==0 || x == null || context.Files.Any(c => c.Id == x)).WithMessage("Fajl {PropertyValue} ne postoji.");

            RuleFor(x => x.ImagesIds)
           .Cascade(CascadeMode.Stop)
               .Must(x => x==null ||  x.Count() == 0 || x.FirstOrDefault() == 0 || context.Images.Any(c => x.Any(u=>u == c.Id))).WithMessage("Slike sa zadatim id-em {PropertyValue} ne postoji.");


            RuleFor(x => x.Price)
            .Cascade(CascadeMode.Stop)
                .Must(x => x.PriceOnHoliday > 0 && x.PricePerNight > 0).WithMessage("Regularna cena ne sme biti negativna vrednost.");


            RuleFor(x => x.Priority)
            .Cascade(CascadeMode.Stop)
                .Must(x => x>0).WithMessage("Prioritet ne moze biti negativna vrednost.");

            RuleFor(x => x.Surface)
            .Cascade(CascadeMode.Stop)
                .Must(x => x > 0).WithMessage("Povrsina ne moze biti negativna vrednost.");

        }
    }
}
