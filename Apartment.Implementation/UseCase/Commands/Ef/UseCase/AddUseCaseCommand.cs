using Apartment.Application.Exceptions;
using Apartment.Application.UseCase.Commands.UseCase;
using Apartment.Application.UseCase.DTO;
using Apartment.DataAccess;
using Apartment.Domain.Entities;
using Apartment.Implementation.Validators;
using AutoMapper;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apartment.Implementation.UseCase.Commands.Ef.UseCase
{
    public class AddUseCaseCommand : EfBase, IAddUseCaseCommand
    { 
        private AddUseCaseValidator validator;
        public AddUseCaseCommand(ApartmentContext context, IMapper mapper ,AddUseCaseValidator validator)
            :base(context, mapper)
        {
            this.validator = validator;
        }
        public int Id => 1;

        public string Name => "Adding Use Case for user - EF";

        public string Description => "";

        public void Execute(AddUseCaseDto request)
        {
            validator.ValidateAndThrow(request);
            
            var user = Context.Users.FirstOrDefault(x=>x.Id == request.UserId);
            Context.Entry(user).Collection(o => o.UseCases).Load();
               
            foreach(var x in request.UseCaseIds)
            {
                user.UseCases.Add(new UserUseCase
                {
                    UserId = request.UserId,
                    UseCaseId = x
                });

            }
            
            Context.SaveChanges();
            
            
        }
    }
}
