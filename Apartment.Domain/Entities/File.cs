using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apartment.Domain.Entities
{
    public class File : Entity
    {
        public string Path { get; set; }
        public string Alt { get; set; }
        public string Extension { get; set; }
        public double Size { get; set; }

        
    }
}
