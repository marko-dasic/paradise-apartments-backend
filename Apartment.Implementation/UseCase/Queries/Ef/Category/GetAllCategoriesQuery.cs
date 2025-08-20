using Apartment.Application.UseCase.DTO;
using Apartment.Application.UseCase.Queries.Category;
using Apartment.DataAccess;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apartment.Implementation.UseCase.Queries.Ef.Category
{
    public class GetAllCategoriesQuery : EfBase, IGetAllCategoriesQuery
    {
        public GetAllCategoriesQuery(ApartmentContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public int Id => 13;

        public string Name => "Get All Categories - Ef";

        public string Description => "";

        public IEnumerable<CategoryDto> Execute(object request = null)
        {
            var categories = Context.Categories.OrderByDescending(x=>x.CreatedAt).Select(x => new CategoryDto
            {
                Id = x.Id,
                Name = x.Name,
                ParrentId = x.ParrentId
            }).ToList();
            var childs = new List<CategoryDto>();
            foreach(var x in categories)
            {
                x.Childrends = Context.Categories.Where(y => y.ParrentId.Value == x.Id).Select(t=> new CategoryDto {
                    Name = x.Name,
                    ParrentId = x.ParrentId
                }).ToList();
            }

            return categories;

            
        }
    }
}
