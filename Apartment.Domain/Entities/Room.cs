using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apartment.Domain.Entities
{
    public class Room : Entity
    {
        public string Value { get; set; }
        public virtual ICollection<Apartment> Apartments { get; set; }    
    }
}
