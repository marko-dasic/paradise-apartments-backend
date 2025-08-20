using Apartment.Application.Exceptions;
using Apartment.Application.UseCase.Commands.Specification;
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

namespace Apartment.Implementation.UseCase.Commands.Ef.Specification
{
    public class CreateSpecificationCommand : EfBase, ICreateSpecificationCommand
    {
        private SpecificationValidator validator;
        public CreateSpecificationCommand(ApartmentContext context, SpecificationValidator validator, IMapper mapper) : base(context, mapper)
        {
            this.validator = validator;
        }

        public int Id => 22;

        public string Name => "Create Specification Line - EF";

        public string Description => "";

        public void Execute(SpecificationDto request)
        {
            if (request is null) throw new BadRequestException();
            validator.ValidateAndThrow(request);
            var obj = new Domain.Entities.Specification
            {
                Name = request.Name,
                MyIcon = request.Icon
            };
            Context.Specifications.Add(obj);
            Context.SaveChanges();
        }
    }
}
