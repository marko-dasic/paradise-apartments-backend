using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apartment.Domain.Entities
{
    public class Price : Entity
    {
        public  double PricePerNight { get; set; }
        public  double PriceOnHoliday { get; set; }
        public double PriceOnNewYear { get; set; }
        public int ApartmentId { get; set; }

        public virtual Apartment Apartment { get; set; }
    }
}
