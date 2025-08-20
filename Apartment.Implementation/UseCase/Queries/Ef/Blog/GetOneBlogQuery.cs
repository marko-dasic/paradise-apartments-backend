using Apartment.Application.UseCase.DTO;
using Apartment.Application.UseCase.Queries.Blogs;
using Apartment.DataAccess;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apartment.Implementation.UseCase.Queries.Ef.Category
{
    public class GetOneBlogQuery : EfBase, IGetOneBlogQuery
    {
        public GetOneBlogQuery(ApartmentContext context) : base(context,null)
        {
        }

        public int Id => 13;

        public string Name => "Get One Blogs - Ef";

        public string Description => "";

        public BlogDto Execute(int request)
        {
            return Context.Blogs.OrderByDescending(x=>x.CreatedAt).Where(x=>x.Id == request).Select(x => new BlogDto
            {
                Id = x.Id,
                Title = x.Title,
                Content = x.Content,
                WorkTime = x.WorkTime,
                GoogleMap = x.GoogleMap,
                Adress = x.Adress,
                Path = x.File.Path,
                Alt = x.File.Alt,
            }).FirstOrDefault();
        }
    }
}
