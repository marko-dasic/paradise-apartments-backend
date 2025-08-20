using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apartment.Domain.Entities
{
    public class Category : Entity
    {
        public string Name { get; set; }
        public int? ParrentId { get; set; }

        public virtual Category Parrent { get; set; }
        public virtual ICollection<Category> Childrends { get; set; }
        public virtual ICollection<Apartment> Apartments{ get; set; }
    }
}
