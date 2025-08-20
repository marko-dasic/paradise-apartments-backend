using Apartment.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Apartment.Application.UseCase.Commands.User;
using Apartment.Application.UseCase.DTO;
using Apartment.Implementation.Validators;
using FluentValidation;
using Apartment.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Apartment.Application.Mail;
using Apartment.Application.UseCase;

namespace Apartment.Implementation.UseCase.Commands.Ef.User
{
    public class CreateUserCommand : EfBase, ICreateUserCommand
    {
        CreateUserValidator validator;
        IEmailSend emailSend;
        
        public CreateUserCommand(ApartmentContext context, CreateUserValidator validator, IMapper mapper, IEmailSend emailSend) : base(context,mapper)
        {
            this.validator = validator;
            this.emailSend = emailSend;
        }

        public int Id => 2;

        public string Name => "Create User - EF";

        public string Description => "Create User with EntityFrameWork";

        public void Execute(CreateUserDto request)
        {
            validator.ValidateAndThrow(request);

            var hash = BCrypt.Net.BCrypt.HashPassword(request.Password);

            var guid = Guid.NewGuid().ToString();
            var obj = new Domain.Entities.User
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                Password = hash,
                Phone = request.Phone,
                UseCases = new List<UserUseCase>(),
                ActivationCode = guid
            };

            var defaultsUseCases = new List<UserUseCase>
                {
                    new UserUseCase {UseCaseId = 2},
                    new UserUseCase {UseCaseId = 11},
                    new UserUseCase {UseCaseId = 12},
                    new UserUseCase {UseCaseId = 13},
                    new UserUseCase {UseCaseId = 14},
                    new UserUseCase {UseCaseId = 15},
                    new UserUseCase {UseCaseId = 16},
                    new UserUseCase {UseCaseId = 17},
                    new UserUseCase {UseCaseId = 18},
                    new UserUseCase {UseCaseId = 19},
                    new UserUseCase {UseCaseId = 20},
                    new UserUseCase {UseCaseId = 50},
                    new UserUseCase {UseCaseId = 51},
                    new UserUseCase {UseCaseId = 52},
                    new UserUseCase {UseCaseId = 53},
                    new UserUseCase {UseCaseId = 54},
                    new UserUseCase {UseCaseId = 55},
                    new UserUseCase {UseCaseId = 56},
                    new UserUseCase {UseCaseId = 57},
                    new UserUseCase {UseCaseId = 58},
                    new UserUseCase {UseCaseId = 59},
                    new UserUseCase {UseCaseId = 60},
                    new UserUseCase {UseCaseId = 61},
                    new UserUseCase {UseCaseId = 62},
                    new UserUseCase {UseCaseId = 63},
                    new UserUseCase {UseCaseId = 64},
                    new UserUseCase {UseCaseId = 65},
                    new UserUseCase {UseCaseId = 66},
                    new UserUseCase {UseCaseId = 67},
                    new UserUseCase {UseCaseId = 68},
                    new UserUseCase {UseCaseId = 69},

                };

            
            foreach(var useCase in defaultsUseCases){
                obj.UseCases.Add(useCase);
            }

            

            Context.Users.Add(obj);

            emailSend.Send(new MailDto
            {
                To = request.Email,
                Title = "Usepsno ste se registrovali",
                Message = $"{request.FirstName} {request.LastName}  Dobro dosli na ansu platformu, nasi call centar operateri su vam dostupni 24h ukoliko imate bilo kakvih pitanja. Potrebno je jos samo da aktivirate vas nalog. To mozete uciniti klikom na link <a href='http://localhost:4200/login/{guid}'>AKTIVIRAJ NALOG</a>"
            }); ;

            Context.SaveChanges();


        }
    }
}
