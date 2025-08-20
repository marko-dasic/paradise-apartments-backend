using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Apartment.Application.UseCase.DTO
{
    public class RateDto : BaseDto
    {
        public int Value { get; set; }
        public int UserId { get; set; }

    }
    public class CreateRateDto
    {
        [JsonIgnore]
        public int UserId { get; set; }
        public int ApartmentId { get; set; }
        public int Value { get; set; }
    }
}
