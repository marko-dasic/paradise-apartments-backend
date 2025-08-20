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
    public class CreateCommentValidator : AbstractValidator<CreateCommentDto>
    {
        public CreateCommentValidator(ApartmentContext context)
        {

            RuleFor(x => x.ParrentId)
                .Cascade(CascadeMode.Stop)
                .Must(x => x == null || x == 0 || context.Comments.Any(y => y.Id == x)).WithMessage("Komentar na koji zelite da odgovorite vise ne postoji")
                .Must(x => x == null || x==0 || context.Comments.Any(y => y.Id == x && y.ParrentId == null)).WithMessage("Nije moguce odgovoriti na odgovor komentara");

            RuleFor(x => x.ApartmentId)
                .Cascade(CascadeMode.Stop)
                .Must(x => context.Apartments.Any(y => y.Id == x)).WithMessage("Apartman na koji zelite da ostavite komentar vise ne postoji");


            RuleFor(x => x.Text)
               .Cascade(CascadeMode.Stop)
               .NotEmpty().WithMessage("Text je obavezan podatak.")
               .MinimumLength(3).WithMessage("Minimalan broj slova je 3.");



        }
    }
}
