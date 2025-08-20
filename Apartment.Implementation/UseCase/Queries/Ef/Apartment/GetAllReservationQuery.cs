using Apartment.Application.UseCase.DTO;
using Apartment.Application.UseCase.Queries.Apartment;
using Apartment.DataAccess;
using Apartment.Domain.Entities;
using AutoMapper;
using Azure.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apartment.Implementation.UseCase.Queries.Ef.Apartment
{
    public class GetAllReservationQuery : EfBase, IGetAllReservationQuery
    {

        public GetAllReservationQuery(ApartmentContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public virtual int Id => 26;

        public virtual string Name => "Get all reservation - EF";

        public virtual string Description => "";

        public IEnumerable<ReservationDto> Execute(FilterPaginationReservationDto request)
        {
            var res = Context.Reservations.Include(x=>x.User).Include(x=>x.Apartment).AsQueryable();

            if(request.IsPaid != null)
            {
                res = res.Where(x => x.IsPaid == request.IsPaid.Value);
            }
            
            if(request.ApartmentId > 0)
            {
                res = res.Where(x => x.ApartmentId == request.ApartmentId);
            }

            if (!string.IsNullOrEmpty(request.ApartmentKeyWord))
            {
                res = res.Where(x => x.Apartment.Title.ToLower().Contains(request.ApartmentKeyWord.ToLower()));
            }

            if(request.CreatedAtFrom != null)
            {
                res = res.Where(x => x.CreatedAt > request.CreatedAtFrom);
            }

            if(request.CreatedAtTo != null)
            {
                res = res.Where(x => x.CreatedAt < request.CreatedAtTo);
            }

            if (request.PageNumber == 0 || request.PageSize == 0)
            {
                request.PageNumber = 1;
                request.PageSize = 10000;
            }

            res = AddAditionalFilter(res);
            res.OrderByDescending(x => x.From);
            var pagination = res.Skip((request.PageNumber - 1) * request.PageSize)
            .Take(request.PageSize).OrderByDescending(x=>x.From).ToList();

            var result = Mapper.Map<IEnumerable<ReservationDto>>(pagination);

            return result;
        }

        protected virtual IQueryable<Reservation> AddAditionalFilter(IQueryable<Reservation> queryable)
        {
            return queryable;
        }
    }
}
