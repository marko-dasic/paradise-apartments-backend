using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apartment.Domain.Entities
{
    public class Report :Entity
    {
        public string Text { get; set; }
        public int? ReportLineId { get; set; }
        public int UserId{ get; set; }
        public int ApartmentId { get; set; }


        public virtual ReportLine ReportLine { get; set; }
        public virtual User User { get; set; }
        public virtual Apartment Apartment { get; set; }
    }
}
