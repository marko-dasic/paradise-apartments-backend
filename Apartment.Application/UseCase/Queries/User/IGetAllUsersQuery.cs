using Apartment.Application.UseCase.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apartment.Application.UseCase.Queries.User
{
    public interface IGetAllUsersQuery : IQuery<FilterPaginationUserDto, IEnumerable<UserDto>>
    {
    }
}
