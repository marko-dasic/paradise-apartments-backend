using Apartment.Application.UseCase.Commands.Category;
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

namespace Apartment.Implementation.UseCase.Commands.Ef.Category
{
    public class CreateCategoryCommand : EfBase, ICreateCategoryCommand
    {
        private CreateCategoryValidator validator;
        public CreateCategoryCommand(ApartmentContext context, IMapper mapper, CreateCategoryValidator validator) : base(context, mapper)
        {
            this.validator = validator;
        }

        public int Id => 6;

        public string Name => "Create Category - EF";

        public string Description =>"";

        public void Execute(CreateCategoryDto request)
        {
            validator.ValidateAndThrow(request);
            if (request.ParrentId == 0) request.ParrentId = null;
            var obj = new Domain.Entities.Category
            {
                Name = request.Name,
                ParrentId = request.ParrentId
            };
            Context.Categories.Add(obj);
            Context.SaveChanges();
        }
    }
}
