using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apartment.Application.UseCase
{
    public interface IQuery<TRequest, TResult> : IUseCase
    {
        TResult Execute(TRequest request);
    }
}
