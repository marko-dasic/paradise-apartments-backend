using Apartment.Application.UseCase.DTO;
using Apartment.Application.UseCase.Queries.Blogs;
using Apartment.DataAccess;
using AutoMapper;
using System;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apartment.Implementation.UseCase.Queries.Ef.Category
{
    public class GetAllBlogQuery : EfBase, IGetAllBlogQuery
    {
        HttpContextAccessor httpContextAccessor;
        public GetAllBlogQuery(ApartmentContext context,IHttpContextAccessor httpContextAccessor) : base(context,null)
        {
            this.httpContextAccessor = httpContextAccessor as HttpContextAccessor ;
        }

        public int Id => 13;

        public string Name => "Get All Blogs - Ef";

        public string Description => "";

        public IEnumerable<BlogDto> Execute(object request = null)
        {
            var serverDomainName = httpContextAccessor.HttpContext.Request;
            string filePath = $"{serverDomainName.Scheme}://{serverDomainName.Host}/api/uploads/";
            return Context.Blogs.OrderByDescending(x=>x.CreatedAt).Select(x => new BlogDto
            {
                Id = x.Id,
                Title = x.Title,
                Content = x.Content,
                WorkTime = x.WorkTime,
                GoogleMap = x.GoogleMap,
                Adress = x.Adress,
                Path = filePath + x.File.Path,
                Alt = x.File.Alt,
            }).ToList();
        }
    }
}
