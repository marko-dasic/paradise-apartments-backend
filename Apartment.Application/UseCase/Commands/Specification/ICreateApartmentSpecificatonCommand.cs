using Apartment.Application.UseCase.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Apartment.Application.UseCase.Commands.Specification
{
    public interface ICreateApartmentSpecificatonCommand : ICommand<ApartmentSpecificationDto>
    {
    }
}
