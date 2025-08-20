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
    public class CreateApartmentSpecification : EfBase, ICreateApartmentSpecificatonCommand
    {
        private CreateApartmentSpecificationValidator validator;
        public CreateApartmentSpecification(ApartmentContext context, CreateApartmentSpecificationValidator  validator, IMapper mapper) : base(context, mapper)
        {
            this.validator = validator;
        }

        public int Id => 21;

        public string Name => "Adding Specification to Apartment - EF";

        public string Description => "";

        public void Execute(ApartmentSpecificationDto request)
        {
            if(request is null) throw new BadRequestException();
            validator.ValidateAndThrow(request);

            


            var obj = new Domain.Entities.ApartmentSpecification
            {
                ApartmentId = request.ApartmentId,
                SpecificationId = request.SpecificationId,
                Value = request.Value
            };
             var oldObject = Context.ApartmentSpecifications.Where(x => x.ApartmentId == request.ApartmentId
            && x.SpecificationId == request.SpecificationId).ToList();

            if(oldObject != null && oldObject.Count > 0) Context.ApartmentSpecifications.RemoveRange(oldObject);
            
            Context.ApartmentSpecifications.Add(obj);
            Context.SaveChanges();
        }
    }
}
