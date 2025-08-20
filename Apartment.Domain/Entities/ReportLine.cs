using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apartment.Domain.Entities
{
    public class ReportLine : Entity
    {
        public string Name { get; set; }

        public virtual ICollection<Report> Reports { get; set; }
    }
}
