using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apartment.Domain.Entities
{
    public class Apartment : Entity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string GoogleMap { get; set; }
        public string CordinateX { get; set; }
        public string CordinateY { get; set; }
        public int UserId { get; set; }
        public int CategoryId { get; set; }
        public int CityId { get; set; }
        public int FileId { get; set; }
        public int Priority { get; set; }
        public string Floor { get; set; }
        public string Street { get; set; }
        public string StreetNumber { get; set;}
        public bool? Garage { get; set; }
        public bool? WiFi { get; set; }
        public int RoomId { get; set; }
        public float Surface { get; set; }
        public int MinPerson { get; set; }
        public int MaxPerson {get;set;}
        public double PricePerPerson { get; set; }
        public string LocalCalendar { get; set; }
        public string RemoteCalendar { get; set; }
        public virtual Room Room { get; set; }
        public virtual User Author { get; set; }
        public virtual File Thumb { get; set; }
        public virtual Category CategoryOfApartment { get; set; }
        public virtual City City{ get; set; }
        public virtual ICollection<ApartmentSpecification> ApartmentSpecifications{ get; set; }
        public virtual ICollection<Report> Reports{ get; set; }
        public virtual ICollection<Rate> Rates{ get; set; }
        public virtual ICollection<Comment> Comments{ get; set; }
        public virtual ICollection<Image> Images{ get; set; }
        public virtual ICollection<Price> Prices{ get; set; }
        public virtual ICollection<SpecPrice> SpecPrices{ get; set; }
        public virtual ICollection<Reservation> Reservations{ get; set; }

    }
}
