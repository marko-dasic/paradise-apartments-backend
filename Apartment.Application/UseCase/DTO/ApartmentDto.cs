using Apartment.Domain.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apartment.Application.UseCase.DTO
{
    public class ApartmentDto : BaseDto
    {

        public string Title { get; set; }
        public string Description { get; set; }
        public string GoogleMap { get; set; }
        public string CordinateX { get; set; }
        public string CordinateY { get; set; }
        public string Floor { get; set; }
        public bool? Garage { get; set; }
        public bool? WiFi { get; set; }
        public int MinPerson { get; set; }
        public int MaxPerson { get; set; }
        public double PricePerPerson { get; set; }
        public string Street { get; set; }
        public string StreetNumber { get; set; }
         public string LocalCalendar { get; set; }
        public string RemoteCalendar { get; set; }
        public List<DateTime> ClosedDates { get; set; }
        public RoomDto Room { get; set; }
        public PriceDto Price { get; set; }
        public UserDto User { get; set; }
        public CategoryDto Category { get; set; }
        public CityDto City { get; set; }
        public FileDto File { get; set; }
        public IEnumerable<SpecPriceGetDto> SpecPrices{ get; set; }
        public IEnumerable<RateDto> Rates { get; set; }
        public IEnumerable<FileDto> Images { get; set; }
        public IEnumerable<ReservationDto> Reservations { get; set; }
        public IEnumerable<CommentDto> Comments { get; set; }
        public IEnumerable<ApartmentSpecificationDto> ApartmentSpecifications { get; set; }
        public int Priority { get; set; }
        public float Surface { get; set; }

    }

    public class CreateApartmentDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string GoogleMap { get; set; }
        public string CordinateX { get; set; }
        public string CordinateY { get; set; }
        public int CategoryId { get; set; }
        public int CityId { get; set; }
        public string File { get; set; }
        public int? FileId { get; set; }
        public string Floor { get; set; }
        public bool? Garage { get; set; }
        public bool? WiFi { get; set; }
        public int RoomId { get; set; }
        public int MinPerson { get; set; }
        public int MaxPerson { get; set; }
        public double PricePerPerson { get; set; }
        public string Street { get; set; }
        public string StreetNumber { get; set; }
        public string RemoteCalendar { get; set; }
        public PriceDto Price { get; set; }
        public IEnumerable<string> Images { get; set; }
        public int Priority { get; set; }
        public float Surface { get; set; }
        public IEnumerable<SpecPriceDto> SpecPrices { get; set; }
        public IEnumerable<ApartmentSpecificationDto> Specification { get; set; }
    }

    public class UpdateApartmentDto : BaseDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string GoogleMap { get; set; }
        public string CordinateX { get; set; }
        public string CordinateY { get; set; }
        public int CategoryId { get; set; }
        public int CityId { get; set; }
        public string File { get; set; } = null;
        public int? FileId { get; set; } = null;
        public string Floor { get; set; }
        public bool? Garage { get; set; }
        public bool? WiFi { get; set; }
        public int? MinPerson { get; set; }
        public int? MaxPerson { get; set; }
        public double? PricePerPerson { get; set; }
        public int RoomId { get; set; }
        public string RemoteCalendar { get; set; }
        public PriceUpdateDto Price { get; set; }
        public IEnumerable<int> ImagesIds { get; set; } = null;
        public IEnumerable<string> Images { get; set; } = null;
        public IEnumerable<SpecPriceDto> SpecPrices { get; set; }

        public int Priority { get; set; } = 3;
        public float Surface { get; set; }

    }

    public class PaginatedApartmentDto
    {
        public IEnumerable<ApartmentDto> Apartments { get; set; }
        public int NumberApartments { get; set; }
    }
}
