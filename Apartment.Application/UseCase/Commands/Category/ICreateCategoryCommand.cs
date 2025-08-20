using Apartment.Application.UseCase.DTO;
using Apartment.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apartment.Application.UseCase.Commands.Category
{
    public interface ICreateCategoryCommand : ICommand<CreateCategoryDto>
    {
    }
}
