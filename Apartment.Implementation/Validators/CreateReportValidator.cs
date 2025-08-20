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
    public  class CreateReportValidator : AbstractValidator<CreateReportDto>
    {
        public CreateReportValidator(ApartmentContext context)
        {
       

            RuleFor(x => x.ApartmentId)
               .Cascade(CascadeMode.Stop)
               .Must(x => context.Apartments.Any(u => u.Id == x)).WithMessage("Apartman sa id:{PropertyValue} Ne postoji u bazi.");

            RuleFor(x => new {x.UserId, x.ApartmentId, x.ReportLineId})
               .Cascade(CascadeMode.Stop)
               .Must(x => !context.Reports.Any(u => u.UserId == x.UserId && u.ApartmentId == x.ApartmentId && u.ReportLineId == x.ReportLineId)).WithMessage("Korisnik je vec poslao report za ovaj apartman.");
            RuleFor(x => x.ReportLineId)
               .Cascade(CascadeMode.Stop)
               .Must(x => context.ReportLines.Any(u => u.Id == x)).WithMessage("Prosledjena je nepostojeca stavka reporta!");
            





        }
    
    }
}
