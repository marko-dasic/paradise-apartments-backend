using System.Collections.Generic;
using Apartment.Application.UseCase.DTO;


namespace Apartment.Application.UseCase.Queries.Blogs
{
    public interface IGetAllBlogQuery : IQuery<object,IEnumerable<BlogDto>>
    {
    }
}
