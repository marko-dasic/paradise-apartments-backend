using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Apartment.Application.UseCase.DTO
{
    public class AddImagesDto 
    {
        public int ApartmentId { get; set; }

        [JsonIgnore]
        public IEnumerable<int> FilesId { get; set; }   
        public IEnumerable<string> Files{ get; set; }
    }
}
