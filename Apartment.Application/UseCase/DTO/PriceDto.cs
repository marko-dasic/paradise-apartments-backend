using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apartment.Application.UseCase.DTO
{
    public class PriceDto : BaseDto
    {
        public double PricePerNight { get; set; }
        public double PriceOnHoliday { get; set; }
        public double PriceOnNewYear { get; set; }
        public int ApartmentId { get; set; }
    }

    public class PriceUpdateDto
    {
        public double PricePerNight { get; set; }
        public double PriceOnHoliday { get; set; }
        public double PriceOnNewYear { get; set; }
        
    }

}
