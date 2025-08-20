using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apartment.Domain.Entities
{
    public class Comment :Entity
    {
        public string Text { get; set; }
        public int AppartmentId { get; set; }
        public int UserId { get; set; }
        public int? ParrentId { get; set; }

        public virtual Comment Parrent { get; set; }
        public virtual ICollection<Comment> ChildComments{ get; set; }
        public virtual User Author { get; set; }
        public virtual Apartment Apartment { get; set; }


    }
}
