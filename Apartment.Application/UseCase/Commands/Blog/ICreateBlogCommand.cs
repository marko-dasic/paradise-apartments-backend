using Apartment.Application.UseCase.DTO;

namespace Apartment.Application.UseCase.Commands.Blog
{
    public interface ICreateBlogCommand : ICommand<CreateBlogDto>
    {
    }
}
