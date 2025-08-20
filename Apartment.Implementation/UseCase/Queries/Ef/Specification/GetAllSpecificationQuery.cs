using Apartment.Application.UseCase.DTO;
using Apartment.Application.UseCase.Queries.Specification;
using Apartment.DataAccess;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apartment.Implementation.UseCase.Queries.Ef.Specification
{
    public class GetAllSpecificationQuery : EfBase, IGetAllSpecificationQuery
    {
        public GetAllSpecificationQuery(ApartmentContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public int Id => 52;

        public string Name =>"Get All Specification - EF";

        public string Description => "";

        public IEnumerable<SpecificationDto> Execute(object request = null)
        {
            var objs = Context.Specifications.ToList();
            var res = new List<SpecificationDto>();

            foreach (var o in objs)
            {
                 res.Add(Mapper.Map<SpecificationDto>(o));

            }
            return res;
        }
    }
}
