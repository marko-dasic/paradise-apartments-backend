
namespace Apartment.Domain.Entities
{
    public class Blog : Entity
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string WorkTime { get; set; }
        public string GoogleMap { get; set; }
        public string Adress { get; set; }
        public int? FileId { get; set; }
        public virtual File File {get;set;}
    }
}
