using Apartment.Application.UseCase.DTO;
using Apartment.Application.UseCase.Queries.Room;
using Apartment.DataAccess;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apartment.Implementation.UseCase.Queries.Ef.Room
{
    public class GetRoomsQuery : EfBase, IGetRoomsQuery
    {
        public GetRoomsQuery(ApartmentContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public int Id => 14;

        public string Name => "Get All Number of Rooms";

        public string Description => "";

        public IEnumerable<RoomDto> Execute(object request)
        {
            return Context.Rooms.Select(x => new RoomDto
            {
                Id = x.Id,
                Value = x.Value
            }).ToList();
        }
    }
}
