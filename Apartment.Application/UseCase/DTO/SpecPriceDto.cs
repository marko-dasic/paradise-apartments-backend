using Apartment.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apartment.Application.UseCase.DTO
{
    public class SpecPriceDto
    {
        public DateTime Date { get; set; }  
        public double Price { get; set; }
        public double PricePerPerson { get; set; }
        public int ApartmentId { get; set; }
    }

    public class SpecPriceGetDto
    {
        public DateTime Date { get; set; }
        public double Price { get; set; }
        public double PricePerPerson { get; set; }
    }
}
