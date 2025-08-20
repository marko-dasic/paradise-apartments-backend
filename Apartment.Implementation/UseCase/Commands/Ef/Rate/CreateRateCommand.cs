using Apartment.Application.Exceptions;
using Apartment.Application.UseCase.Commands.Rate;
using Apartment.Application.UseCase.DTO;
using Apartment.DataAccess;
using Apartment.Domain;
using Apartment.Implementation.Validators;
using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apartment.Implementation.UseCase.Commands.Ef.Rate
{
    public class CreateRateCommand : EfBase, ICreateRateCommand
    {
        private CreateRateValidator validator;
        private IUser user;
        public CreateRateCommand(ApartmentContext context, IMapper mapper, [FromServices] CreateRateValidator validator, IUser user  ) : base(context, mapper)
        {
            this.validator = validator;
            this.user = user;
        }

        public int Id => 51;

        public string Name => "Create Rate on Apartment - EF";

        public string Description => "";

        public void Execute(CreateRateDto request)
        {
            if (request is null) throw new BadRequestException();
            request.UserId = user.Id;
            validator.ValidateAndThrow(request);
        
            //provera da li je korisnik vec uneo ocenu za trazeni apartman. Ukoliko jeste, ocena se azurira
            var oldUserRate = Context.Rates.Where(x => x.UserId == this.user.Id && x.ApartmentId == request.ApartmentId).FirstOrDefault();
            if (oldUserRate != null)
            {
                oldUserRate.Value = request.Value;
            }
            else
            {
                var obj = new Domain.Entities.Rate
                {
                    UserId = user.Id,
                    ApartmentId = request.ApartmentId,
                    Value = request.Value
                };
                Context.Rates.Add(obj);
            }
            Context.SaveChanges();

            
        }
    }
}
