using Apartment.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apartment.Application.UseCase.DTO
{
    public class CategoryDto : BaseDto
    {
        public string Name { get; set; }
        public int? ParrentId {  get; set; }
        public IEnumerable<CategoryDto> Childrends { get; set; }

    }
    public class CreateCategoryDto
    {
        public string Name { get; set; }
        public int? ParrentId { get; set; }
    }
}
