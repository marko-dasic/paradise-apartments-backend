using Apartment.Application.UseCase.DTO;
using Apartment.Application.UseCase.Queries.Apartment;
using Apartment.DataAccess;
using Apartment.Domain;
using Apartment.Domain.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apartment.Implementation.UseCase.Queries.Ef.Apartment
{
    public class GetYourSelfReservationQuery : GetAllReservationQuery
    {
        private IUser user;
        public GetYourSelfReservationQuery(ApartmentContext context, IMapper mapper, IUser user) : base(context, mapper)
        {
            this.user = user;
        }

        public override int Id => 57;

        public override string Name => "Get Your Self Reservation - EF";

        public override string Description => "";

        protected override IQueryable<Reservation> AddAditionalFilter(IQueryable<Reservation> queryable)
        {
            queryable = queryable.Where(x => x.UserId == user.Id);
            return queryable;
        }




    }
}
