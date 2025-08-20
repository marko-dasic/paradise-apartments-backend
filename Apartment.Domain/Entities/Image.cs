using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apartment.Domain.Entities
{
    public class Image : Entity
    {
        public int ApartmentId { get; set; }
        public int? FileId { get; set; }

        public virtual  File File { get; set; }
        public virtual  Apartment Apartment { get; set; }

    }
}
