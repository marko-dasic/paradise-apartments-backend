using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apartment.Application.UseCase
{
    public interface IUseCase
    {
        abstract int Id { get; }
        string Name { get; }
        string Description { get; }
    }
}
