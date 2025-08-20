using Apartment.Application.UseCase.DTO;
using Apartment.Application.UseCase.Queries.User;
using Apartment.DataAccess;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Apartment.Implementation.UseCase.Queries.Ef.User
{
    public class GetAllUsersQuery : EfBase, IGetAllUsersQuery
    {
        
        
        public GetAllUsersQuery(ApartmentContext context, IMapper mapper)
            :base(context,mapper)
        {
            

        }
        public int Id => 4;

        public string Name => "Get All User - EF";

        public string Description => "";

        public IEnumerable<UserDto> Execute(FilterPaginationUserDto request)
        {
            var res = Context.Users.Include(x => x.UseCases).AsQueryable();

            if (!string.IsNullOrEmpty(request.FullName))
            {
                res = res.Where(x => (x.FirstName + " " + x.LastName).Contains(request.FullName));
            }
            if(request.CreatedAtFrom < request.CreatedAtTo)
            {
                res = res.Where(x => x.CreatedAt > request.CreatedAtFrom && x.CreatedAt < request.CreatedAtTo);
            }

            if (request.PageNumber == 0 || request.PageSize == 0)
            {
                request.PageNumber = 1;
                request.PageSize = 10000;
            }

            res = res.OrderByDescending(x => x.CreatedAt);

            var pagination = res.Skip((request.PageNumber - 1) * request.PageSize)
            .Take(request.PageSize).ToList();

            var result =  Mapper.Map<List<UserDto>>(pagination);
                
           /* var result = pagination.Select(x=> new UserDto{
                Id = x.Id,
                FullName= x.FirstName + " " + x.LastName,
                Email = x.Email,
                Phone = x.Phone,
                UseCases = x.UseCases. Select(x=> new UseCaseDto { Id = x.Id, UseCaseId = x.UseCaseId })
            }).ToList();*/
           
            return result;
           
        }
    }
}
