using Apartment.Application.Exceptions;
using Apartment.Application.UseCase.Commands.User;
using Apartment.Application.UseCase.DTO;
using Apartment.DataAccess;
using Apartment.Domain;
using Apartment.Domain.Entities;
using Apartment.Implementation.Validators;
using AutoMapper;
using FluentAssertions.Numeric;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apartment.Implementation.UseCase.Commands.Ef.User
{
    public class UpdateUserCommand : EfBase, IUpdateUserCommand
    {
        private UpdateUserValidator validator;
        private readonly IUser user;
        public UpdateUserCommand(IUser user,UpdateUserValidator validator, ApartmentContext context, IMapper mapper) : base(context, mapper)
        {
            this.validator = validator;
            this.user = user;
        }

        public virtual int Id => 9;

        public string Name => "Update User - EF";

        public string Description => "";

        public void Execute(UpdateUserDto request)
        {
            if (request is null) throw new BadRequestException();
          
            if(request.Id == 0) 
                    request.Id = this.user.Id;
          
            validator.ValidateAndThrow(request);

            string hash = null;
            if(!string.IsNullOrEmpty(request.Password)) hash = BCrypt.Net.BCrypt.HashPassword(request.Password);

            var oldUser = Context.Users.Include(t=>t.UseCases).FirstOrDefault(t=>t.Id == request.Id);
            var numerator = 0;
            var useCasesIsChanged = false;

            if (request.UseCaseIds != null && request.UseCaseIds.Count() > 0)
            {
                foreach (var x in oldUser.UseCases)
                {
                    if (request.UseCaseIds.Any(t => t == x.UseCaseId)) numerator++;
                }
                if (!(numerator == oldUser.UseCases.Count() && numerator == request.UseCaseIds.Count())) useCasesIsChanged = true;

                if (useCasesIsChanged)
                {
                    oldUser.UseCases = new List<UserUseCase>();
                    foreach (var id in request.UseCaseIds)
                    {
                        oldUser.UseCases.Add(new UserUseCase
                        {
                            UseCaseId = id,
                            UserId = request.Id
                        });
                    }
                }
            }


            if (oldUser.FirstName != request.FirstName) oldUser.FirstName = request.FirstName;
            if ( oldUser.LastName != request.LastName) oldUser.LastName = request.LastName;
            if ( oldUser.Email != request.Email) oldUser.Email = request.Email;
            if (!string.IsNullOrEmpty(hash) && oldUser.Password != hash) oldUser.Password = hash;
            if (oldUser.Phone != request.Phone) oldUser.Phone = request.Phone;
            if (request.CityId > 0 && oldUser.CityId != request.CityId) oldUser.CityId = request.CityId;

            Context.SaveChanges();



        }
    }
}
