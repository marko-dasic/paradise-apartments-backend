using Apartment.Application.Exceptions;
using Apartment.Application.UseCase.Commands.Report;
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

namespace Apartment.Implementation.UseCase.Commands.Ef.Report
{
    public class CreateReportCommand : EfBase, ICreateReportCommand
    {
        private IUser user;
        private CreateReportValidator validator;
        public CreateReportCommand(IUser user ,CreateReportValidator validator, ApartmentContext context, IMapper mapper) : base(context, mapper)
        {
            this.validator = validator;
            this.user = user;
        }

        public int Id => 16;

        public string Name => "Create Report - Ef";

        public string Description => "";

        public void Execute(CreateReportDto request)
        {
            request.UserId = user.Id;
            if (request is null) throw new BadRequestException();
            validator.ValidateAndThrow(request);

            Context.Reports.Add(new Domain.Entities.Report
            {
                ApartmentId = request.ApartmentId,
                UserId = user.Id,
                ReportLineId = request.ReportLineId,
                Text = request.Text
            });
            Context.SaveChanges();
           
        }
    }
}
