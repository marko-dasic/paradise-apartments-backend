using Apartment.Application.Exceptions;
using Apartment.Application.UseCase.Commands.Report;
using Apartment.Application.UseCase.DTO;
using Apartment.DataAccess;
using Apartment.Domain.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apartment.Implementation.UseCase.Commands.Ef.Report
{
    public class CreateReportLineCommand :EfBase, ICreateReportLineCommand
    {
        public CreateReportLineCommand(ApartmentContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public int Id => 24;

        public string Name => "Create Report line - Ef";

        public string Description => "";

        public void Execute(CreateReportLineDto request)
        {
            if(request == null || string.IsNullOrEmpty(request.Name) || request.Name.Length < 3) 
            {
                throw new BadRequestException();
            }

            Context.ReportLines.Add(new ReportLine
            {
                Name = request.Name
            });
            Context.SaveChanges();
        }
    }
}
