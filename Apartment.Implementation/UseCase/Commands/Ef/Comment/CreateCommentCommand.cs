using Apartment.Application.Exceptions;
using Apartment.Application.UseCase.Commands.Comment;
using Apartment.Application.UseCase.DTO;
using Apartment.DataAccess;
using Apartment.Domain;
using Apartment.Implementation.Validators;
using AutoMapper;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apartment.Implementation.UseCase.Commands.Ef.Comment
{
    public class CreateCommentCommand : EfBase, ICreateCommentCommand
    {
        private CreateCommentValidator validator;
        private IUser user;
        public CreateCommentCommand(ApartmentContext context,CreateCommentValidator validator, IMapper mapper, IUser user) : base(context, mapper)
        {
            this.validator = validator;
            this.user = user;
        }

        public int Id => 50;

        public string Name => "Create Comment - EF";

        public string Description => "";

        public void Execute(CreateCommentDto request)
        {
            if(request is null) throw new BadRequestException();
            validator.ValidateAndThrow(request);
            if (request.ParrentId == 0) request.ParrentId = null;

            var Comment = new Domain.Entities.Comment
            {
                ParrentId = request.ParrentId,
                AppartmentId = request.ApartmentId,
                Text = request.Text,
                UserId = user.Id,
                CreatedAt = DateTime.Now
            };

            Context.Comments.Add(Comment);
            Context.SaveChanges();
            
        }
    }
}
