using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apartment.Domain.Entities
{
    public class ApartmentSpecification : Entity
    {
        public int ApartmentId { get; set; }
        public int SpecificationId { get; set; }

        public string Value { get; set; }

        public virtual Apartment Apartment { get; set; }
        public virtual Specification Specification { get; set; }
    }
}
