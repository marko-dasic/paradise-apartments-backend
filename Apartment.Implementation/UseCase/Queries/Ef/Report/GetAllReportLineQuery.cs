using Apartment.Application.UseCase.DTO;
using Apartment.Application.UseCase.Queries.Report;
using Apartment.DataAccess;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apartment.Implementation.UseCase.Queries.Ef.Report
{
    public class GetAllReportLineQuery : EfBase, IGetAllReportLineQuery
    {
        public GetAllReportLineQuery(ApartmentContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public int Id => 15;

        public string Name => "Get all Report Line - Ef";

        public string Description => throw new NotImplementedException();

        public IEnumerable<ReportLineDto> Execute(object request = null)
        {
            var res = new List<ReportLineDto>();
            foreach (var x in Context.ReportLines.OrderByDescending(x => x.CreatedAt).ToList())
            {
                res.Add(Mapper.Map<ReportLineDto>(x));  
            }
            return res;
           
        }
    }
}
