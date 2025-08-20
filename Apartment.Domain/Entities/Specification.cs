using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apartment.Domain.Entities
{
    public class Specification : Entity
    {
        public string Name { get; set; }
        public string MyIcon { get; set; }

        public virtual ICollection<ApartmentSpecification> ApartmentSpecifications { get; set; }
    }
}
