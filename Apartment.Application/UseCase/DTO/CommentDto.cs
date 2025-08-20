using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Apartment.Application.UseCase.DTO
{
    public class CommentDto : BaseDto
    {
        public int? ParrentId{ get; set; }
        public string Text { get; set; }
        public UserDto User { get; set; }
        public IEnumerable<CommentDto> Childs { get; set; }
        public DateTime? CreatedAt { get; set; }
    }
    public class CreateCommentDto
    {
        public int ApartmentId { get; set; }
        public int? ParrentId { get; set; }
        public string Text { get; set; }
        [JsonIgnore]
        public int UserId { get; set; }
    }
}
