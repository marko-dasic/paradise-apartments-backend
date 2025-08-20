using Apartment.Application.UseCase.Commands.City;
using Apartment.Application.UseCase.DTO;
using Apartment.DataAccess;
using Apartment.Implementation.Validators;
using AutoMapper;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apartment.Implementation.UseCase.Commands.Ef.City
{
    public class CreateCityCommand : EfBase, ICreateCityCommand
    {
        private CreateCtiyValidator validator;
        public CreateCityCommand(ApartmentContext context, IMapper mapper, CreateCtiyValidator validator) : base(context, mapper)
        {
            this.validator = validator;
        }

        public int Id => 7;

        public string Name => "Create City - Ef";

        public string Description => "";

        public void Execute(CityDto request)
        {
            validator.ValidateAndThrow(request);
            var obj = new Domain.Entities.City { Name = request.Name };
            Context.Cities.Add(obj);
            Context.SaveChanges();
        }
    }
}
