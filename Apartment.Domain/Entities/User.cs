using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apartment.Domain.Entities
{
    public class User : Entity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }

        public string ActivationCode { get; set; }
        public bool IsActivated { get; set; }

        public int? CityId { get; set; }

        public virtual City City { get; set; }
        public virtual ICollection<UserUseCase> UseCases{ get; set; }
        public virtual ICollection<Report> Reports { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Rate> Rates{ get; set; }
        public virtual ICollection<Reservation> Reservations{ get; set; }


    }
}
