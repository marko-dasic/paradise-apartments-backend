using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apartment.Domain.Entities
{
    public class SpecPrice : Entity
    {
        public int ApartmentId { get; set; }
        public DateTime Date { get; set; }
        public double Price { get; set; }
        public double PricePerPerson { get; set; }
        public virtual Apartment Apartment { get; set; }
    }
}
