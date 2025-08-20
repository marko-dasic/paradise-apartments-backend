using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apartment.Domain.Entities
{
    public class Reservation : Entity
    {
        public int ApartmentId { get; set; }
        public int? UserId { get; set; }
        public DateTime From { get; set; }
        public DateTime? To { get; set; }
        public double Amount { get; set; }
        public bool IsPaid { get; set; }
        public string FullName { get; set; }
        public int NumPerson { get; set; }
        public string Phone { get; set; }
        public bool Cancelled {get;set;}

        public virtual Apartment Apartment { get; set; }
        public virtual User User { get; set; }
    }
}
