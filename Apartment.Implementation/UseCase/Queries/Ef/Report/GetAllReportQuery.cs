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
    public class GetAllReportQuery : EfBase, IGetAllReportQuery
    {
        public GetAllReportQuery(ApartmentContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public int Id => 8;

        public string Name => "Get All Report - EF";

        public string Description => "";

        public IEnumerable<GetReportDto> Execute(object request = null)
        {
            var res = new List<GetReportDto>();
            var all = Context.Reports.OrderByDescending(x=>x.CreatedAt).ToList();
            foreach(var x in Context.Reports.ToList())
            {
                res.Add(Mapper.Map<GetReportDto>(x));
            }
            var t = all;
            return res;
        }
    }
}
