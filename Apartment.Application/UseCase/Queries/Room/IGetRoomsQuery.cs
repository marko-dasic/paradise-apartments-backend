using Apartment.Application.UseCase.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apartment.Application.UseCase.Queries.Room
{
    public interface IGetRoomsQuery : IQuery<object,IEnumerable<RoomDto>>
    {
    }
}
