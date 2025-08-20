using NSwag.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Apartment.Application.UseCase.DTO
{
    public class ApartmentSpecificationDto
    {
        [JsonIgnore]
        public int Id { get; set; }
        
        public int ApartmentId { get; set; }
        public string Icon { get; set; }
        public string Specification { get; set; }
        public int SpecificationId { get; set; }

        public string Value { get; set; }
    }
}
