using Microsoft.AspNetCore.Http;
using NSwag.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Apartment.Application.UseCase.DTO
{
    public class FileDto : BaseDto
    {
        public string Path { get; set; }
        [JsonIgnore]
        public string Alt { get; set; }
        [JsonIgnore]

        public string Extension { get; set; }
        [JsonIgnore]
        public double Size { get; set; }
    }
    
}
