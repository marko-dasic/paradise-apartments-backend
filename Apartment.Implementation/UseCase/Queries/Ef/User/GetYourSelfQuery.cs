using Apartment.DataAccess;
using Apartment.Implementation.UseCase.Queries.Queries.User;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apartment.Implementation.UseCase.Queries.Ef.User
{
    public class GetYourSelfQuery : GetOneUserQuery
    {
        public override int Id => 54;
        public GetYourSelfQuery(ApartmentContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
