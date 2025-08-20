using NSwag.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Apartment.Application.UseCase.DTO
{
    public class SpecificationDto 
    {
        [SwaggerIgnore]
        [Obsolete]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Icon { get; set; }
    }
}
