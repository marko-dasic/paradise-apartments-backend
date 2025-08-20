using Apartment.Application.Exceptions;
using Apartment.Application.UseCase.Commands.UseCase;
using Apartment.Application.UseCase.DTO;
using Apartment.DataAccess;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apartment.Implementation.UseCase.Commands.Ef.UseCase
{
    public class ActivateUser : EfBase, IActivateUser
    {
        public ActivateUser(ApartmentContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public int Id => 60 ;

        public string Name => "Activate user after his registration - EF";

        public string Description => "";

        public void Execute(ActivateLinkDto request)
        {
            var code = request.Code;
            if (string.IsNullOrEmpty(code)) throw new BadRequestException();
            var obj = Context.Users.Where(x => !x.IsActivated && x.ActivationCode == code).FirstOrDefault();
            if (obj == null) throw new EntityNotFoundException("user with activation code" + code, 0);
            obj.IsActivated = true;
            Context.SaveChanges();
        }
    }
}
