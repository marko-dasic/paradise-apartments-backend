using Apartment.Application.UseCase.DTO;
using Apartment.Application.UseCase.Queries.City;
using Apartment.DataAccess;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apartment.Implementation.UseCase.Queries.Ef.City
{
    public class GetAllCityQuery : EfBase, IGetAllCityQuery
    {
        public GetAllCityQuery(ApartmentContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public int Id => 14;

        public string Name => "Get All Cities - EF";

        public string Description => "";

        public IEnumerable<CityDto> Execute(object request = null)
        {
            var res = Context.Cities.OrderByDescending(x=> x.CreatedAt).Select(x => new CityDto
            {
                Id= x.Id,
                Name = x.Name
            }).ToList();
            return res;
        }
    }
}
