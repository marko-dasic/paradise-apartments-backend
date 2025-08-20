using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apartment.Domain.Entities
{
    public class Rate : Entity
    {
        public int Value { get; set; }
        public int UserId { get; set; }
        public int ApartmentId{ get; set; }

        public virtual User Author { get; set; }
        public virtual Apartment Apartment { get; set; }
    }
}
