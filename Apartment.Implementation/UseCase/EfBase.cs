using Apartment.DataAccess;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apartment.Implementation.UseCase
{
    public abstract class EfBase
    {
        protected ApartmentContext Context { get; set; }    
        protected IMapper Mapper { get; set; }
        protected EfBase(ApartmentContext context, IMapper mapper)
        {
            Context = context;
            Mapper = mapper;
        }  
    }
}
